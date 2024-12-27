namespace TEAMS_csv_To_xlsx
{
    partial class fmrInicial
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmrInicial));
            btnSelecionar = new Button();
            fbdPathCsv = new FolderBrowserDialog();
            txtPath = new TextBox();
            tvDados = new TreeView();
            imageListFolder = new ImageList(components);
            pgBarCsv = new ProgressBar();
            groupBox1 = new GroupBox();
            label6 = new Label();
            txtDetail = new TextBox();
            pgBarConvert = new ProgressBar();
            btnConvert = new Button();
            label5 = new Label();
            btnPathExport = new Button();
            label4 = new Label();
            label3 = new Label();
            txtPathExport = new TextBox();
            lblArquivos = new Label();
            lblPastas = new Label();
            label2 = new Label();
            label1 = new Label();
            txtFileNameExport = new TextBox();
            fbdPathXlsx = new FolderBrowserDialog();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelecionar
            // 
            btnSelecionar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelecionar.BackColor = SystemColors.Highlight;
            btnSelecionar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelecionar.ForeColor = Color.White;
            btnSelecionar.Location = new Point(1166, 14);
            btnSelecionar.Margin = new Padding(4);
            btnSelecionar.Name = "btnSelecionar";
            btnSelecionar.Size = new Size(171, 32);
            btnSelecionar.TabIndex = 0;
            btnSelecionar.Text = "Selecionar Pasta";
            btnSelecionar.UseVisualStyleBackColor = false;
            btnSelecionar.Click += BtnSelecionar_Click;
            // 
            // fbdPathCsv
            // 
            fbdPathCsv.RootFolder = Environment.SpecialFolder.Recent;
            fbdPathCsv.ShowNewFolderButton = false;
            // 
            // txtPath
            // 
            txtPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPath.Location = new Point(13, 16);
            txtPath.Margin = new Padding(4);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(1145, 29);
            txtPath.TabIndex = 1;
            // 
            // tvDados
            // 
            tvDados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tvDados.ImageIndex = 1;
            tvDados.ImageList = imageListFolder;
            tvDados.Location = new Point(14, 90);
            tvDados.Margin = new Padding(4);
            tvDados.Name = "tvDados";
            tvDados.SelectedImageIndex = 0;
            tvDados.Size = new Size(791, 626);
            tvDados.TabIndex = 2;
            // 
            // imageListFolder
            // 
            imageListFolder.ColorDepth = ColorDepth.Depth32Bit;
            imageListFolder.ImageStream = (ImageListStreamer)resources.GetObject("imageListFolder.ImageStream");
            imageListFolder.TransparentColor = Color.Transparent;
            imageListFolder.Images.SetKeyName(0, "pasta.png");
            imageListFolder.Images.SetKeyName(1, "arquivo.png");
            // 
            // pgBarCsv
            // 
            pgBarCsv.Location = new Point(13, 53);
            pgBarCsv.Margin = new Padding(4);
            pgBarCsv.Name = "pgBarCsv";
            pgBarCsv.Size = new Size(792, 29);
            pgBarCsv.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtDetail);
            groupBox1.Controls.Add(pgBarConvert);
            groupBox1.Controls.Add(btnConvert);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnPathExport);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtPathExport);
            groupBox1.Controls.Add(lblArquivos);
            groupBox1.Controls.Add(lblPastas);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtFileNameExport);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DarkGreen;
            groupBox1.Location = new Point(820, 53);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(516, 663);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "CONVERTER PARA EXCEL";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.WindowText;
            label6.Location = new Point(19, 427);
            label6.Name = "label6";
            label6.Size = new Size(186, 21);
            label6.TabIndex = 13;
            label6.Text = "Detalhes da conversão:";
            // 
            // txtDetail
            // 
            txtDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDetail.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDetail.Location = new Point(19, 451);
            txtDetail.Multiline = true;
            txtDetail.Name = "txtDetail";
            txtDetail.ScrollBars = ScrollBars.Both;
            txtDetail.Size = new Size(479, 191);
            txtDetail.TabIndex = 12;
            // 
            // pgBarConvert
            // 
            pgBarConvert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pgBarConvert.Location = new Point(19, 382);
            pgBarConvert.Name = "pgBarConvert";
            pgBarConvert.Size = new Size(479, 25);
            pgBarConvert.TabIndex = 11;
            // 
            // btnConvert
            // 
            btnConvert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnConvert.BackColor = Color.LimeGreen;
            btnConvert.ForeColor = Color.White;
            btnConvert.Image = Properties.Resources.xlxs;
            btnConvert.ImageAlign = ContentAlignment.MiddleRight;
            btnConvert.Location = new Point(19, 314);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(479, 53);
            btnConvert.TabIndex = 10;
            btnConvert.Text = "CONVERTER";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += BtnConvert_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.ForeColor = Color.DarkGreen;
            label5.Location = new Point(454, 178);
            label5.Name = "label5";
            label5.Size = new Size(44, 21);
            label5.TabIndex = 9;
            label5.Text = ".xlxs";
            // 
            // btnPathExport
            // 
            btnPathExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPathExport.Image = Properties.Resources.pasta;
            btnPathExport.Location = new Point(454, 251);
            btnPathExport.Name = "btnPathExport";
            btnPathExport.Size = new Size(44, 44);
            btnPathExport.TabIndex = 8;
            btnPathExport.UseVisualStyleBackColor = true;
            btnPathExport.Click += BtnPathExport_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.DarkGreen;
            label4.Location = new Point(19, 236);
            label4.Name = "label4";
            label4.Size = new Size(182, 21);
            label4.TabIndex = 7;
            label4.Text = "Local para Exportação:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.DarkGreen;
            label3.Location = new Point(19, 151);
            label3.Name = "label3";
            label3.Size = new Size(276, 21);
            label3.TabIndex = 6;
            label3.Text = "Nome do arquivo para Exportação:";
            // 
            // txtPathExport
            // 
            txtPathExport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPathExport.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPathExport.Location = new Point(19, 260);
            txtPathExport.Name = "txtPathExport";
            txtPathExport.PlaceholderText = "Clique no botão ao lado para escolher o local de exportação do arquivo ";
            txtPathExport.Size = new Size(429, 29);
            txtPathExport.TabIndex = 5;
            // 
            // lblArquivos
            // 
            lblArquivos.AutoSize = true;
            lblArquivos.BorderStyle = BorderStyle.FixedSingle;
            lblArquivos.ForeColor = SystemColors.Highlight;
            lblArquivos.Location = new Point(225, 86);
            lblArquivos.Name = "lblArquivos";
            lblArquivos.Size = new Size(21, 23);
            lblArquivos.TabIndex = 4;
            lblArquivos.Text = "0";
            // 
            // lblPastas
            // 
            lblPastas.AutoSize = true;
            lblPastas.BorderStyle = BorderStyle.FixedSingle;
            lblPastas.ForeColor = SystemColors.Highlight;
            lblPastas.Location = new Point(225, 44);
            lblPastas.Name = "lblPastas";
            lblPastas.Size = new Size(21, 23);
            lblPastas.TabIndex = 3;
            lblPastas.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.WindowText;
            label2.Location = new Point(19, 88);
            label2.Name = "label2";
            label2.Size = new Size(189, 21);
            label2.TabIndex = 2;
            label2.Text = "Arquivos encontrados..:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.WindowText;
            label1.Location = new Point(19, 46);
            label1.Name = "label1";
            label1.Size = new Size(188, 21);
            label1.TabIndex = 1;
            label1.Text = "Pastas encontradas.......:";
            // 
            // txtFileNameExport
            // 
            txtFileNameExport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFileNameExport.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFileNameExport.Location = new Point(19, 175);
            txtFileNameExport.Name = "txtFileNameExport";
            txtFileNameExport.PlaceholderText = "Digite o nome arquivo";
            txtFileNameExport.Size = new Size(429, 29);
            txtFileNameExport.TabIndex = 0;
            // 
            // fbdPathXlsx
            // 
            fbdPathXlsx.AddToRecent = false;
            // 
            // fmrInicial
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(groupBox1);
            Controls.Add(pgBarCsv);
            Controls.Add(tvDados);
            Controls.Add(txtPath);
            Controls.Add(btnSelecionar);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "fmrInicial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conversor de Presença (CSV) do TEAMS para Excel";
            WindowState = FormWindowState.Maximized;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSelecionar;
        private FolderBrowserDialog fbdPathCsv;
        private TextBox txtPath;
        private TreeView tvDados;
        private ImageList imageListFolder;
        private ProgressBar pgBarCsv;
        private GroupBox groupBox1;
        private TextBox txtFileNameExport;
        private Label label2;
        private Label label1;
        private Label lblArquivos;
        private Label lblPastas;
        private TextBox txtPathExport;
        private Label label4;
        private Label label3;
        private Label label5;
        private Button btnPathExport;
        private Button btnConvert;
        private ProgressBar pgBarConvert;
        private FolderBrowserDialog fbdPathXlsx;
        private Label label6;
        private TextBox txtDetail;
    }
}
