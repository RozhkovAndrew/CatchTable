namespace WindowsFormsApp1
{
    partial class Form1
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
            this.DownloadButton = new System.Windows.Forms.Button();
            this.comboMonthList = new System.Windows.Forms.ComboBox();
            this.comboTeacherList = new System.Windows.Forms.ComboBox();
            this.comboGroupList = new System.Windows.Forms.ComboBox();
            this.dgvOutput = new System.Windows.Forms.DataGridView();
            this.buttonTeacher = new System.Windows.Forms.Button();
            this.buttonGroup = new System.Windows.Forms.Button();
            this.labelMonth = new System.Windows.Forms.Label();
            this.labelTeacher = new System.Windows.Forms.Label();
            this.labelGroup = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // DownloadButton
            // 
            this.DownloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DownloadButton.Location = new System.Drawing.Point(53, 24);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(196, 31);
            this.DownloadButton.TabIndex = 0;
            this.DownloadButton.Text = "Получить расписание";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // comboMonthList
            // 
            this.comboMonthList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboMonthList.FormattingEnabled = true;
            this.comboMonthList.Location = new System.Drawing.Point(53, 90);
            this.comboMonthList.Name = "comboMonthList";
            this.comboMonthList.Size = new System.Drawing.Size(196, 24);
            this.comboMonthList.TabIndex = 1;
            // 
            // comboTeacherList
            // 
            this.comboTeacherList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboTeacherList.FormattingEnabled = true;
            this.comboTeacherList.Location = new System.Drawing.Point(277, 90);
            this.comboTeacherList.Name = "comboTeacherList";
            this.comboTeacherList.Size = new System.Drawing.Size(188, 24);
            this.comboTeacherList.TabIndex = 2;
            // 
            // comboGroupList
            // 
            this.comboGroupList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboGroupList.FormattingEnabled = true;
            this.comboGroupList.Location = new System.Drawing.Point(494, 90);
            this.comboGroupList.Name = "comboGroupList";
            this.comboGroupList.Size = new System.Drawing.Size(194, 24);
            this.comboGroupList.TabIndex = 3;
            // 
            // dgvOutput
            // 
            this.dgvOutput.AllowUserToOrderColumns = true;
            this.dgvOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutput.Location = new System.Drawing.Point(53, 162);
            this.dgvOutput.Name = "dgvOutput";
            this.dgvOutput.Size = new System.Drawing.Size(635, 378);
            this.dgvOutput.TabIndex = 4;
            // 
            // buttonTeacher
            // 
            this.buttonTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTeacher.Location = new System.Drawing.Point(277, 24);
            this.buttonTeacher.Name = "buttonTeacher";
            this.buttonTeacher.Size = new System.Drawing.Size(188, 31);
            this.buttonTeacher.TabIndex = 5;
            this.buttonTeacher.Text = "Поиск по преподавателю";
            this.buttonTeacher.UseVisualStyleBackColor = true;
            this.buttonTeacher.Click += new System.EventHandler(this.buttonTeacher_Click);
            // 
            // buttonGroup
            // 
            this.buttonGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGroup.Location = new System.Drawing.Point(494, 25);
            this.buttonGroup.Name = "buttonGroup";
            this.buttonGroup.Size = new System.Drawing.Size(194, 30);
            this.buttonGroup.TabIndex = 6;
            this.buttonGroup.Text = "Поиск по группе";
            this.buttonGroup.UseVisualStyleBackColor = true;
            this.buttonGroup.Click += new System.EventHandler(this.buttonGroup_Click);
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMonth.Location = new System.Drawing.Point(59, 67);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(149, 20);
            this.labelMonth.TabIndex = 7;
            this.labelMonth.Text = "Учебный период";
            // 
            // labelTeacher
            // 
            this.labelTeacher.AutoSize = true;
            this.labelTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTeacher.Location = new System.Drawing.Point(284, 67);
            this.labelTeacher.Name = "labelTeacher";
            this.labelTeacher.Size = new System.Drawing.Size(145, 20);
            this.labelTeacher.TabIndex = 8;
            this.labelTeacher.Text = "Преподаватель";
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGroup.Location = new System.Drawing.Point(500, 67);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(67, 20);
            this.labelGroup.TabIndex = 9;
            this.labelGroup.Text = "Группа";
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOutput.Location = new System.Drawing.Point(60, 133);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(0, 16);
            this.labelOutput.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 570);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.labelTeacher);
            this.Controls.Add(this.labelMonth);
            this.Controls.Add(this.buttonGroup);
            this.Controls.Add(this.buttonTeacher);
            this.Controls.Add(this.dgvOutput);
            this.Controls.Add(this.comboGroupList);
            this.Controls.Add(this.comboTeacherList);
            this.Controls.Add(this.comboMonthList);
            this.Controls.Add(this.DownloadButton);
            this.Name = "Form1";
            this.Text = "Обозреватель расписания занятий";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.ComboBox comboMonthList;
        private System.Windows.Forms.ComboBox comboTeacherList;
        private System.Windows.Forms.ComboBox comboGroupList;
        private System.Windows.Forms.DataGridView dgvOutput;
        private System.Windows.Forms.Button buttonTeacher;
        private System.Windows.Forms.Button buttonGroup;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.Label labelTeacher;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Label labelOutput;
    }
}

