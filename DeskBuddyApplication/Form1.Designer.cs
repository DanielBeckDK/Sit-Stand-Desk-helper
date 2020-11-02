namespace DeskBuddyApplication
{
    partial class DeskBuddyForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonColorAction = new System.Windows.Forms.Button();
            this.buttonColorStay = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxActionColor = new System.Windows.Forms.PictureBox();
            this.pictureBoxStayColor = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxChartRange = new System.Windows.Forms.ComboBox();
            this.chartPositions = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.measurementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet = new DeskBuddyApplication.Database1DataSet();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.colorDialogAction = new System.Windows.Forms.ColorDialog();
            this.colorDialogStay = new System.Windows.Forms.ColorDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.measurementsTableAdapter = new DeskBuddyApplication.Database1DataSetTableAdapters.MeasurementsTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActionColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStayColor)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPositions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonColorAction
            // 
            this.buttonColorAction.Location = new System.Drawing.Point(9, 50);
            this.buttonColorAction.Name = "buttonColorAction";
            this.buttonColorAction.Size = new System.Drawing.Size(89, 23);
            this.buttonColorAction.TabIndex = 0;
            this.buttonColorAction.Text = "Choose Color";
            this.buttonColorAction.UseVisualStyleBackColor = true;
            this.buttonColorAction.Click += new System.EventHandler(this.buttonColorAction_Click);
            // 
            // buttonColorStay
            // 
            this.buttonColorStay.Location = new System.Drawing.Point(9, 126);
            this.buttonColorStay.Name = "buttonColorStay";
            this.buttonColorStay.Size = new System.Drawing.Size(89, 23);
            this.buttonColorStay.TabIndex = 1;
            this.buttonColorStay.Text = "Choose Color";
            this.buttonColorStay.UseVisualStyleBackColor = true;
            this.buttonColorStay.Click += new System.EventHandler(this.buttonColorStay_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBoxActionColor);
            this.groupBox1.Controls.Add(this.pictureBoxStayColor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonColorAction);
            this.groupBox1.Controls.Add(this.buttonColorStay);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 160);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change LED color";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "LED color when position change is reccomended";
            // 
            // pictureBoxActionColor
            // 
            this.pictureBoxActionColor.Location = new System.Drawing.Point(217, 50);
            this.pictureBoxActionColor.Name = "pictureBoxActionColor";
            this.pictureBoxActionColor.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxActionColor.TabIndex = 7;
            this.pictureBoxActionColor.TabStop = false;
            // 
            // pictureBoxStayColor
            // 
            this.pictureBoxStayColor.Location = new System.Drawing.Point(217, 126);
            this.pictureBoxStayColor.Name = "pictureBoxStayColor";
            this.pictureBoxStayColor.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxStayColor.TabIndex = 8;
            this.pictureBoxStayColor.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "LED color while no change in position is needed";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxChartRange);
            this.groupBox2.Controls.Add(this.chartPositions);
            this.groupBox2.Location = new System.Drawing.Point(12, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1053, 654);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Statistics";
            // 
            // comboBoxChartRange
            // 
            this.comboBoxChartRange.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxChartRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChartRange.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBoxChartRange.FormattingEnabled = true;
            this.comboBoxChartRange.Items.AddRange(new object[] {
            "Hour",
            "Day",
            "Week",
            "Month",
            "Year"});
            this.comboBoxChartRange.Location = new System.Drawing.Point(926, 89);
            this.comboBoxChartRange.Name = "comboBoxChartRange";
            this.comboBoxChartRange.Size = new System.Drawing.Size(88, 21);
            this.comboBoxChartRange.TabIndex = 9;
            this.comboBoxChartRange.SelectedIndexChanged += new System.EventHandler(this.comboBoxChartRange_SelectedIndexChanged);
            // 
            // chartPositions
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPositions.ChartAreas.Add(chartArea1);
            this.chartPositions.DataSource = this.measurementsBindingSource;
            legend1.Name = "Legend1";
            this.chartPositions.Legends.Add(legend1);
            this.chartPositions.Location = new System.Drawing.Point(9, 19);
            this.chartPositions.Name = "chartPositions";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.DodgerBlue;
            series1.Legend = "Legend1";
            series1.Name = "Sitting";
            series1.XValueMember = "Distance";
            series1.YValueMembers = "DateTime";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(191)))), ((int)(((byte)(87)))));
            series2.Legend = "Legend1";
            series2.Name = "Standing";
            this.chartPositions.Series.Add(series1);
            this.chartPositions.Series.Add(series2);
            this.chartPositions.Size = new System.Drawing.Size(1038, 629);
            this.chartPositions.TabIndex = 0;
            this.chartPositions.Text = "chart1";
            // 
            // measurementsBindingSource
            // 
            this.measurementsBindingSource.DataMember = "Measurements";
            this.measurementsBindingSource.DataSource = this.database1DataSet;
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(343, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(642, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 160);
            this.textBox1.TabIndex = 5;
            // 
            // measurementsTableAdapter
            // 
            this.measurementsTableAdapter.ClearBeforeFill = true;
            // 
            // DeskBuddyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1077, 844);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DeskBuddyForm";
            this.Text = "DeskBuddy Control Center";
            this.Load += new System.EventHandler(this.DeskBuddyForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActionColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStayColor)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPositions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.measurementsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonColorAction;
        private System.Windows.Forms.Button buttonColorStay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxActionColor;
        private System.Windows.Forms.PictureBox pictureBoxStayColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxChartRange;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPositions;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ColorDialog colorDialogAction;
        private System.Windows.Forms.ColorDialog colorDialogStay;
        private System.Windows.Forms.TextBox textBox1;
        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource measurementsBindingSource;
        private Database1DataSetTableAdapters.MeasurementsTableAdapter measurementsTableAdapter;
    }
}

