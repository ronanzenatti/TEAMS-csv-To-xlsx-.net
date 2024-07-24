using System.Text;

namespace TEAMS_csv_To_xlsx
{
    public partial class fmrInicial : Form
    {
        private int arquivos = 0;
        private int pastas = 0;

        private static Dictionary<string, Dictionary<string, List<string>>> dados = new Dictionary<string, Dictionary<string, List<string>>>();

        public fmrInicial()
        {
            InitializeComponent();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
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

        private void CarregaDadosPasta(string diretorio)
        {
            DirectoryInfo diretorioInfo = new DirectoryInfo(diretorio);
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

        private void CarregaArquivos(string diretorio, TreeNode tnd)
        {
            string[] arquivos = Directory.GetFiles(diretorio, "*.*");
            // Percorre os arquivos
            foreach (string arq in arquivos)
            {
                FileInfo arquivo = new FileInfo(arq);
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
                DirectoryInfo diretorio = new DirectoryInfo(subdiretorio);
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
            no.Text = $"{no.Text} ({numeroDeArquivos} arquivos)";
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
                    new Font("Arial", (float)8.25, FontStyle.Regular),
                    Brushes.Black,
                    new PointF(pgBarCsv.Width / 2 - 10, pgBarCsv.Height / 2 - 7)
                );
                Application.DoEvents();
            }
        }

        private void btnPathExport_Click(object sender, EventArgs e)
        {
            if (fbdPathXlsx.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPathExport.Text = fbdPathXlsx.SelectedPath;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            Encoding encoding = Encoding.Unicode;

            txtDetail.Clear();

            foreach (string subDir in Directory.GetDirectories(txtPath.Text))
            {
                string turmaKey = new DirectoryInfo(subDir).Name;
                dados[turmaKey] = new Dictionary<string, List<string>>();

                txtDetail.Text += turmaKey + "\r\n";

                foreach (string file in Directory.GetFiles(subDir, "*.csv"))
                {
                    txtDetail.Text += Path.GetFileName(file) + "\r\n";

                    var parte = 0;
                    string data;

                    using (var reader = new StreamReader(file, encoding))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            var values = line.Split('\t');

                            if (values[0].StartsWith("1."))
                            {
                                parte = 1; break;
                            }
                            else if (values[0].StartsWith("2."))
                            {
                                parte = 2; break;
                            }
                            else if (values[0].StartsWith("3."))
                            {
                                parte = 3; break;
                            }

                            if (values[0].StartsWith("Start time") || values[0].StartsWith("Hora de início"))
                            {
                                data = values[1]; break;
                            }

                            if (parte == 2)
                            {
                                if (values[6] != "Organizer" && values[6] != "Organizador")
                                {
                                    string email = values[4];
                                    string nome = values[1];

                                    dados[turmaKey][email] = new List<string> { nome };
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
