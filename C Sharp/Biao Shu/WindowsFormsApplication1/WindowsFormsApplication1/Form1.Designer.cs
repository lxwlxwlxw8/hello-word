namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tb_fileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_totalNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.differGridView = new System.Windows.Forms.DataGridView();
            this.rowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.excelNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.phName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.differGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(474, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "选择文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_fileName
            // 
            this.tb_fileName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_fileName.Location = new System.Drawing.Point(77, 18);
            this.tb_fileName.Multiline = true;
            this.tb_fileName.Name = "tb_fileName";
            this.tb_fileName.ReadOnly = true;
            this.tb_fileName.Size = new System.Drawing.Size(391, 23);
            this.tb_fileName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "文件位置：";
            // 
            // textBox_totalNum
            // 
            this.textBox_totalNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_totalNum.Location = new System.Drawing.Point(77, 61);
            this.textBox_totalNum.Name = "textBox_totalNum";
            this.textBox_totalNum.ReadOnly = true;
            this.textBox_totalNum.Size = new System.Drawing.Size(70, 26);
            this.textBox_totalNum.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "总数量：";
            // 
            // differGridView
            // 
            this.differGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.differGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowNo,
            this.excelNum,
            this.countNum});
            this.differGridView.Location = new System.Drawing.Point(347, 60);
            this.differGridView.Name = "differGridView";
            this.differGridView.RowTemplate.Height = 23;
            this.differGridView.Size = new System.Drawing.Size(292, 93);
            this.differGridView.TabIndex = 5;
            // 
            // rowNo
            // 
            this.rowNo.HeaderText = "行号";
            this.rowNo.Name = "rowNo";
            this.rowNo.ReadOnly = true;
            this.rowNo.Width = 60;
            // 
            // excelNum
            // 
            this.excelNum.HeaderText = "excel数量";
            this.excelNum.Name = "excelNum";
            this.excelNum.ReadOnly = true;
            this.excelNum.Width = 90;
            // 
            // countNum
            // 
            this.countNum.HeaderText = "计算数量";
            this.countNum.Name = "countNum";
            this.countNum.ReadOnly = true;
            this.countNum.Width = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "个";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(229, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "每行数量差异表:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phName,
            this.rowNum});
            this.dataGridView2.Location = new System.Drawing.Point(10, 178);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(629, 241);
            this.dataGridView2.TabIndex = 8;
            // 
            // phName
            // 
            this.phName.HeaderText = "编号名称";
            this.phName.Name = "phName";
            this.phName.ReadOnly = true;
            this.phName.Width = 150;
            // 
            // rowNum
            // 
            this.rowNum.HeaderText = "行号";
            this.rowNum.Name = "rowNum";
            this.rowNum.ReadOnly = true;
            this.rowNum.Width = 350;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "重复编号表:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(556, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "分析数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 430);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.differGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_totalNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_fileName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "出厂编号识别工具";
            ((System.ComponentModel.ISupportInitialize)(this.differGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_fileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_totalNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView differGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn excelNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn countNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn phName;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowNum;
        private System.Windows.Forms.Button button2;
    }
}

