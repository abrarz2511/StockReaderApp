namespace StockReaderApp
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            openFileDialog_loadData = new OpenFileDialog();
            label_PickStartDate = new Label();
            label_EndDate = new Label();
            Button1_loadData = new Button();
            form1BindingSource = new BindingSource(components);
            bindingSource1 = new BindingSource(components);
            dataGridView1 = new DataGridView();
            chart_ShowData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart_ShowData).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(538, 58);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(538, 145);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 1;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // openFileDialog_loadData
            // 
            openFileDialog_loadData.FileName = "openFileDialog1";
            openFileDialog_loadData.InitialDirectory = "D:\\newCode\\StockReaderApp";
            openFileDialog_loadData.Multiselect = true;
            openFileDialog_loadData.FileOk += openFileDialog_loadData_FileOk;
            // 
            // label_PickStartDate
            // 
            label_PickStartDate.AutoSize = true;
            label_PickStartDate.Location = new Point(537, 31);
            label_PickStartDate.Name = "label_PickStartDate";
            label_PickStartDate.Size = new Size(106, 20);
            label_PickStartDate.TabIndex = 2;
            label_PickStartDate.Text = "Pick Start Date";
            // 
            // label_EndDate
            // 
            label_EndDate.AutoSize = true;
            label_EndDate.Location = new Point(538, 122);
            label_EndDate.Name = "label_EndDate";
            label_EndDate.Size = new Size(100, 20);
            label_EndDate.TabIndex = 3;
            label_EndDate.Text = "Pick End Date";
            // 
            // Button1_loadData
            // 
            Button1_loadData.Location = new Point(602, 220);
            Button1_loadData.Name = "Button1_loadData";
            Button1_loadData.Size = new Size(94, 29);
            Button1_loadData.TabIndex = 4;
            Button1_loadData.Text = "Load Data";
            Button1_loadData.UseVisualStyleBackColor = true;
            Button1_loadData.Click += button1_loadData_Click;
            // 
            // form1BindingSource
            // 
            form1BindingSource.DataSource = typeof(Form1);
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(300, 188);
            dataGridView1.TabIndex = 5;
            // 
            // chart_ShowData
            // 
            chartArea2.Name = "ChartArea_OHLC";
            chart_ShowData.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart_ShowData.Legends.Add(legend2);
            chart_ShowData.Location = new Point(34, 268);
            chart_ShowData.Name = "chart_ShowData";
            series2.ChartArea = "ChartArea_OHLC";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart_ShowData.Series.Add(series2);
            chart_ShowData.Size = new Size(375, 375);
            chart_ShowData.TabIndex = 6;
            chart_ShowData.Text = "chart1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chart_ShowData);
            Controls.Add(dataGridView1);
            Controls.Add(Button1_loadData);
            Controls.Add(label_EndDate);
            Controls.Add(label_PickStartDate);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart_ShowData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label_PickStartDate;
        private Label label_EndDate;
        private Button Button1_loadData;
        private BindingSource form1BindingSource;
        private BindingSource bindingSource1;
        private DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_ShowData;
        protected internal OpenFileDialog openFileDialog_loadData;
    }
}
