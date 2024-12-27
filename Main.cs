using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TEAMS_csv_To_xlsx.Models;

namespace TEAMS_csv_To_xlsx
{
    public partial class fmrInicial : Form
    {
        private int arquivos = 0;
        private int pastas = 0;
        private readonly Encoding encoding = Encoding.Unicode;

        // Declarar explicitamente o tipo do campo 'data'
        private Dictionary<string, List<AttendanceRecord>> data = [];

        public fmrInicial()
        {
            InitializeComponent();
        }

        private void BtnSelecionar_Click(object sender, EventArgs e)
        {
            if (fbdPathCsv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPath.Text = fbdPathCsv.SelectedPath;
                CarregarPasta();
                lblArquivos.Text = this.arquivos.ToString();
                lblPastas.Text = this.pastas.ToString();
            }
        }

        private void CarregarPasta()
        {
            try
            {
                // Define o valor inicial da progressbar
                pgBarCsv.Value = 0;
                // Limpa todos os Nodes 
                tvDados.Nodes.Clear();
                //Carrega os dados da Pasta informada se ela existir
                if (txtPath.Text != "" && Directory.Exists(txtPath.Text))
                {
                    CarregaDadosPasta(txtPath.Text);
                    tvDados.Nodes[0].Expand();
                }
                else
                {
                    MessageBox.Show("Selecione uma pasta!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:\n" + ex.Message);
            }
        }

        private void CarregaDadosPasta(string diretorio)
        {
            try
            {
                DirectoryInfo diretorioInfo = new(diretorio);
                //Define o valor máximo do ProgressBar
                pgBarCsv.Maximum = Directory.GetFiles(diretorio, "*.*", SearchOption.AllDirectories).Length + Directory.GetDirectories(diretorio, "**", SearchOption.AllDirectories).Length;
                TreeNode tds = tvDados.Nodes.Add(diretorioInfo.Name);
                tds.Tag = diretorioInfo.FullName;
                tds.StateImageIndex = 1;
                tds.ImageIndex = 1;
                tds.SelectedImageIndex = 1;

                //carrega os arquivos e as subpastas
                CarregaArquivos(diretorio, tds);
                CarregaSubDiretorios(diretorio, tds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sem permissões para a pasta!\n" + ex.Message);
            }
        }

        private void CarregaArquivos(string diretorio, TreeNode tnd)
        {
            string[] arquivos = Directory.GetFiles(diretorio, "*.*");
            // Percorre os arquivos
            foreach (string arq in arquivos)
            {
                FileInfo arquivo = new(arq);
                TreeNode tds = tnd.Nodes.Add(arquivo.Name);
                tds.Tag = arquivo.FullName;
                tds.StateImageIndex = 0;
                tds.ImageIndex = 0;
                tds.SelectedImageIndex = 0;
                AtualizaProgressBar();
                this.arquivos++;
            }
        }

        private void CarregaSubDiretorios(string dir, TreeNode td)
        {
            // Pega todos os subdiretorios
            string[] subdiretorioEntradas = Directory.GetDirectories(dir);
            // Percorre os subdiretorios a ver se existem outras subpasts
            foreach (string subdiretorio in subdiretorioEntradas)
            {
                DirectoryInfo diretorio = new(subdiretorio);
                TreeNode tds = td.Nodes.Add(diretorio.Name);
                tds.StateImageIndex = 1;
                tds.ImageIndex = 1;
                tds.SelectedImageIndex = 1;
                tds.Tag = diretorio.FullName;
                CarregaArquivos(subdiretorio, tds);
                CarregaSubDiretorios(subdiretorio, tds);
                AtualizaNomeDoNo(tds);
                AtualizaProgressBar();
                this.pastas++;
            }
        }

        private static void AtualizaNomeDoNo(TreeNode no)
        {
            int numeroDeArquivos = ContarArquivos(no);
            no.Text = (numeroDeArquivos > 1 || numeroDeArquivos == 0) ? $"{no.Text} ({numeroDeArquivos} arquivos)" : $"{no.Text} ({numeroDeArquivos} arquivo)";
        }

        private static int ContarArquivos(TreeNode no)
        {
            int count = 0;
            foreach (TreeNode child in no.Nodes)
            {
                if (child.Nodes.Count > 0)
                {
                    count += ContarArquivos(child);
                }
                else
                {
                    count++;
                }
            }
            return count;
        }

        private void AtualizaProgressBar()
        {
            if (pgBarCsv.Value < pgBarCsv.Maximum)
            {
                pgBarCsv.Value++;
                int percentual = (int)(((double)pgBarCsv.Value / (double)pgBarCsv.Maximum) * 100);
                pgBarCsv.CreateGraphics().DrawString(
                    percentual.ToString() + "%",
                    new Font("Arial", (float)8.25, FontStyle.Bold),
                    Brushes.White,
                    new PointF(pgBarCsv.Width / 2 - 10, pgBarCsv.Height / 2 - 7)
                );
                Application.DoEvents();
            }
        }

        private void BtnPathExport_Click(object sender, EventArgs e)
        {
            if (fbdPathXlsx.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPathExport.Text = fbdPathXlsx.SelectedPath;
            }
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            btnConvert.Enabled = false;

            txtDetail.Clear();

            txtDetail.Text += "  ======  INICIANDO PROCESSO DE CONVERSÃO  ======  \r\n \r\n";

            foreach (string subDir in Directory.GetDirectories(txtPath.Text))
            {
                // Adiciona a turma a lista usando o nomes da pasta
                string turmaKey = new DirectoryInfo(subDir).Name;
                if (!data.ContainsKey(turmaKey))
                {
                    data[turmaKey] = [];
                }

                // Adiciona o nome da turma no status
                txtDetail.Text += turmaKey + "\r\n";

                // Cria uma lista de estudantes nos arquivos.
                List<Person> students = GetStudents(subDir);

                // Verifica a presença de cada aluno nos arquivos
                data[turmaKey] = GetAttendanceRecordsFiles(subDir, students);

                btnConvert.Enabled = true;

                txtDetail.Text += "\r\n";

                // Caminho do arquivo onde as informações serão gravadas
                string filePath = @"C:\CSharp\output.txt";

                // Grava os dados de forma resumida no arquivo
                PrintAttendanceData(data, filePath);
            }

        }

        private List<Person> GetStudents(string subDir)
        {
            var persons = new List<Person>();
            var emails = new HashSet<string>();

            foreach (string file in Directory.GetFiles(subDir, "*.csv"))
            {
                using (var reader = new StreamReader(file, encoding))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var values = line.Split('\t');

                        if (values.Length > 6 && IsValidEmail(values[4]))
                        {
                            string email = values[4];
                            if (!emails.Contains(email))
                            {
                                emails.Add(email);

                                // Extrai o número do e-mail
                                int rm = ExtractNumberFromEmail(email);

                                Person person = new(
                                    rm,
                                    values[0],
                                    email,
                                    (values[6] == "Organizer" || values[6] == "Organizador") ? "EQUIPE" : "ALUNO");
                                persons.Add(person);
                            }
                        }
                    }
                }
            }
            txtDetail.Text += "    1. Levantamento de alunos: [ " + emails.Count + " ]\r\n";
            //txtDetail.Text += string.Join("\r\n", students) + "\r\n";
            return persons;
        }

        private List<AttendanceRecord> GetAttendanceRecordsFiles(string subDir, List<Person> students)
        {
            var attendanceRecords = new List<AttendanceRecord>();
            txtDetail.Text += "    2. Levantamento de presentes...";
            foreach (string file in Directory.GetFiles(subDir, "*.csv"))
            {
                AttendanceRecord record = new()
                {
                    File = Path.GetFileName(file)
                };

                using (var reader = new StreamReader(file, encoding))
                {
                    string line;
                    int i = 0;
                    var emails = new HashSet<string>();

                    while ((line = reader.ReadLine()) != null)
                    {
                        var values = line.Split('\t');

                        if (i == 3)
                        {
                            record.Data = ConverteData(values[1]);
                        }

                        if (values.Length > 6 && IsValidEmail(values[4]))
                        {
                            emails.Add(values[4]);
                        }

                        i++;
                    }
                    record.Presentes = new List<string>(emails);
                    record.Pessoas = students;
                }
                attendanceRecords.Add(record);
            }
            txtDetail.Text += " Concluído!\r\n";

            return attendanceRecords;
        }

        public static bool IsValidEmail(string email)
        {
            // Define a expressão regular para validar o e-mail
            string pattern = @"^[a-zA-Z0-9._%+-]+@(fatcursos\.org\.br|pmc\.fatcursos\.org\.br)$";

            // Cria uma instância da classe Regex com o padrão especificado
            Regex regex = new(pattern, RegexOptions.IgnoreCase);

            // Verifica se o e-mail corresponde ao padrão
            return regex.IsMatch(email);
        }

        public static string ConverteData(string inputDate)
        {
            // Define o formato de data e hora da string de entrada
            string inputFormat = "M/d/yy, h:mm:ss tt";

            // Define o formato de saída desejado
            string outputFormat = "dd/MM/yy";

            // Faz o parsing da string para um objeto DateTime
            DateTime parsedDate = DateTime.ParseExact(inputDate, inputFormat, CultureInfo.InvariantCulture);

            // Formata o objeto DateTime para a string desejada
            return parsedDate.ToString(outputFormat);
        }

        public static int ExtractNumberFromEmail(string email)
        {
            // Usa uma expressão regular para encontrar números antes do '@'
            string pattern = @"(\d+)(?=@)";
            Regex regex = new(pattern);
            Match match = regex.Match(email);

            // Se houver um número, retorna ele como inteiro. Caso contrário, retorna 0.
            return match.Success ? int.Parse(match.Value) : 0;
        }

        private static void PrintAttendanceData(Dictionary<string, List<AttendanceRecord>> data, string filePath)
        {
            using (StreamWriter writer = new(filePath, false, Encoding.UTF8))
            {
                foreach (var turma in data)
                {
                    writer.WriteLine($"Turma: {turma.Key}");
                    foreach (var record in turma.Value)
                    {
                        writer.WriteLine($"\n Data: {record.Data}");
                        writer.WriteLine($"ALUNOS: \n{string.Join("\n", record.Pessoas)}");
                        writer.WriteLine($"Presentes: \n{string.Join("\n", record.Presentes)}");
                    }
                    writer.WriteLine("\n");
                }
            }

            Console.WriteLine($"Dados gravados com sucesso em: {filePath}");
        }

        private void MontarPlanilha()
        {

        }
    }
}
