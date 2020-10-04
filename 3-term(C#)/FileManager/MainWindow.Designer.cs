namespace FileManager
{
    partial class MainWindow
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
            this.LeftDirectoryView = new System.Windows.Forms.ListBox();
            this.RightDirectoryView = new System.Windows.Forms.ListBox();
            this.LeftSelectDisk = new System.Windows.Forms.ComboBox();
            this.RightSelectDisk = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.LeftFilesHidden = new System.Windows.Forms.CheckBox();
            this.RightFilesHidden = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LeftDirectoryView
            // 
            this.LeftDirectoryView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftDirectoryView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeftDirectoryView.FormattingEnabled = true;
            this.LeftDirectoryView.ItemHeight = 25;
            this.LeftDirectoryView.Location = new System.Drawing.Point(12, 74);
            this.LeftDirectoryView.Name = "LeftDirectoryView";
            this.LeftDirectoryView.Size = new System.Drawing.Size(600, 1052);
            this.LeftDirectoryView.TabIndex = 0;
            this.LeftDirectoryView.SelectedIndexChanged += new System.EventHandler(this.LeftDirectoryView_SelectedIndexChanged);
            // 
            // RightDirectoryView
            // 
            this.RightDirectoryView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RightDirectoryView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RightDirectoryView.FormattingEnabled = true;
            this.RightDirectoryView.ItemHeight = 25;
            this.RightDirectoryView.Location = new System.Drawing.Point(631, 74);
            this.RightDirectoryView.Name = "RightDirectoryView";
            this.RightDirectoryView.Size = new System.Drawing.Size(600, 1052);
            this.RightDirectoryView.TabIndex = 1;
            this.RightDirectoryView.SelectedIndexChanged += new System.EventHandler(this.RightDirectoryView_SelectedIndexChanged);
            // 
            // LeftSelectDisk
            // 
            this.LeftSelectDisk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeftSelectDisk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LeftSelectDisk.FormattingEnabled = true;
            this.LeftSelectDisk.Location = new System.Drawing.Point(12, 24);
            this.LeftSelectDisk.Name = "LeftSelectDisk";
            this.LeftSelectDisk.Size = new System.Drawing.Size(102, 33);
            this.LeftSelectDisk.TabIndex = 2;
            this.LeftSelectDisk.SelectedIndexChanged += new System.EventHandler(this.LeftSelectDisk_SelectedIndexChanged);
            // 
            // RightSelectDisk
            // 
            this.RightSelectDisk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RightSelectDisk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RightSelectDisk.FormattingEnabled = true;
            this.RightSelectDisk.Location = new System.Drawing.Point(631, 24);
            this.RightSelectDisk.Name = "RightSelectDisk";
            this.RightSelectDisk.Size = new System.Drawing.Size(110, 33);
            this.RightSelectDisk.TabIndex = 3;
            this.RightSelectDisk.SelectedIndexChanged += new System.EventHandler(this.RightSelectDisk_SelectedIndexChanged);
            // 
            // LeftFilesHidden
            // 
            this.LeftFilesHidden.AutoSize = true;
            this.LeftFilesHidden.Location = new System.Drawing.Point(420, 28);
            this.LeftFilesHidden.Name = "LeftFilesHidden";
            this.LeftFilesHidden.Size = new System.Drawing.Size(192, 29);
            this.LeftFilesHidden.TabIndex = 4;
            this.LeftFilesHidden.Text = "Скрыть файлы";
            this.LeftFilesHidden.UseVisualStyleBackColor = true;
            this.LeftFilesHidden.CheckedChanged += new System.EventHandler(this.LeftFilesHidden_CheckedChanged);
            // 
            // RightFilesHidden
            // 
            this.RightFilesHidden.AutoSize = true;
            this.RightFilesHidden.Location = new System.Drawing.Point(1039, 24);
            this.RightFilesHidden.Name = "RightFilesHidden";
            this.RightFilesHidden.Size = new System.Drawing.Size(192, 29);
            this.RightFilesHidden.TabIndex = 5;
            this.RightFilesHidden.Text = "Скрыть файлы";
            this.RightFilesHidden.UseVisualStyleBackColor = true;
            this.RightFilesHidden.CheckedChanged += new System.EventHandler(this.RightFilesHidden_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 1209);
            this.Controls.Add(this.RightFilesHidden);
            this.Controls.Add(this.LeftFilesHidden);
            this.Controls.Add(this.RightSelectDisk);
            this.Controls.Add(this.LeftSelectDisk);
            this.Controls.Add(this.RightDirectoryView);
            this.Controls.Add(this.LeftDirectoryView);
            this.Name = "MainWindow";
            this.Text = "File Manager";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LeftDirectoryView;
        private System.Windows.Forms.ListBox RightDirectoryView;
        private System.Windows.Forms.ComboBox LeftSelectDisk;
        private System.Windows.Forms.ComboBox RightSelectDisk;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox LeftFilesHidden;
        private System.Windows.Forms.CheckBox RightFilesHidden;
    }
}

