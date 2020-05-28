namespace ConvolutionMethod
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbCam = new System.Windows.Forms.ToolStripComboBox();
            this.btnVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCircle = new System.Windows.Forms.ToolStripButton();
            this.btnSelection = new System.Windows.Forms.ToolStripButton();
            this.groupZones = new System.Windows.Forms.GroupBox();
            this.cmbMeasure = new System.Windows.Forms.ComboBox();
            this.btnCalcDifference = new System.Windows.Forms.Button();
            this.listZones = new System.Windows.Forms.ListBox();
            this.btnReconHolo = new System.Windows.Forms.Button();
            this.groupParamProcess = new System.Windows.Forms.GroupBox();
            this.lblCurrentDistance = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.numStep = new System.Windows.Forms.NumericUpDown();
            this.lblNumStep = new System.Windows.Forms.Label();
            this.lblSizeStep = new System.Windows.Forms.Label();
            this.txbSizeStep = new System.Windows.Forms.TextBox();
            this.btnGenHolo = new System.Windows.Forms.Button();
            this.groupColor = new System.Windows.Forms.GroupBox();
            this.rbtnPhase = new System.Windows.Forms.RadioButton();
            this.rbtnAmp = new System.Windows.Forms.RadioButton();
            this.lblChannel = new System.Windows.Forms.Label();
            this.cmbChannel = new System.Windows.Forms.ComboBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblN = new System.Windows.Forms.Label();
            this.groupParamHolo = new System.Windows.Forms.GroupBox();
            this.lblDist = new System.Windows.Forms.Label();
            this.txbDist = new System.Windows.Forms.TextBox();
            this.lblDx = new System.Windows.Forms.Label();
            this.txbDx = new System.Windows.Forms.TextBox();
            this.lblWave = new System.Windows.Forms.Label();
            this.txbWave = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.picSourceImage = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.picGenHolo = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.picReconHolo = new System.Windows.Forms.PictureBox();
            this.tabZones = new System.Windows.Forms.TabPage();
            this.groupAnalyzeZones = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.picAnalyze = new System.Windows.Forms.PictureBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.picScale = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picScale2 = new System.Windows.Forms.PictureBox();
            this.tabVideo = new System.Windows.Forms.TabPage();
            this.picVideo = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupZones.SuspendLayout();
            this.groupParamProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStep)).BeginInit();
            this.groupColor.SuspendLayout();
            this.groupParamHolo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSourceImage)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGenHolo)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReconHolo)).BeginInit();
            this.tabZones.SuspendLayout();
            this.groupAnalyzeZones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnalyze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScale)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScale2)).BeginInit();
            this.tabVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFile,
            this.видToolStripMenuItem,
            this.cmbCam,
            this.btnVideo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(964, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnFile
            // 
            this.btnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnExit});
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(48, 23);
            this.btnFile.Text = "Файл";
            // 
            // btnOpen
            // 
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(121, 22);
            this.btnOpen.Text = "Открыть";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(121, 22);
            this.btnExit.Text = "Выход";
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 23);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // cmbCam
            // 
            this.cmbCam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCam.Name = "cmbCam";
            this.cmbCam.Size = new System.Drawing.Size(121, 23);
            this.cmbCam.SelectedIndexChanged += new System.EventHandler(this.cmbCam_SelectedIndexChanged);
            // 
            // btnVideo
            // 
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(89, 23);
            this.btnVideo.Text = "Захват видео";
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 647);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(964, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel1.Text = "Готово";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.groupZones);
            this.panel1.Controls.Add(this.btnReconHolo);
            this.panel1.Controls.Add(this.groupParamProcess);
            this.panel1.Controls.Add(this.btnGenHolo);
            this.panel1.Controls.Add(this.groupColor);
            this.panel1.Controls.Add(this.groupParamHolo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(682, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 620);
            this.panel1.TabIndex = 11;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Enabled = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.btnCircle,
            this.btnSelection});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(282, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(146, 22);
            this.toolStripLabel1.Text = "Инструменты выделения";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCircle
            // 
            this.btnCircle.CheckOnClick = true;
            this.btnCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCircle.Image = ((System.Drawing.Image)(resources.GetObject("btnCircle.Image")));
            this.btnCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(23, 22);
            this.btnCircle.Text = "Окружность";
            this.btnCircle.CheckStateChanged += new System.EventHandler(this.btnCircle_CheckStateChanged);
            // 
            // btnSelection
            // 
            this.btnSelection.CheckOnClick = true;
            this.btnSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelection.Image = ((System.Drawing.Image)(resources.GetObject("btnSelection.Image")));
            this.btnSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(23, 22);
            this.btnSelection.Text = "Произвольная область";
            this.btnSelection.CheckStateChanged += new System.EventHandler(this.btnSelection_CheckStateChanged);
            // 
            // groupZones
            // 
            this.groupZones.Controls.Add(this.cmbMeasure);
            this.groupZones.Controls.Add(this.btnCalcDifference);
            this.groupZones.Controls.Add(this.listZones);
            this.groupZones.Enabled = false;
            this.groupZones.Location = new System.Drawing.Point(41, 413);
            this.groupZones.Name = "groupZones";
            this.groupZones.Size = new System.Drawing.Size(196, 203);
            this.groupZones.TabIndex = 15;
            this.groupZones.TabStop = false;
            this.groupZones.Text = "Список анализируемых областей";
            // 
            // cmbMeasure
            // 
            this.cmbMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeasure.FormattingEnabled = true;
            this.cmbMeasure.Items.AddRange(new object[] {
            "PSNR",
            "RMSE",
            "All Measures"});
            this.cmbMeasure.Location = new System.Drawing.Point(6, 17);
            this.cmbMeasure.Name = "cmbMeasure";
            this.cmbMeasure.Size = new System.Drawing.Size(184, 21);
            this.cmbMeasure.TabIndex = 15;
            this.cmbMeasure.SelectedIndexChanged += new System.EventHandler(this.cmbMeasure_SelectedIndexChanged);
            // 
            // btnCalcDifference
            // 
            this.btnCalcDifference.Location = new System.Drawing.Point(3, 171);
            this.btnCalcDifference.Name = "btnCalcDifference";
            this.btnCalcDifference.Size = new System.Drawing.Size(190, 26);
            this.btnCalcDifference.TabIndex = 14;
            this.btnCalcDifference.Text = "Рассчитать оценки";
            this.btnCalcDifference.UseVisualStyleBackColor = true;
            this.btnCalcDifference.Click += new System.EventHandler(this.btnCalcDifference_Click);
            // 
            // listZones
            // 
            this.listZones.Enabled = false;
            this.listZones.FormattingEnabled = true;
            this.listZones.Location = new System.Drawing.Point(3, 44);
            this.listZones.Name = "listZones";
            this.listZones.Size = new System.Drawing.Size(190, 121);
            this.listZones.TabIndex = 0;
            this.listZones.SelectedIndexChanged += new System.EventHandler(this.listZones_SelectedIndexChanged);
            // 
            // btnReconHolo
            // 
            this.btnReconHolo.Enabled = false;
            this.btnReconHolo.Location = new System.Drawing.Point(143, 384);
            this.btnReconHolo.Name = "btnReconHolo";
            this.btnReconHolo.Size = new System.Drawing.Size(96, 23);
            this.btnReconHolo.TabIndex = 14;
            this.btnReconHolo.Text = "Восстановить";
            this.btnReconHolo.UseVisualStyleBackColor = true;
            this.btnReconHolo.Click += new System.EventHandler(this.btnReconHolo_Click);
            // 
            // groupParamProcess
            // 
            this.groupParamProcess.Controls.Add(this.lblCurrentDistance);
            this.groupParamProcess.Controls.Add(this.trackBar1);
            this.groupParamProcess.Controls.Add(this.numStep);
            this.groupParamProcess.Controls.Add(this.lblNumStep);
            this.groupParamProcess.Controls.Add(this.lblSizeStep);
            this.groupParamProcess.Controls.Add(this.txbSizeStep);
            this.groupParamProcess.Enabled = false;
            this.groupParamProcess.Location = new System.Drawing.Point(41, 257);
            this.groupParamProcess.Name = "groupParamProcess";
            this.groupParamProcess.Size = new System.Drawing.Size(196, 121);
            this.groupParamProcess.TabIndex = 11;
            this.groupParamProcess.TabStop = false;
            this.groupParamProcess.Text = "Параметры восстановления";
            // 
            // lblCurrentDistance
            // 
            this.lblCurrentDistance.AutoSize = true;
            this.lblCurrentDistance.Location = new System.Drawing.Point(69, 105);
            this.lblCurrentDistance.Name = "lblCurrentDistance";
            this.lblCurrentDistance.Size = new System.Drawing.Size(47, 13);
            this.lblCurrentDistance.TabIndex = 6;
            this.lblCurrentDistance.Text = "0.00 mm";
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(6, 70);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(180, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // numStep
            // 
            this.numStep.Location = new System.Drawing.Point(86, 46);
            this.numStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStep.Name = "numStep";
            this.numStep.Size = new System.Drawing.Size(100, 20);
            this.numStep.TabIndex = 4;
            this.numStep.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numStep.ValueChanged += new System.EventHandler(this.txbWave_TextChanged);
            // 
            // lblNumStep
            // 
            this.lblNumStep.AutoSize = true;
            this.lblNumStep.Location = new System.Drawing.Point(45, 48);
            this.lblNumStep.Name = "lblNumStep";
            this.lblNumStep.Size = new System.Drawing.Size(35, 13);
            this.lblNumStep.TabIndex = 3;
            this.lblNumStep.Text = "steps:";
            // 
            // lblSizeStep
            // 
            this.lblSizeStep.AutoSize = true;
            this.lblSizeStep.Location = new System.Drawing.Point(26, 22);
            this.lblSizeStep.Name = "lblSizeStep";
            this.lblSizeStep.Size = new System.Drawing.Size(52, 13);
            this.lblSizeStep.TabIndex = 1;
            this.lblSizeStep.Text = "step, mm:";
            // 
            // txbSizeStep
            // 
            this.txbSizeStep.Location = new System.Drawing.Point(86, 19);
            this.txbSizeStep.Name = "txbSizeStep";
            this.txbSizeStep.Size = new System.Drawing.Size(100, 20);
            this.txbSizeStep.TabIndex = 0;
            this.txbSizeStep.Text = "0.1";
            this.txbSizeStep.TextChanged += new System.EventHandler(this.txbWave_TextChanged);
            // 
            // btnGenHolo
            // 
            this.btnGenHolo.Enabled = false;
            this.btnGenHolo.Location = new System.Drawing.Point(41, 384);
            this.btnGenHolo.Name = "btnGenHolo";
            this.btnGenHolo.Size = new System.Drawing.Size(96, 23);
            this.btnGenHolo.TabIndex = 13;
            this.btnGenHolo.Text = "Сгенерировать";
            this.btnGenHolo.UseVisualStyleBackColor = true;
            this.btnGenHolo.Click += new System.EventHandler(this.btnGenHolo_Click);
            // 
            // groupColor
            // 
            this.groupColor.Controls.Add(this.rbtnPhase);
            this.groupColor.Controls.Add(this.rbtnAmp);
            this.groupColor.Controls.Add(this.lblChannel);
            this.groupColor.Controls.Add(this.cmbChannel);
            this.groupColor.Controls.Add(this.btnAccept);
            this.groupColor.Controls.Add(this.lblSize);
            this.groupColor.Controls.Add(this.lblN);
            this.groupColor.Enabled = false;
            this.groupColor.Location = new System.Drawing.Point(41, 28);
            this.groupColor.Name = "groupColor";
            this.groupColor.Size = new System.Drawing.Size(196, 116);
            this.groupColor.TabIndex = 12;
            this.groupColor.TabStop = false;
            this.groupColor.Text = "Параметры изображения";
            // 
            // rbtnPhase
            // 
            this.rbtnPhase.AutoSize = true;
            this.rbtnPhase.Enabled = false;
            this.rbtnPhase.Location = new System.Drawing.Point(132, 90);
            this.rbtnPhase.Name = "rbtnPhase";
            this.rbtnPhase.Size = new System.Drawing.Size(54, 17);
            this.rbtnPhase.TabIndex = 9;
            this.rbtnPhase.TabStop = true;
            this.rbtnPhase.Text = "Фаза";
            this.rbtnPhase.UseVisualStyleBackColor = true;
            this.rbtnPhase.Click += new System.EventHandler(this.rbtnPhase_CheckedChanged);
            // 
            // rbtnAmp
            // 
            this.rbtnAmp.AutoSize = true;
            this.rbtnAmp.Checked = true;
            this.rbtnAmp.Enabled = false;
            this.rbtnAmp.Location = new System.Drawing.Point(6, 90);
            this.rbtnAmp.Name = "rbtnAmp";
            this.rbtnAmp.Size = new System.Drawing.Size(80, 17);
            this.rbtnAmp.TabIndex = 8;
            this.rbtnAmp.TabStop = true;
            this.rbtnAmp.Text = "Амплитуда";
            this.rbtnAmp.UseVisualStyleBackColor = true;
            this.rbtnAmp.Click += new System.EventHandler(this.rbtnAmp_CheckedChanged);
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(36, 39);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(41, 13);
            this.lblChannel.TabIndex = 7;
            this.lblChannel.Text = "Канал:";
            // 
            // cmbChannel
            // 
            this.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannel.FormattingEnabled = true;
            this.cmbChannel.Items.AddRange(new object[] {
            "Original",
            "R",
            "G",
            "B",
            "Gray"});
            this.cmbChannel.Location = new System.Drawing.Point(83, 36);
            this.cmbChannel.Name = "cmbChannel";
            this.cmbChannel.Size = new System.Drawing.Size(103, 21);
            this.cmbChannel.TabIndex = 6;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(6, 61);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(180, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Применить";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblSize
            // 
            this.lblSize.Location = new System.Drawing.Point(83, 20);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(103, 13);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "NxN";
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(28, 20);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(49, 13);
            this.lblN.TabIndex = 0;
            this.lblN.Text = "Размер:";
            // 
            // groupParamHolo
            // 
            this.groupParamHolo.Controls.Add(this.lblDist);
            this.groupParamHolo.Controls.Add(this.txbDist);
            this.groupParamHolo.Controls.Add(this.lblDx);
            this.groupParamHolo.Controls.Add(this.txbDx);
            this.groupParamHolo.Controls.Add(this.lblWave);
            this.groupParamHolo.Controls.Add(this.txbWave);
            this.groupParamHolo.Enabled = false;
            this.groupParamHolo.Location = new System.Drawing.Point(41, 150);
            this.groupParamHolo.Name = "groupParamHolo";
            this.groupParamHolo.Size = new System.Drawing.Size(196, 101);
            this.groupParamHolo.TabIndex = 10;
            this.groupParamHolo.TabStop = false;
            this.groupParamHolo.Text = "Параметры голограммы";
            // 
            // lblDist
            // 
            this.lblDist.AutoSize = true;
            this.lblDist.Location = new System.Drawing.Point(42, 74);
            this.lblDist.Name = "lblDist";
            this.lblDist.Size = new System.Drawing.Size(38, 13);
            this.lblDist.TabIndex = 5;
            this.lblDist.Text = "d, mm:";
            // 
            // txbDist
            // 
            this.txbDist.Location = new System.Drawing.Point(86, 71);
            this.txbDist.Name = "txbDist";
            this.txbDist.Size = new System.Drawing.Size(100, 20);
            this.txbDist.TabIndex = 4;
            this.txbDist.Text = "47";
            this.txbDist.TextChanged += new System.EventHandler(this.txbWave_TextChanged);
            // 
            // lblDx
            // 
            this.lblDx.AutoSize = true;
            this.lblDx.Location = new System.Drawing.Point(37, 48);
            this.lblDx.Name = "lblDx";
            this.lblDx.Size = new System.Drawing.Size(43, 13);
            this.lblDx.TabIndex = 3;
            this.lblDx.Text = "dx, mm:";
            // 
            // txbDx
            // 
            this.txbDx.Location = new System.Drawing.Point(86, 45);
            this.txbDx.Name = "txbDx";
            this.txbDx.Size = new System.Drawing.Size(100, 20);
            this.txbDx.TabIndex = 2;
            this.txbDx.Text = "0.007";
            this.txbDx.TextChanged += new System.EventHandler(this.txbWave_TextChanged);
            // 
            // lblWave
            // 
            this.lblWave.AutoSize = true;
            this.lblWave.Location = new System.Drawing.Point(21, 22);
            this.lblWave.Name = "lblWave";
            this.lblWave.Size = new System.Drawing.Size(59, 13);
            this.lblWave.TabIndex = 1;
            this.lblWave.Text = "Wave, nm:";
            // 
            // txbWave
            // 
            this.txbWave.Location = new System.Drawing.Point(86, 19);
            this.txbWave.Name = "txbWave";
            this.txbWave.Size = new System.Drawing.Size(100, 20);
            this.txbWave.TabIndex = 0;
            this.txbWave.Text = "532";
            this.txbWave.TextChanged += new System.EventHandler(this.txbWave_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(682, 620);
            this.panel2.TabIndex = 12;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabZones);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabVideo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(682, 620);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.picSourceImage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(674, 594);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Исходное";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // picSourceImage
            // 
            this.picSourceImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSourceImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSourceImage.Location = new System.Drawing.Point(3, 3);
            this.picSourceImage.Name = "picSourceImage";
            this.picSourceImage.Size = new System.Drawing.Size(668, 588);
            this.picSourceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSourceImage.TabIndex = 0;
            this.picSourceImage.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.picGenHolo);
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(674, 594);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Сгенерированное";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // picGenHolo
            // 
            this.picGenHolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGenHolo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGenHolo.Location = new System.Drawing.Point(3, 3);
            this.picGenHolo.Name = "picGenHolo";
            this.picGenHolo.Size = new System.Drawing.Size(668, 588);
            this.picGenHolo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGenHolo.TabIndex = 1;
            this.picGenHolo.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.picReconHolo);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(674, 594);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = "Reconstruction";
            this.tabPage3.Text = "Восстановленное";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // picReconHolo
            // 
            this.picReconHolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picReconHolo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picReconHolo.Location = new System.Drawing.Point(3, 3);
            this.picReconHolo.Name = "picReconHolo";
            this.picReconHolo.Size = new System.Drawing.Size(668, 588);
            this.picReconHolo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picReconHolo.TabIndex = 2;
            this.picReconHolo.TabStop = false;
            this.picReconHolo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picReconHolo_MouseClick);
            this.picReconHolo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picReconHolo_MouseDown);
            this.picReconHolo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picReconHolo_MouseMove);
            this.picReconHolo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picReconHolo_MouseUp);
            // 
            // tabZones
            // 
            this.tabZones.Controls.Add(this.groupAnalyzeZones);
            this.tabZones.Location = new System.Drawing.Point(4, 22);
            this.tabZones.Name = "tabZones";
            this.tabZones.Padding = new System.Windows.Forms.Padding(3);
            this.tabZones.Size = new System.Drawing.Size(674, 594);
            this.tabZones.TabIndex = 3;
            this.tabZones.Text = "Анализ областей";
            this.tabZones.UseVisualStyleBackColor = true;
            // 
            // groupAnalyzeZones
            // 
            this.groupAnalyzeZones.Controls.Add(this.splitContainer1);
            this.groupAnalyzeZones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupAnalyzeZones.Location = new System.Drawing.Point(3, 3);
            this.groupAnalyzeZones.Name = "groupAnalyzeZones";
            this.groupAnalyzeZones.Size = new System.Drawing.Size(668, 588);
            this.groupAnalyzeZones.TabIndex = 1;
            this.groupAnalyzeZones.TabStop = false;
            this.groupAnalyzeZones.Text = "Анализ зон";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.picAnalyze);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart1);
            this.splitContainer1.Size = new System.Drawing.Size(662, 569);
            this.splitContainer1.SplitterDistance = 406;
            this.splitContainer1.TabIndex = 19;
            // 
            // picAnalyze
            // 
            this.picAnalyze.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnalyze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picAnalyze.Location = new System.Drawing.Point(0, 0);
            this.picAnalyze.Name = "picAnalyze";
            this.picAnalyze.Size = new System.Drawing.Size(662, 406);
            this.picAnalyze.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnalyze.TabIndex = 3;
            this.picAnalyze.TabStop = false;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.Name = "Area";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(662, 159);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel4);
            this.tabPage4.Controls.Add(this.panel3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(674, 594);
            this.tabPage4.TabIndex = 5;
            this.tabPage4.Text = "Расчеты";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.picScale);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(231, 588);
            this.panel4.TabIndex = 5;
            // 
            // picScale
            // 
            this.picScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picScale.Dock = System.Windows.Forms.DockStyle.Top;
            this.picScale.Location = new System.Drawing.Point(0, 0);
            this.picScale.Name = "picScale";
            this.picScale.Size = new System.Drawing.Size(231, 209);
            this.picScale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picScale.TabIndex = 1;
            this.picScale.TabStop = false;
            this.picScale.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picScale_MouseClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.picScale2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(234, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(437, 588);
            this.panel3.TabIndex = 4;
            // 
            // picScale2
            // 
            this.picScale2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picScale2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picScale2.Location = new System.Drawing.Point(0, 0);
            this.picScale2.Name = "picScale2";
            this.picScale2.Size = new System.Drawing.Size(437, 588);
            this.picScale2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picScale2.TabIndex = 1;
            this.picScale2.TabStop = false;
            this.picScale2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picScale2_MouseClick);
            // 
            // tabVideo
            // 
            this.tabVideo.Controls.Add(this.picVideo);
            this.tabVideo.Location = new System.Drawing.Point(4, 22);
            this.tabVideo.Name = "tabVideo";
            this.tabVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabVideo.Size = new System.Drawing.Size(674, 594);
            this.tabVideo.TabIndex = 4;
            this.tabVideo.Text = "Изображение с камеры";
            this.tabVideo.UseVisualStyleBackColor = true;
            // 
            // picVideo
            // 
            this.picVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picVideo.Location = new System.Drawing.Point(3, 3);
            this.picVideo.Name = "picVideo";
            this.picVideo.Size = new System.Drawing.Size(668, 588);
            this.picVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVideo.TabIndex = 0;
            this.picVideo.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 669);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная форма: Метод свертки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupZones.ResumeLayout(false);
            this.groupParamProcess.ResumeLayout(false);
            this.groupParamProcess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStep)).EndInit();
            this.groupColor.ResumeLayout(false);
            this.groupColor.PerformLayout();
            this.groupParamHolo.ResumeLayout(false);
            this.groupParamHolo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSourceImage)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGenHolo)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picReconHolo)).EndInit();
            this.tabZones.ResumeLayout(false);
            this.groupAnalyzeZones.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnalyze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picScale)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picScale2)).EndInit();
            this.tabVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnFile;
        private System.Windows.Forms.ToolStripMenuItem btnOpen;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbWave;
        private System.Windows.Forms.Label lblWave;
        private System.Windows.Forms.TextBox txbDx;
        private System.Windows.Forms.Label lblDx;
        private System.Windows.Forms.TextBox txbDist;
        private System.Windows.Forms.Label lblDist;
        private System.Windows.Forms.GroupBox groupParamHolo;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.RadioButton rbtnAmp;
        private System.Windows.Forms.RadioButton rbtnPhase;
        private System.Windows.Forms.GroupBox groupColor;
        private System.Windows.Forms.TextBox txbSizeStep;
        private System.Windows.Forms.Label lblSizeStep;
        private System.Windows.Forms.Label lblNumStep;
        private System.Windows.Forms.NumericUpDown numStep;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblCurrentDistance;
        private System.Windows.Forms.GroupBox groupParamProcess;
        private System.Windows.Forms.Button btnGenHolo;
        private System.Windows.Forms.Button btnReconHolo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabZones;
        private System.Windows.Forms.PictureBox picReconHolo;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox picGenHolo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupZones;
        private System.Windows.Forms.GroupBox groupAnalyzeZones;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.PictureBox picAnalyze;
        private System.Windows.Forms.ListBox listZones;
        private System.Windows.Forms.Button btnCalcDifference;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCircle;
        private System.Windows.Forms.ToolStripButton btnSelection;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tabVideo;
        private System.Windows.Forms.ComboBox cmbMeasure;
        private System.Windows.Forms.ToolStripComboBox cmbCam;
        private System.Windows.Forms.ToolStripMenuItem btnVideo;
        private System.Windows.Forms.PictureBox picVideo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox picScale2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picScale;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox picSourceImage;
        private System.Windows.Forms.TabPage tabPage1;
    }
}

