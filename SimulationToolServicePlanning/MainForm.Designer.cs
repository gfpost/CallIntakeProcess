namespace Simulator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miReadConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.miReadEngineers = new System.Windows.Forms.ToolStripMenuItem();
            this.miReadTasks = new System.Windows.Forms.ToolStripMenuItem();
            this.miReadStrategyParameters = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.miExecuteStrategies = new System.Windows.Forms.ToolStripMenuItem();
            this.miSavePlanning = new System.Windows.Forms.ToolStripMenuItem();
            this.miChart = new System.Windows.Forms.ToolStripMenuItem();
            this.miData = new System.Windows.Forms.ToolStripMenuItem();
            this.miConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.gbModel = new System.Windows.Forms.GroupBox();
            this.tbEmployees = new System.Windows.Forms.TextBox();
            this.tbTasks = new System.Windows.Forms.TextBox();
            this.lblEmployees = new System.Windows.Forms.Label();
            this.lblTasks = new System.Windows.Forms.Label();
            this.gridShifts = new System.Windows.Forms.DataGridView();
            this.gbSimulation = new System.Windows.Forms.GroupBox();
            this.tbBlocktimeDuration = new System.Windows.Forms.TextBox();
            this.lblBlocktimeDuration = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TextBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.tbRandomPercentage = new System.Windows.Forms.TextBox();
            this.lblRandomPercentage = new System.Windows.Forms.Label();
            this.barProcessingDay = new System.Windows.Forms.ProgressBar();
            this.cbbStrategy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.tbNumberOfDays = new System.Windows.Forms.TextBox();
            this.lblNumberOfDays = new System.Windows.Forms.Label();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.tbFiveOrMoreLate = new System.Windows.Forms.TextBox();
            this.tbFourLate = new System.Windows.Forms.TextBox();
            this.tbThreeLate = new System.Windows.Forms.TextBox();
            this.tbTwoLate = new System.Windows.Forms.TextBox();
            this.tbOneLate = new System.Windows.Forms.TextBox();
            this.lblFiveOrMoreDaysTooLate = new System.Windows.Forms.Label();
            this.lblFourDaysTooLate = new System.Windows.Forms.Label();
            this.lblThreeDaysTooLate = new System.Windows.Forms.Label();
            this.lblTwoDaysTooLate = new System.Windows.Forms.Label();
            this.lblOneDayTooLate = new System.Windows.Forms.Label();
            this.tbPlanned = new System.Windows.Forms.TextBox();
            this.lblPlanned = new System.Windows.Forms.Label();
            this.tbTravelTime = new System.Windows.Forms.TextBox();
            this.lblTravelTime = new System.Windows.Forms.Label();
            this.tbNotPlanned = new System.Windows.Forms.TextBox();
            this.lblNotPlanned = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbDisplay = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tbDisplayNumberOfDays = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mainMenu.SuspendLayout();
            this.gbModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShifts)).BeginInit();
            this.gbSimulation.SuspendLayout();
            this.gbResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.gbDisplay.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miChart,
            this.miData});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1306, 24);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "mainMenu";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miReadConfiguration,
            this.miReadEngineers,
            this.miReadTasks,
            this.miReadStrategyParameters,
            this.menuSeparator,
            this.miExecuteStrategies,
            this.miSavePlanning});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "File";
            // 
            // miReadConfiguration
            // 
            this.miReadConfiguration.Name = "miReadConfiguration";
            this.miReadConfiguration.Size = new System.Drawing.Size(305, 22);
            this.miReadConfiguration.Text = "Load configuration ...";
            this.miReadConfiguration.Click += new System.EventHandler(this.ReadConfiguration_Click);
            // 
            // miReadEngineers
            // 
            this.miReadEngineers.Name = "miReadEngineers";
            this.miReadEngineers.Size = new System.Drawing.Size(305, 22);
            this.miReadEngineers.Text = "Load engineers ...";
            this.miReadEngineers.Click += new System.EventHandler(this.readEmployees_Click);
            // 
            // miReadTasks
            // 
            this.miReadTasks.Name = "miReadTasks";
            this.miReadTasks.Size = new System.Drawing.Size(305, 22);
            this.miReadTasks.Text = "Load tasks ...";
            this.miReadTasks.Click += new System.EventHandler(this.readTasks_Click);
            // 
            // miReadStrategyParameters
            // 
            this.miReadStrategyParameters.Name = "miReadStrategyParameters";
            this.miReadStrategyParameters.Size = new System.Drawing.Size(305, 22);
            this.miReadStrategyParameters.Text = "Load strategy parameters ...";
            this.miReadStrategyParameters.Click += new System.EventHandler(this.ReadStrategieParameters_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(302, 6);
            // 
            // miExecuteStrategies
            // 
            this.miExecuteStrategies.Name = "miExecuteStrategies";
            this.miExecuteStrategies.Size = new System.Drawing.Size(305, 22);
            this.miExecuteStrategies.Text = "Execute directory with strategies and tasks...";
            this.miExecuteStrategies.Click += new System.EventHandler(this.ExecuteStrategies_Click);
            // 
            // miSavePlanning
            // 
            this.miSavePlanning.Name = "miSavePlanning";
            this.miSavePlanning.Size = new System.Drawing.Size(305, 22);
            this.miSavePlanning.Text = "Save planning to file ...";
            this.miSavePlanning.Click += new System.EventHandler(this.SavePlanning_Click);
            // 
            // miChart
            // 
            this.miChart.Name = "miChart";
            this.miChart.Size = new System.Drawing.Size(72, 20);
            this.miChart.Text = "Show grid";
            this.miChart.Click += new System.EventHandler(this.graph_Click);
            // 
            // miData
            // 
            this.miData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConfiguration});
            this.miData.Name = "miData";
            this.miData.Size = new System.Drawing.Size(43, 20);
            this.miData.Text = "Data";
            // 
            // miConfiguration
            // 
            this.miConfiguration.Name = "miConfiguration";
            this.miConfiguration.Size = new System.Drawing.Size(209, 22);
            this.miConfiguration.Text = "Create data configuration";
            this.miConfiguration.Click += new System.EventHandler(this.OpenDataConfiguration_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "files|*.txt";
            // 
            // gbModel
            // 
            this.gbModel.Controls.Add(this.tbEmployees);
            this.gbModel.Controls.Add(this.tbTasks);
            this.gbModel.Controls.Add(this.lblEmployees);
            this.gbModel.Controls.Add(this.lblTasks);
            this.gbModel.Location = new System.Drawing.Point(12, 27);
            this.gbModel.Name = "gbModel";
            this.gbModel.Size = new System.Drawing.Size(243, 94);
            this.gbModel.TabIndex = 3;
            this.gbModel.TabStop = false;
            this.gbModel.Text = "Model";
            // 
            // tbEmployees
            // 
            this.tbEmployees.Enabled = false;
            this.tbEmployees.Location = new System.Drawing.Point(186, 61);
            this.tbEmployees.Name = "tbEmployees";
            this.tbEmployees.Size = new System.Drawing.Size(51, 20);
            this.tbEmployees.TabIndex = 5;
            this.tbEmployees.Text = "0";
            this.tbEmployees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbTasks
            // 
            this.tbTasks.Enabled = false;
            this.tbTasks.Location = new System.Drawing.Point(186, 33);
            this.tbTasks.Name = "tbTasks";
            this.tbTasks.Size = new System.Drawing.Size(51, 20);
            this.tbTasks.TabIndex = 4;
            this.tbTasks.Text = "0";
            this.tbTasks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEmployees
            // 
            this.lblEmployees.AutoSize = true;
            this.lblEmployees.Location = new System.Drawing.Point(18, 64);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(108, 13);
            this.lblEmployees.TabIndex = 1;
            this.lblEmployees.Text = "Number of engineers:";
            // 
            // lblTasks
            // 
            this.lblTasks.AutoSize = true;
            this.lblTasks.Location = new System.Drawing.Point(18, 33);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(90, 13);
            this.lblTasks.TabIndex = 0;
            this.lblTasks.Text = "Number of tasks: ";
            // 
            // gridShifts
            // 
            this.gridShifts.AllowUserToAddRows = false;
            this.gridShifts.AllowUserToDeleteRows = false;
            this.gridShifts.AllowUserToOrderColumns = true;
            this.gridShifts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridShifts.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridShifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridShifts.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.gridShifts.Location = new System.Drawing.Point(277, 27);
            this.gridShifts.Name = "gridShifts";
            this.gridShifts.RowHeadersWidth = 10;
            this.gridShifts.Size = new System.Drawing.Size(1006, 710);
            this.gridShifts.TabIndex = 4;
            // 
            // gbSimulation
            // 
            this.gbSimulation.Controls.Add(this.tbBlocktimeDuration);
            this.gbSimulation.Controls.Add(this.lblBlocktimeDuration);
            this.gbSimulation.Controls.Add(this.tbSpeed);
            this.gbSimulation.Controls.Add(this.lblSpeed);
            this.gbSimulation.Controls.Add(this.tbRandomPercentage);
            this.gbSimulation.Controls.Add(this.lblRandomPercentage);
            this.gbSimulation.Controls.Add(this.barProcessingDay);
            this.gbSimulation.Controls.Add(this.cbbStrategy);
            this.gbSimulation.Controls.Add(this.label1);
            this.gbSimulation.Controls.Add(this.btnRun);
            this.gbSimulation.Controls.Add(this.tbNumberOfDays);
            this.gbSimulation.Controls.Add(this.lblNumberOfDays);
            this.gbSimulation.Location = new System.Drawing.Point(12, 127);
            this.gbSimulation.Name = "gbSimulation";
            this.gbSimulation.Size = new System.Drawing.Size(243, 259);
            this.gbSimulation.TabIndex = 5;
            this.gbSimulation.TabStop = false;
            this.gbSimulation.Text = "Simulation";
            // 
            // tbBlocktimeDuration
            // 
            this.tbBlocktimeDuration.Enabled = false;
            this.tbBlocktimeDuration.Location = new System.Drawing.Point(212, 148);
            this.tbBlocktimeDuration.Name = "tbBlocktimeDuration";
            this.tbBlocktimeDuration.Size = new System.Drawing.Size(25, 20);
            this.tbBlocktimeDuration.TabIndex = 17;
            this.tbBlocktimeDuration.Text = "120";
            this.tbBlocktimeDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBlocktimeDuration
            // 
            this.lblBlocktimeDuration.AutoSize = true;
            this.lblBlocktimeDuration.Location = new System.Drawing.Point(14, 151);
            this.lblBlocktimeDuration.Name = "lblBlocktimeDuration";
            this.lblBlocktimeDuration.Size = new System.Drawing.Size(106, 13);
            this.lblBlocktimeDuration.TabIndex = 16;
            this.lblBlocktimeDuration.Text = "Block duration (min): ";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Enabled = false;
            this.tbSpeed.Location = new System.Drawing.Point(212, 117);
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(25, 20);
            this.tbSpeed.TabIndex = 15;
            this.tbSpeed.Text = "60";
            this.tbSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(14, 120);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(78, 13);
            this.lblSpeed.TabIndex = 14;
            this.lblSpeed.Text = "Speed (km/h): ";
            // 
            // tbRandomPercentage
            // 
            this.tbRandomPercentage.Location = new System.Drawing.Point(212, 54);
            this.tbRandomPercentage.Name = "tbRandomPercentage";
            this.tbRandomPercentage.Size = new System.Drawing.Size(25, 20);
            this.tbRandomPercentage.TabIndex = 13;
            this.tbRandomPercentage.Text = "0";
            this.tbRandomPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRandomPercentage
            // 
            this.lblRandomPercentage.AutoSize = true;
            this.lblRandomPercentage.Location = new System.Drawing.Point(14, 57);
            this.lblRandomPercentage.Name = "lblRandomPercentage";
            this.lblRandomPercentage.Size = new System.Drawing.Size(112, 13);
            this.lblRandomPercentage.TabIndex = 10;
            this.lblRandomPercentage.Text = "Ramdom percentage: ";
            // 
            // barProcessingDay
            // 
            this.barProcessingDay.Location = new System.Drawing.Point(17, 230);
            this.barProcessingDay.Name = "barProcessingDay";
            this.barProcessingDay.Size = new System.Drawing.Size(220, 23);
            this.barProcessingDay.TabIndex = 9;
            // 
            // cbbStrategy
            // 
            this.cbbStrategy.FormattingEnabled = true;
            this.cbbStrategy.Location = new System.Drawing.Point(75, 23);
            this.cbbStrategy.Name = "cbbStrategy";
            this.cbbStrategy.Size = new System.Drawing.Size(162, 21);
            this.cbbStrategy.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Strategy: ";
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(33, 187);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(192, 27);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.RunSimulation_Click);
            // 
            // tbNumberOfDays
            // 
            this.tbNumberOfDays.Location = new System.Drawing.Point(202, 84);
            this.tbNumberOfDays.Name = "tbNumberOfDays";
            this.tbNumberOfDays.Size = new System.Drawing.Size(35, 20);
            this.tbNumberOfDays.TabIndex = 5;
            this.tbNumberOfDays.Text = "270";
            this.tbNumberOfDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNumberOfDays
            // 
            this.lblNumberOfDays.AutoSize = true;
            this.lblNumberOfDays.Location = new System.Drawing.Point(14, 87);
            this.lblNumberOfDays.Name = "lblNumberOfDays";
            this.lblNumberOfDays.Size = new System.Drawing.Size(87, 13);
            this.lblNumberOfDays.TabIndex = 1;
            this.lblNumberOfDays.Text = "Number of days: ";
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.tbFiveOrMoreLate);
            this.gbResult.Controls.Add(this.tbFourLate);
            this.gbResult.Controls.Add(this.tbThreeLate);
            this.gbResult.Controls.Add(this.tbTwoLate);
            this.gbResult.Controls.Add(this.tbOneLate);
            this.gbResult.Controls.Add(this.lblFiveOrMoreDaysTooLate);
            this.gbResult.Controls.Add(this.lblFourDaysTooLate);
            this.gbResult.Controls.Add(this.lblThreeDaysTooLate);
            this.gbResult.Controls.Add(this.lblTwoDaysTooLate);
            this.gbResult.Controls.Add(this.lblOneDayTooLate);
            this.gbResult.Controls.Add(this.tbPlanned);
            this.gbResult.Controls.Add(this.lblPlanned);
            this.gbResult.Controls.Add(this.tbTravelTime);
            this.gbResult.Controls.Add(this.lblTravelTime);
            this.gbResult.Controls.Add(this.tbNotPlanned);
            this.gbResult.Controls.Add(this.lblNotPlanned);
            this.gbResult.Location = new System.Drawing.Point(12, 483);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(243, 260);
            this.gbResult.TabIndex = 6;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "Result";
            // 
            // tbFiveOrMoreLate
            // 
            this.tbFiveOrMoreLate.Enabled = false;
            this.tbFiveOrMoreLate.Location = new System.Drawing.Point(184, 224);
            this.tbFiveOrMoreLate.Name = "tbFiveOrMoreLate";
            this.tbFiveOrMoreLate.Size = new System.Drawing.Size(51, 20);
            this.tbFiveOrMoreLate.TabIndex = 20;
            this.tbFiveOrMoreLate.Text = "0";
            this.tbFiveOrMoreLate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbFourLate
            // 
            this.tbFourLate.Enabled = false;
            this.tbFourLate.Location = new System.Drawing.Point(184, 195);
            this.tbFourLate.Name = "tbFourLate";
            this.tbFourLate.Size = new System.Drawing.Size(51, 20);
            this.tbFourLate.TabIndex = 19;
            this.tbFourLate.Text = "0";
            this.tbFourLate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbThreeLate
            // 
            this.tbThreeLate.Enabled = false;
            this.tbThreeLate.Location = new System.Drawing.Point(184, 162);
            this.tbThreeLate.Name = "tbThreeLate";
            this.tbThreeLate.Size = new System.Drawing.Size(51, 20);
            this.tbThreeLate.TabIndex = 18;
            this.tbThreeLate.Text = "0";
            this.tbThreeLate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbTwoLate
            // 
            this.tbTwoLate.Enabled = false;
            this.tbTwoLate.Location = new System.Drawing.Point(184, 130);
            this.tbTwoLate.Name = "tbTwoLate";
            this.tbTwoLate.Size = new System.Drawing.Size(51, 20);
            this.tbTwoLate.TabIndex = 17;
            this.tbTwoLate.Text = "0";
            this.tbTwoLate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbOneLate
            // 
            this.tbOneLate.Enabled = false;
            this.tbOneLate.Location = new System.Drawing.Point(184, 100);
            this.tbOneLate.Name = "tbOneLate";
            this.tbOneLate.Size = new System.Drawing.Size(51, 20);
            this.tbOneLate.TabIndex = 16;
            this.tbOneLate.Text = "0";
            this.tbOneLate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblFiveOrMoreDaysTooLate
            // 
            this.lblFiveOrMoreDaysTooLate.AutoSize = true;
            this.lblFiveOrMoreDaysTooLate.Location = new System.Drawing.Point(14, 227);
            this.lblFiveOrMoreDaysTooLate.Name = "lblFiveOrMoreDaysTooLate";
            this.lblFiveOrMoreDaysTooLate.Size = new System.Drawing.Size(102, 13);
            this.lblFiveOrMoreDaysTooLate.TabIndex = 15;
            this.lblFiveOrMoreDaysTooLate.Text = "5 or more days late: ";
            // 
            // lblFourDaysTooLate
            // 
            this.lblFourDaysTooLate.AutoSize = true;
            this.lblFourDaysTooLate.Location = new System.Drawing.Point(14, 198);
            this.lblFourDaysTooLate.Name = "lblFourDaysTooLate";
            this.lblFourDaysTooLate.Size = new System.Drawing.Size(64, 13);
            this.lblFourDaysTooLate.TabIndex = 14;
            this.lblFourDaysTooLate.Text = "4 days late: ";
            // 
            // lblThreeDaysTooLate
            // 
            this.lblThreeDaysTooLate.AutoSize = true;
            this.lblThreeDaysTooLate.Location = new System.Drawing.Point(14, 165);
            this.lblThreeDaysTooLate.Name = "lblThreeDaysTooLate";
            this.lblThreeDaysTooLate.Size = new System.Drawing.Size(64, 13);
            this.lblThreeDaysTooLate.TabIndex = 13;
            this.lblThreeDaysTooLate.Text = "3 days late: ";
            // 
            // lblTwoDaysTooLate
            // 
            this.lblTwoDaysTooLate.AutoSize = true;
            this.lblTwoDaysTooLate.Location = new System.Drawing.Point(15, 133);
            this.lblTwoDaysTooLate.Name = "lblTwoDaysTooLate";
            this.lblTwoDaysTooLate.Size = new System.Drawing.Size(61, 13);
            this.lblTwoDaysTooLate.TabIndex = 12;
            this.lblTwoDaysTooLate.Text = "2 days late:";
            // 
            // lblOneDayTooLate
            // 
            this.lblOneDayTooLate.AutoSize = true;
            this.lblOneDayTooLate.Location = new System.Drawing.Point(15, 103);
            this.lblOneDayTooLate.Name = "lblOneDayTooLate";
            this.lblOneDayTooLate.Size = new System.Drawing.Size(56, 13);
            this.lblOneDayTooLate.TabIndex = 11;
            this.lblOneDayTooLate.Text = "1 day late:";
            // 
            // tbPlanned
            // 
            this.tbPlanned.Enabled = false;
            this.tbPlanned.Location = new System.Drawing.Point(186, 26);
            this.tbPlanned.Name = "tbPlanned";
            this.tbPlanned.Size = new System.Drawing.Size(51, 20);
            this.tbPlanned.TabIndex = 10;
            this.tbPlanned.Text = "0";
            this.tbPlanned.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPlanned
            // 
            this.lblPlanned.AutoSize = true;
            this.lblPlanned.Location = new System.Drawing.Point(14, 29);
            this.lblPlanned.Name = "lblPlanned";
            this.lblPlanned.Size = new System.Drawing.Size(91, 13);
            this.lblPlanned.TabIndex = 9;
            this.lblPlanned.Text = "Number planned: ";
            // 
            // tbTravelTime
            // 
            this.tbTravelTime.Enabled = false;
            this.tbTravelTime.Location = new System.Drawing.Point(140, 294);
            this.tbTravelTime.Name = "tbTravelTime";
            this.tbTravelTime.Size = new System.Drawing.Size(69, 20);
            this.tbTravelTime.TabIndex = 8;
            this.tbTravelTime.Text = "0";
            this.tbTravelTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTravelTime
            // 
            this.lblTravelTime.AutoSize = true;
            this.lblTravelTime.Location = new System.Drawing.Point(14, 297);
            this.lblTravelTime.Name = "lblTravelTime";
            this.lblTravelTime.Size = new System.Drawing.Size(88, 13);
            this.lblTravelTime.TabIndex = 6;
            this.lblTravelTime.Text = "Total travel time: ";
            // 
            // tbNotPlanned
            // 
            this.tbNotPlanned.Enabled = false;
            this.tbNotPlanned.Location = new System.Drawing.Point(186, 58);
            this.tbNotPlanned.Name = "tbNotPlanned";
            this.tbNotPlanned.Size = new System.Drawing.Size(51, 20);
            this.tbNotPlanned.TabIndex = 5;
            this.tbNotPlanned.Text = "0";
            this.tbNotPlanned.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNotPlanned
            // 
            this.lblNotPlanned.AutoSize = true;
            this.lblNotPlanned.Location = new System.Drawing.Point(14, 61);
            this.lblNotPlanned.Name = "lblNotPlanned";
            this.lblNotPlanned.Size = new System.Drawing.Size(109, 13);
            this.lblNotPlanned.TabIndex = 1;
            this.lblNotPlanned.Text = "Number not planned: ";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "files|*.txt";
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(277, 27);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series1.Legend = "Legend1";
            series1.Name = "task duration";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "travel time";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            series3.Legend = "Legend1";
            series3.Name = "idle time";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(1006, 710);
            this.chart.TabIndex = 7;
            this.chart.Text = "Bezetting";
            // 
            // gbDisplay
            // 
            this.gbDisplay.Controls.Add(this.label2);
            this.gbDisplay.Controls.Add(this.tbStart);
            this.gbDisplay.Controls.Add(this.btnForward);
            this.gbDisplay.Controls.Add(this.btnBack);
            this.gbDisplay.Controls.Add(this.tbDisplayNumberOfDays);
            this.gbDisplay.Controls.Add(this.label3);
            this.gbDisplay.Location = new System.Drawing.Point(12, 392);
            this.gbDisplay.Name = "gbDisplay";
            this.gbDisplay.Size = new System.Drawing.Size(243, 85);
            this.gbDisplay.TabIndex = 8;
            this.gbDisplay.TabStop = false;
            this.gbDisplay.Text = "Validation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Start:";
            // 
            // tbStart
            // 
            this.tbStart.Enabled = false;
            this.tbStart.Location = new System.Drawing.Point(143, 55);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(35, 20);
            this.tbStart.TabIndex = 11;
            this.tbStart.Text = "50";
            this.tbStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnForward
            // 
            this.btnForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForward.Location = new System.Drawing.Point(184, 53);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(25, 23);
            this.btnForward.TabIndex = 10;
            this.btnForward.Text = ">";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(112, 53);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(25, 23);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tbDisplayNumberOfDays
            // 
            this.tbDisplayNumberOfDays.Location = new System.Drawing.Point(184, 23);
            this.tbDisplayNumberOfDays.Name = "tbDisplayNumberOfDays";
            this.tbDisplayNumberOfDays.Size = new System.Drawing.Size(25, 20);
            this.tbDisplayNumberOfDays.TabIndex = 5;
            this.tbDisplayNumberOfDays.Text = "200";
            this.tbDisplayNumberOfDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDisplayNumberOfDays.Leave += new System.EventHandler(this.tbDisplayNumberOfDays_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Number of days:";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "C:\\Projects\\simulationtool\\data\\Params\\";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 749);
            this.Controls.Add(this.gbDisplay);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.gbResult);
            this.Controls.Add(this.gbSimulation);
            this.Controls.Add(this.gridShifts);
            this.Controls.Add(this.gbModel);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Simulator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.gbModel.ResumeLayout(false);
            this.gbModel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridShifts)).EndInit();
            this.gbSimulation.ResumeLayout(false);
            this.gbSimulation.PerformLayout();
            this.gbResult.ResumeLayout(false);
            this.gbResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.gbDisplay.ResumeLayout(false);
            this.gbDisplay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miReadTasks;
        private System.Windows.Forms.ToolStripMenuItem miReadEngineers;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox gbModel;
        private System.Windows.Forms.TextBox tbEmployees;
        private System.Windows.Forms.TextBox tbTasks;
        private System.Windows.Forms.Label lblEmployees;
        private System.Windows.Forms.Label lblTasks;
        private System.Windows.Forms.DataGridView gridShifts;
        private System.Windows.Forms.GroupBox gbSimulation;
        private System.Windows.Forms.TextBox tbNumberOfDays;
        private System.Windows.Forms.Label lblNumberOfDays;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.TextBox tbTravelTime;
        private System.Windows.Forms.Label lblTravelTime;
        private System.Windows.Forms.TextBox tbNotPlanned;
        private System.Windows.Forms.Label lblNotPlanned;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private System.Windows.Forms.Label lblPlanned;
        private System.Windows.Forms.TextBox tbPlanned;
        private System.Windows.Forms.ComboBox cbbStrategy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFiveOrMoreLate;
        private System.Windows.Forms.TextBox tbFourLate;
        private System.Windows.Forms.TextBox tbThreeLate;
        private System.Windows.Forms.TextBox tbTwoLate;
        private System.Windows.Forms.TextBox tbOneLate;
        private System.Windows.Forms.Label lblFiveOrMoreDaysTooLate;
        private System.Windows.Forms.Label lblFourDaysTooLate;
        private System.Windows.Forms.Label lblThreeDaysTooLate;
        private System.Windows.Forms.Label lblTwoDaysTooLate;
        private System.Windows.Forms.Label lblOneDayTooLate;
        private System.Windows.Forms.ToolStripMenuItem miChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.GroupBox gbDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox tbDisplayNumberOfDays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem miSavePlanning;
        private System.Windows.Forms.ProgressBar barProcessingDay;
        private System.Windows.Forms.ToolStripMenuItem miReadStrategyParameters;
        private System.Windows.Forms.ToolStripMenuItem miExecuteStrategies;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem miData;
        private System.Windows.Forms.ToolStripMenuItem miConfiguration;
        private System.Windows.Forms.ToolStripMenuItem miReadConfiguration;
        private System.Windows.Forms.TextBox tbRandomPercentage;
        private System.Windows.Forms.Label lblRandomPercentage;
        private System.Windows.Forms.TextBox tbBlocktimeDuration;
        private System.Windows.Forms.Label lblBlocktimeDuration;
        private System.Windows.Forms.TextBox tbSpeed;
        private System.Windows.Forms.Label lblSpeed;
    }
}

