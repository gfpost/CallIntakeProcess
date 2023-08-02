namespace Simulator
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.gbGeometry = new System.Windows.Forms.GroupBox();
            this.tbNofRegionsHeight = new System.Windows.Forms.TextBox();
            this.lblNofRegionsHeight = new System.Windows.Forms.Label();
            this.tbNofRegionsWidth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHeight = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.tbWidth = new System.Windows.Forms.TextBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.gbTasks = new System.Windows.Forms.GroupBox();
            this.tbMinDeadline = new System.Windows.Forms.TextBox();
            this.tbMaxDeadline = new System.Windows.Forms.TextBox();
            this.lblMaxDeadline = new System.Windows.Forms.Label();
            this.lblMinDeadline = new System.Windows.Forms.Label();
            this.tbAvgDeadline = new System.Windows.Forms.TextBox();
            this.lblAverageDeadline = new System.Windows.Forms.Label();
            this.tbMaxTaskDuration = new System.Windows.Forms.TextBox();
            this.lblMaxTaskDuration = new System.Windows.Forms.Label();
            this.tbMinNofTasks = new System.Windows.Forms.TextBox();
            this.tbMaxNofTasks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMaxNofTasks = new System.Windows.Forms.Label();
            this.tbAvgNofTasks = new System.Windows.Forms.TextBox();
            this.lblAverageNofTasks = new System.Windows.Forms.Label();
            this.tbMinTaskDuration = new System.Windows.Forms.TextBox();
            this.lblMinTaskDuration = new System.Windows.Forms.Label();
            this.tbAvgTaskDuration = new System.Windows.Forms.TextBox();
            this.lblAverageTaskDuration = new System.Windows.Forms.Label();
            this.tbNofDays = new System.Windows.Forms.TextBox();
            this.gbSkills = new System.Windows.Forms.GroupBox();
            this.lblMaxPercentageSkill = new System.Windows.Forms.Label();
            this.tbNofSkills = new System.Windows.Forms.TextBox();
            this.lblNofSkills = new System.Windows.Forms.Label();
            this.tbMaxPercentageSkill = new System.Windows.Forms.TextBox();
            this.tbMinPercentageSkill = new System.Windows.Forms.TextBox();
            this.lblMinPercentageSkill = new System.Windows.Forms.Label();
            this.gbSimulation = new System.Windows.Forms.GroupBox();
            this.tbRandomAssignment = new System.Windows.Forms.TextBox();
            this.lblPercentagePreset = new System.Windows.Forms.Label();
            this.tbBlocktimeDuration = new System.Windows.Forms.TextBox();
            this.lblBlocktimeDuration = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TextBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblNofDays = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbShiftDuration = new System.Windows.Forms.TextBox();
            this.lblShiftDuration = new System.Windows.Forms.Label();
            this.tbAvgNofSkills = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbNofEmployees = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dialFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.gbGenerateData = new System.Windows.Forms.GroupBox();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.gbGeometry.SuspendLayout();
            this.gbTasks.SuspendLayout();
            this.gbSkills.SuspendLayout();
            this.gbSimulation.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbGenerateData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGeometry
            // 
            this.gbGeometry.Controls.Add(this.tbNofRegionsHeight);
            this.gbGeometry.Controls.Add(this.lblNofRegionsHeight);
            this.gbGeometry.Controls.Add(this.tbNofRegionsWidth);
            this.gbGeometry.Controls.Add(this.label1);
            this.gbGeometry.Controls.Add(this.tbHeight);
            this.gbGeometry.Controls.Add(this.lblHeight);
            this.gbGeometry.Controls.Add(this.tbWidth);
            this.gbGeometry.Controls.Add(this.lblWidth);
            this.gbGeometry.Location = new System.Drawing.Point(733, 12);
            this.gbGeometry.Name = "gbGeometry";
            this.gbGeometry.Size = new System.Drawing.Size(221, 159);
            this.gbGeometry.TabIndex = 0;
            this.gbGeometry.TabStop = false;
            this.gbGeometry.Text = "Geometry";
            // 
            // tbNofRegionsHeight
            // 
            this.tbNofRegionsHeight.Location = new System.Drawing.Point(174, 122);
            this.tbNofRegionsHeight.Name = "tbNofRegionsHeight";
            this.tbNofRegionsHeight.Size = new System.Drawing.Size(32, 20);
            this.tbNofRegionsHeight.TabIndex = 7;
            this.tbNofRegionsHeight.Text = "3";
            this.tbNofRegionsHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNofRegionsHeight
            // 
            this.lblNofRegionsHeight.AutoSize = true;
            this.lblNofRegionsHeight.Location = new System.Drawing.Point(16, 125);
            this.lblNofRegionsHeight.Name = "lblNofRegionsHeight";
            this.lblNofRegionsHeight.Size = new System.Drawing.Size(139, 13);
            this.lblNofRegionsHeight.TabIndex = 6;
            this.lblNofRegionsHeight.Text = "Number of regions in height:";
            // 
            // tbNofRegionsWidth
            // 
            this.tbNofRegionsWidth.Location = new System.Drawing.Point(174, 92);
            this.tbNofRegionsWidth.Name = "tbNofRegionsWidth";
            this.tbNofRegionsWidth.Size = new System.Drawing.Size(32, 20);
            this.tbNofRegionsWidth.TabIndex = 5;
            this.tbNofRegionsWidth.Text = "3";
            this.tbNofRegionsWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of regions in width:";
            // 
            // tbHeight
            // 
            this.tbHeight.Location = new System.Drawing.Point(174, 53);
            this.tbHeight.Name = "tbHeight";
            this.tbHeight.Size = new System.Drawing.Size(32, 20);
            this.tbHeight.TabIndex = 3;
            this.tbHeight.Text = "100";
            this.tbHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(16, 56);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(100, 13);
            this.lblHeight.TabIndex = 2;
            this.lblHeight.Text = "Height of area (km):";
            // 
            // tbWidth
            // 
            this.tbWidth.Location = new System.Drawing.Point(174, 25);
            this.tbWidth.Name = "tbWidth";
            this.tbWidth.Size = new System.Drawing.Size(32, 20);
            this.tbWidth.TabIndex = 1;
            this.tbWidth.Text = "100";
            this.tbWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(16, 28);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(97, 13);
            this.lblWidth.TabIndex = 0;
            this.lblWidth.Text = "Width of area (km):";
            // 
            // gbTasks
            // 
            this.gbTasks.Controls.Add(this.tbMinDeadline);
            this.gbTasks.Controls.Add(this.tbMaxDeadline);
            this.gbTasks.Controls.Add(this.lblMaxDeadline);
            this.gbTasks.Controls.Add(this.lblMinDeadline);
            this.gbTasks.Controls.Add(this.tbAvgDeadline);
            this.gbTasks.Controls.Add(this.lblAverageDeadline);
            this.gbTasks.Controls.Add(this.tbMaxTaskDuration);
            this.gbTasks.Controls.Add(this.lblMaxTaskDuration);
            this.gbTasks.Controls.Add(this.tbMinNofTasks);
            this.gbTasks.Controls.Add(this.tbMaxNofTasks);
            this.gbTasks.Controls.Add(this.label2);
            this.gbTasks.Controls.Add(this.lblMaxNofTasks);
            this.gbTasks.Controls.Add(this.tbAvgNofTasks);
            this.gbTasks.Controls.Add(this.lblAverageNofTasks);
            this.gbTasks.Controls.Add(this.tbMinTaskDuration);
            this.gbTasks.Controls.Add(this.lblMinTaskDuration);
            this.gbTasks.Controls.Add(this.tbAvgTaskDuration);
            this.gbTasks.Controls.Add(this.lblAverageTaskDuration);
            this.gbTasks.Location = new System.Drawing.Point(263, 12);
            this.gbTasks.Name = "gbTasks";
            this.gbTasks.Size = new System.Drawing.Size(229, 311);
            this.gbTasks.TabIndex = 10;
            this.gbTasks.TabStop = false;
            this.gbTasks.Text = "Taken";
            // 
            // tbMinDeadline
            // 
            this.tbMinDeadline.Location = new System.Drawing.Point(183, 179);
            this.tbMinDeadline.Name = "tbMinDeadline";
            this.tbMinDeadline.Size = new System.Drawing.Size(32, 20);
            this.tbMinDeadline.TabIndex = 17;
            this.tbMinDeadline.Text = "5";
            this.tbMinDeadline.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbMaxDeadline
            // 
            this.tbMaxDeadline.Location = new System.Drawing.Point(183, 151);
            this.tbMaxDeadline.Name = "tbMaxDeadline";
            this.tbMaxDeadline.Size = new System.Drawing.Size(32, 20);
            this.tbMaxDeadline.TabIndex = 16;
            this.tbMaxDeadline.Text = "10";
            this.tbMaxDeadline.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMaxDeadline
            // 
            this.lblMaxDeadline.AutoSize = true;
            this.lblMaxDeadline.Location = new System.Drawing.Point(16, 154);
            this.lblMaxDeadline.Name = "lblMaxDeadline";
            this.lblMaxDeadline.Size = new System.Drawing.Size(97, 13);
            this.lblMaxDeadline.TabIndex = 15;
            this.lblMaxDeadline.Text = "Maximum deadline:";
            // 
            // lblMinDeadline
            // 
            this.lblMinDeadline.AutoSize = true;
            this.lblMinDeadline.Location = new System.Drawing.Point(16, 182);
            this.lblMinDeadline.Name = "lblMinDeadline";
            this.lblMinDeadline.Size = new System.Drawing.Size(94, 13);
            this.lblMinDeadline.TabIndex = 14;
            this.lblMinDeadline.Text = "Minimum deadline:";
            // 
            // tbAvgDeadline
            // 
            this.tbAvgDeadline.Location = new System.Drawing.Point(183, 126);
            this.tbAvgDeadline.Name = "tbAvgDeadline";
            this.tbAvgDeadline.Size = new System.Drawing.Size(32, 20);
            this.tbAvgDeadline.TabIndex = 13;
            this.tbAvgDeadline.Text = "7";
            this.tbAvgDeadline.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAverageDeadline
            // 
            this.lblAverageDeadline.AutoSize = true;
            this.lblAverageDeadline.Location = new System.Drawing.Point(16, 129);
            this.lblAverageDeadline.Name = "lblAverageDeadline";
            this.lblAverageDeadline.Size = new System.Drawing.Size(93, 13);
            this.lblAverageDeadline.TabIndex = 12;
            this.lblAverageDeadline.Text = "Average deadline:";
            // 
            // tbMaxTaskDuration
            // 
            this.tbMaxTaskDuration.Location = new System.Drawing.Point(183, 53);
            this.tbMaxTaskDuration.Name = "tbMaxTaskDuration";
            this.tbMaxTaskDuration.Size = new System.Drawing.Size(32, 20);
            this.tbMaxTaskDuration.TabIndex = 11;
            this.tbMaxTaskDuration.Text = "60";
            this.tbMaxTaskDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMaxTaskDuration
            // 
            this.lblMaxTaskDuration.AutoSize = true;
            this.lblMaxTaskDuration.Location = new System.Drawing.Point(16, 56);
            this.lblMaxTaskDuration.Name = "lblMaxTaskDuration";
            this.lblMaxTaskDuration.Size = new System.Drawing.Size(143, 13);
            this.lblMaxTaskDuration.TabIndex = 10;
            this.lblMaxTaskDuration.Text = "Maximum task duration (min):";
            // 
            // tbMinNofTasks
            // 
            this.tbMinNofTasks.Location = new System.Drawing.Point(183, 274);
            this.tbMinNofTasks.Name = "tbMinNofTasks";
            this.tbMinNofTasks.Size = new System.Drawing.Size(32, 20);
            this.tbMinNofTasks.TabIndex = 5;
            this.tbMinNofTasks.Text = "120";
            this.tbMinNofTasks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbMaxNofTasks
            // 
            this.tbMaxNofTasks.Location = new System.Drawing.Point(183, 246);
            this.tbMaxNofTasks.Name = "tbMaxNofTasks";
            this.tbMaxNofTasks.Size = new System.Drawing.Size(32, 20);
            this.tbMaxNofTasks.TabIndex = 3;
            this.tbMaxNofTasks.Text = "180";
            this.tbMaxNofTasks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Minimum number of tasks per day:";
            // 
            // lblMaxNofTasks
            // 
            this.lblMaxNofTasks.AutoSize = true;
            this.lblMaxNofTasks.Location = new System.Drawing.Point(16, 249);
            this.lblMaxNofTasks.Name = "lblMaxNofTasks";
            this.lblMaxNofTasks.Size = new System.Drawing.Size(170, 13);
            this.lblMaxNofTasks.TabIndex = 2;
            this.lblMaxNofTasks.Text = "Maximum number of tasks per day:";
            // 
            // tbAvgNofTasks
            // 
            this.tbAvgNofTasks.Location = new System.Drawing.Point(183, 219);
            this.tbAvgNofTasks.Name = "tbAvgNofTasks";
            this.tbAvgNofTasks.Size = new System.Drawing.Size(32, 20);
            this.tbAvgNofTasks.TabIndex = 1;
            this.tbAvgNofTasks.Text = "150";
            this.tbAvgNofTasks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAverageNofTasks
            // 
            this.lblAverageNofTasks.AutoSize = true;
            this.lblAverageNofTasks.Location = new System.Drawing.Point(16, 222);
            this.lblAverageNofTasks.Name = "lblAverageNofTasks";
            this.lblAverageNofTasks.Size = new System.Drawing.Size(166, 13);
            this.lblAverageNofTasks.TabIndex = 0;
            this.lblAverageNofTasks.Text = "Average number of tasks per day:";
            // 
            // tbMinTaskDuration
            // 
            this.tbMinTaskDuration.Location = new System.Drawing.Point(183, 79);
            this.tbMinTaskDuration.Name = "tbMinTaskDuration";
            this.tbMinTaskDuration.Size = new System.Drawing.Size(32, 20);
            this.tbMinTaskDuration.TabIndex = 9;
            this.tbMinTaskDuration.Text = "30";
            this.tbMinTaskDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMinTaskDuration
            // 
            this.lblMinTaskDuration.AutoSize = true;
            this.lblMinTaskDuration.Location = new System.Drawing.Point(16, 82);
            this.lblMinTaskDuration.Name = "lblMinTaskDuration";
            this.lblMinTaskDuration.Size = new System.Drawing.Size(140, 13);
            this.lblMinTaskDuration.TabIndex = 8;
            this.lblMinTaskDuration.Text = "Minimum task duration (min):";
            // 
            // tbAvgTaskDuration
            // 
            this.tbAvgTaskDuration.Location = new System.Drawing.Point(183, 25);
            this.tbAvgTaskDuration.Name = "tbAvgTaskDuration";
            this.tbAvgTaskDuration.Size = new System.Drawing.Size(32, 20);
            this.tbAvgTaskDuration.TabIndex = 7;
            this.tbAvgTaskDuration.Text = "45";
            this.tbAvgTaskDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAverageTaskDuration
            // 
            this.lblAverageTaskDuration.AutoSize = true;
            this.lblAverageTaskDuration.Location = new System.Drawing.Point(16, 28);
            this.lblAverageTaskDuration.Name = "lblAverageTaskDuration";
            this.lblAverageTaskDuration.Size = new System.Drawing.Size(139, 13);
            this.lblAverageTaskDuration.TabIndex = 6;
            this.lblAverageTaskDuration.Text = "Average task duration (min):";
            // 
            // tbNofDays
            // 
            this.tbNofDays.Location = new System.Drawing.Point(196, 25);
            this.tbNofDays.Name = "tbNofDays";
            this.tbNofDays.Size = new System.Drawing.Size(32, 20);
            this.tbNofDays.TabIndex = 7;
            this.tbNofDays.Text = "270";
            this.tbNofDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbSkills
            // 
            this.gbSkills.Controls.Add(this.lblMaxPercentageSkill);
            this.gbSkills.Controls.Add(this.tbNofSkills);
            this.gbSkills.Controls.Add(this.lblNofSkills);
            this.gbSkills.Controls.Add(this.tbMaxPercentageSkill);
            this.gbSkills.Controls.Add(this.tbMinPercentageSkill);
            this.gbSkills.Controls.Add(this.lblMinPercentageSkill);
            this.gbSkills.Location = new System.Drawing.Point(498, 12);
            this.gbSkills.Name = "gbSkills";
            this.gbSkills.Size = new System.Drawing.Size(229, 112);
            this.gbSkills.TabIndex = 11;
            this.gbSkills.TabStop = false;
            this.gbSkills.Text = "Skills";
            // 
            // lblMaxPercentageSkill
            // 
            this.lblMaxPercentageSkill.AutoSize = true;
            this.lblMaxPercentageSkill.Location = new System.Drawing.Point(16, 82);
            this.lblMaxPercentageSkill.Name = "lblMaxPercentageSkill";
            this.lblMaxPercentageSkill.Size = new System.Drawing.Size(137, 13);
            this.lblMaxPercentageSkill.TabIndex = 9;
            this.lblMaxPercentageSkill.Text = "Highest percentage in task:";
            // 
            // tbNofSkills
            // 
            this.tbNofSkills.Location = new System.Drawing.Point(183, 25);
            this.tbNofSkills.Name = "tbNofSkills";
            this.tbNofSkills.Size = new System.Drawing.Size(32, 20);
            this.tbNofSkills.TabIndex = 3;
            this.tbNofSkills.Text = "10";
            this.tbNofSkills.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNofSkills
            // 
            this.lblNofSkills.AutoSize = true;
            this.lblNofSkills.Location = new System.Drawing.Point(16, 28);
            this.lblNofSkills.Name = "lblNofSkills";
            this.lblNofSkills.Size = new System.Drawing.Size(84, 13);
            this.lblNofSkills.TabIndex = 8;
            this.lblNofSkills.Text = "Number of skills:";
            // 
            // tbMaxPercentageSkill
            // 
            this.tbMaxPercentageSkill.Location = new System.Drawing.Point(183, 79);
            this.tbMaxPercentageSkill.Name = "tbMaxPercentageSkill";
            this.tbMaxPercentageSkill.Size = new System.Drawing.Size(32, 20);
            this.tbMaxPercentageSkill.TabIndex = 7;
            this.tbMaxPercentageSkill.Text = "15";
            this.tbMaxPercentageSkill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbMinPercentageSkill
            // 
            this.tbMinPercentageSkill.Location = new System.Drawing.Point(183, 53);
            this.tbMinPercentageSkill.Name = "tbMinPercentageSkill";
            this.tbMinPercentageSkill.Size = new System.Drawing.Size(32, 20);
            this.tbMinPercentageSkill.TabIndex = 5;
            this.tbMinPercentageSkill.Text = "5";
            this.tbMinPercentageSkill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMinPercentageSkill
            // 
            this.lblMinPercentageSkill.AutoSize = true;
            this.lblMinPercentageSkill.Location = new System.Drawing.Point(16, 56);
            this.lblMinPercentageSkill.Name = "lblMinPercentageSkill";
            this.lblMinPercentageSkill.Size = new System.Drawing.Size(135, 13);
            this.lblMinPercentageSkill.TabIndex = 4;
            this.lblMinPercentageSkill.Text = "Lowest percentage in task:";
            // 
            // gbSimulation
            // 
            this.gbSimulation.Controls.Add(this.tbRandomAssignment);
            this.gbSimulation.Controls.Add(this.lblPercentagePreset);
            this.gbSimulation.Controls.Add(this.tbBlocktimeDuration);
            this.gbSimulation.Controls.Add(this.lblBlocktimeDuration);
            this.gbSimulation.Controls.Add(this.tbSpeed);
            this.gbSimulation.Controls.Add(this.lblSpeed);
            this.gbSimulation.Controls.Add(this.lblNofDays);
            this.gbSimulation.Controls.Add(this.tbNofDays);
            this.gbSimulation.Location = new System.Drawing.Point(12, 12);
            this.gbSimulation.Name = "gbSimulation";
            this.gbSimulation.Size = new System.Drawing.Size(245, 311);
            this.gbSimulation.TabIndex = 12;
            this.gbSimulation.TabStop = false;
            this.gbSimulation.Text = "Simulation";
            // 
            // tbRandomAssignment
            // 
            this.tbRandomAssignment.Location = new System.Drawing.Point(196, 105);
            this.tbRandomAssignment.Name = "tbRandomAssignment";
            this.tbRandomAssignment.Size = new System.Drawing.Size(32, 20);
            this.tbRandomAssignment.TabIndex = 16;
            this.tbRandomAssignment.Text = "0";
            this.tbRandomAssignment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPercentagePreset
            // 
            this.lblPercentagePreset.AutoSize = true;
            this.lblPercentagePreset.Location = new System.Drawing.Point(16, 108);
            this.lblPercentagePreset.Name = "lblPercentagePreset";
            this.lblPercentagePreset.Size = new System.Drawing.Size(123, 13);
            this.lblPercentagePreset.TabIndex = 15;
            this.lblPercentagePreset.Text = "Random assignment (%):";
            // 
            // tbBlocktimeDuration
            // 
            this.tbBlocktimeDuration.Location = new System.Drawing.Point(196, 79);
            this.tbBlocktimeDuration.Name = "tbBlocktimeDuration";
            this.tbBlocktimeDuration.Size = new System.Drawing.Size(32, 20);
            this.tbBlocktimeDuration.TabIndex = 14;
            this.tbBlocktimeDuration.Text = "120";
            this.tbBlocktimeDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBlocktimeDuration
            // 
            this.lblBlocktimeDuration.AutoSize = true;
            this.lblBlocktimeDuration.Location = new System.Drawing.Point(16, 82);
            this.lblBlocktimeDuration.Name = "lblBlocktimeDuration";
            this.lblBlocktimeDuration.Size = new System.Drawing.Size(78, 13);
            this.lblBlocktimeDuration.TabIndex = 13;
            this.lblBlocktimeDuration.Text = "Block duration:";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(196, 53);
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(32, 20);
            this.tbSpeed.TabIndex = 10;
            this.tbSpeed.Text = "60";
            this.tbSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(16, 56);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(75, 13);
            this.lblSpeed.TabIndex = 9;
            this.lblSpeed.Text = "Speed (km/h):";
            // 
            // lblNofDays
            // 
            this.lblNofDays.AutoSize = true;
            this.lblNofDays.Location = new System.Drawing.Point(16, 28);
            this.lblNofDays.Name = "lblNofDays";
            this.lblNofDays.Size = new System.Drawing.Size(148, 13);
            this.lblNofDays.TabIndex = 8;
            this.lblNofDays.Text = "Number of days for simulation:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbShiftDuration);
            this.groupBox1.Controls.Add(this.lblShiftDuration);
            this.groupBox1.Controls.Add(this.tbAvgNofSkills);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbNofEmployees);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(498, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 113);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Engineers";
            // 
            // tbShiftDuration
            // 
            this.tbShiftDuration.Location = new System.Drawing.Point(183, 82);
            this.tbShiftDuration.Name = "tbShiftDuration";
            this.tbShiftDuration.Size = new System.Drawing.Size(32, 20);
            this.tbShiftDuration.TabIndex = 7;
            this.tbShiftDuration.Text = "480";
            this.tbShiftDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblShiftDuration
            // 
            this.lblShiftDuration.AutoSize = true;
            this.lblShiftDuration.Location = new System.Drawing.Point(16, 85);
            this.lblShiftDuration.Name = "lblShiftDuration";
            this.lblShiftDuration.Size = new System.Drawing.Size(97, 13);
            this.lblShiftDuration.TabIndex = 6;
            this.lblShiftDuration.Text = "Shift duration (min):";
            // 
            // tbAvgNofSkills
            // 
            this.tbAvgNofSkills.Location = new System.Drawing.Point(183, 53);
            this.tbAvgNofSkills.Name = "tbAvgNofSkills";
            this.tbAvgNofSkills.Size = new System.Drawing.Size(32, 20);
            this.tbAvgNofSkills.TabIndex = 5;
            this.tbAvgNofSkills.Text = "5";
            this.tbAvgNofSkills.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Average nuberof skills:";
            // 
            // tbNofEmployees
            // 
            this.tbNofEmployees.Location = new System.Drawing.Point(183, 25);
            this.tbNofEmployees.Name = "tbNofEmployees";
            this.tbNofEmployees.Size = new System.Drawing.Size(32, 20);
            this.tbNofEmployees.TabIndex = 1;
            this.tbNofEmployees.Text = "25";
            this.tbNofEmployees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Number of engineers:";
            // 
            // dialFolder
            // 
            this.dialFolder.SelectedPath = ".";
            // 
            // gbGenerateData
            // 
            this.gbGenerateData.Controls.Add(this.tbVersion);
            this.gbGenerateData.Controls.Add(this.lblVersion);
            this.gbGenerateData.Controls.Add(this.btnCreate);
            this.gbGenerateData.Location = new System.Drawing.Point(733, 177);
            this.gbGenerateData.Name = "gbGenerateData";
            this.gbGenerateData.Size = new System.Drawing.Size(221, 146);
            this.gbGenerateData.TabIndex = 13;
            this.gbGenerateData.TabStop = false;
            this.gbGenerateData.Text = "Generate data";
            // 
            // tbVersion
            // 
            this.tbVersion.Location = new System.Drawing.Point(105, 23);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(32, 20);
            this.tbVersion.TabIndex = 14;
            this.tbVersion.Text = "1";
            this.tbVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(16, 26);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(83, 13);
            this.lblVersion.TabIndex = 8;
            this.lblVersion.Text = "Version number:";
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(19, 63);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(187, 38);
            this.btnCreate.TabIndex = 13;
            this.btnCreate.Text = "Generate data ...";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 335);
            this.Controls.Add(this.gbGenerateData);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSimulation);
            this.Controls.Add(this.gbSkills);
            this.Controls.Add(this.gbTasks);
            this.Controls.Add(this.gbGeometry);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigurationForm";
            this.Text = "Configuration";
            this.gbGeometry.ResumeLayout(false);
            this.gbGeometry.PerformLayout();
            this.gbTasks.ResumeLayout(false);
            this.gbTasks.PerformLayout();
            this.gbSkills.ResumeLayout(false);
            this.gbSkills.PerformLayout();
            this.gbSimulation.ResumeLayout(false);
            this.gbSimulation.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbGenerateData.ResumeLayout(false);
            this.gbGenerateData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGeometry;
        private System.Windows.Forms.TextBox tbNofRegionsHeight;
        private System.Windows.Forms.Label lblNofRegionsHeight;
        private System.Windows.Forms.TextBox tbNofRegionsWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox tbWidth;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.GroupBox gbTasks;
        private System.Windows.Forms.TextBox tbMinNofTasks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMaxNofTasks;
        private System.Windows.Forms.Label lblMaxNofTasks;
        private System.Windows.Forms.TextBox tbAvgNofTasks;
        private System.Windows.Forms.Label lblAverageNofTasks;
        private System.Windows.Forms.TextBox tbNofDays;
        private System.Windows.Forms.Label lblNofSkills;
        private System.Windows.Forms.TextBox tbNofSkills;
        private System.Windows.Forms.GroupBox gbSkills;
        private System.Windows.Forms.TextBox tbMaxPercentageSkill;
        private System.Windows.Forms.TextBox tbMinPercentageSkill;
        private System.Windows.Forms.Label lblMinPercentageSkill;
        private System.Windows.Forms.GroupBox gbSimulation;
        private System.Windows.Forms.Label lblNofDays;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbAvgNofSkills;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbNofEmployees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMaxPercentageSkill;
        private System.Windows.Forms.TextBox tbMinDeadline;
        private System.Windows.Forms.TextBox tbMaxDeadline;
        private System.Windows.Forms.Label lblMaxDeadline;
        private System.Windows.Forms.Label lblMinDeadline;
        private System.Windows.Forms.TextBox tbAvgDeadline;
        private System.Windows.Forms.Label lblAverageDeadline;
        private System.Windows.Forms.TextBox tbMaxTaskDuration;
        private System.Windows.Forms.Label lblMaxTaskDuration;
        private System.Windows.Forms.TextBox tbMinTaskDuration;
        private System.Windows.Forms.Label lblMinTaskDuration;
        private System.Windows.Forms.TextBox tbAvgTaskDuration;
        private System.Windows.Forms.Label lblAverageTaskDuration;
        private System.Windows.Forms.TextBox tbSpeed;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.FolderBrowserDialog dialFolder;
        private System.Windows.Forms.GroupBox gbGenerateData;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox tbBlocktimeDuration;
        private System.Windows.Forms.Label lblBlocktimeDuration;
        private System.Windows.Forms.TextBox tbShiftDuration;
        private System.Windows.Forms.Label lblShiftDuration;
        private System.Windows.Forms.TextBox tbRandomAssignment;
        private System.Windows.Forms.Label lblPercentagePreset;
    }
}