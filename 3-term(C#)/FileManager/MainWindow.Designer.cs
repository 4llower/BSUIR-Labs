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
            this.copyButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.CompressButton = new System.Windows.Forms.Button();
            this.DecompressButton = new System.Windows.Forms.Button();
            this.SwapButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LeftDirectoryView
            // 
            this.LeftDirectoryView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftDirectoryView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeftDirectoryView.FormattingEnabled = true;
            this.LeftDirectoryView.ItemHeight = 25;
            this.LeftDirectoryView.Location = new System.Drawing.Point(12, 126);
            this.LeftDirectoryView.Name = "LeftDirectoryView";
            this.LeftDirectoryView.Size = new System.Drawing.Size(600, 1002);
            this.LeftDirectoryView.TabIndex = 0;
            this.LeftDirectoryView.SelectedIndexChanged += new System.EventHandler(this.LeftDirectoryView_SelectedIndexChanged);
            // 
            // RightDirectoryView
            // 
            this.RightDirectoryView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RightDirectoryView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RightDirectoryView.FormattingEnabled = true;
            this.RightDirectoryView.ItemHeight = 25;
            this.RightDirectoryView.Location = new System.Drawing.Point(631, 126);
            this.RightDirectoryView.Name = "RightDirectoryView";
            this.RightDirectoryView.Size = new System.Drawing.Size(600, 1002);
            this.RightDirectoryView.TabIndex = 1;
            this.RightDirectoryView.SelectedIndexChanged += new System.EventHandler(this.RightDirectoryView_SelectedIndexChanged);
            // 
            // LeftSelectDisk
            // 
            this.LeftSelectDisk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeftSelectDisk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LeftSelectDisk.FormattingEnabled = true;
            this.LeftSelectDisk.Location = new System.Drawing.Point(197, 30);
            this.LeftSelectDisk.Name = "LeftSelectDisk";
            this.LeftSelectDisk.Size = new System.Drawing.Size(189, 33);
            this.LeftSelectDisk.TabIndex = 2;
            this.LeftSelectDisk.SelectedIndexChanged += new System.EventHandler(this.LeftSelectDisk_SelectedIndexChanged);
            // 
            // RightSelectDisk
            // 
            this.RightSelectDisk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RightSelectDisk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RightSelectDisk.FormattingEnabled = true;
            this.RightSelectDisk.Location = new System.Drawing.Point(848, 28);
            this.RightSelectDisk.Name = "RightSelectDisk";
            this.RightSelectDisk.Size = new System.Drawing.Size(192, 33);
            this.RightSelectDisk.TabIndex = 3;
            this.RightSelectDisk.SelectedIndexChanged += new System.EventHandler(this.RightSelectDisk_SelectedIndexChanged);
            // 
            // LeftFilesHidden
            // 
            this.LeftFilesHidden.AutoSize = true;
            this.LeftFilesHidden.Location = new System.Drawing.Point(197, 80);
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
            this.RightFilesHidden.Location = new System.Drawing.Point(848, 80);
            this.RightFilesHidden.Name = "RightFilesHidden";
            this.RightFilesHidden.Size = new System.Drawing.Size(192, 29);
            this.RightFilesHidden.TabIndex = 5;
            this.RightFilesHidden.Text = "Скрыть файлы";
            this.RightFilesHidden.UseVisualStyleBackColor = true;
            this.RightFilesHidden.CheckedChanged += new System.EventHandler(this.RightFilesHidden_CheckedChanged);
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(699, 51);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(89, 58);
            this.copyButton.TabIndex = 6;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(445, 51);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(89, 58);
            this.moveButton.TabIndex = 7;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(540, 51);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(153, 58);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CompressButton
            // 
            this.CompressButton.Location = new System.Drawing.Point(412, 4);
            this.CompressButton.Name = "CompressButton";
            this.CompressButton.Size = new System.Drawing.Size(155, 41);
            this.CompressButton.TabIndex = 9;
            this.CompressButton.Text = "Compress";
            this.CompressButton.UseVisualStyleBackColor = true;
            this.CompressButton.Click += new System.EventHandler(this.CompressButton_Click);
            // 
            // DecompressButton
            // 
            this.DecompressButton.Location = new System.Drawing.Point(666, 4);
            this.DecompressButton.Name = "DecompressButton";
            this.DecompressButton.Size = new System.Drawing.Size(155, 41);
            this.DecompressButton.TabIndex = 10;
            this.DecompressButton.Text = "Decompress";
            this.DecompressButton.UseVisualStyleBackColor = true;
            this.DecompressButton.Click += new System.EventHandler(this.DecompressButton_Click);
            // 
            // SwapButton
            // 
            this.SwapButton.Location = new System.Drawing.Point(573, 4);
            this.SwapButton.Name = "SwapButton";
            this.SwapButton.Size = new System.Drawing.Size(87, 41);
            this.SwapButton.TabIndex = 11;
            this.SwapButton.Text = "Swap";
            this.SwapButton.UseVisualStyleBackColor = true;
            this.SwapButton.Click += new System.EventHandler(this.SwapButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 1209);
            this.Controls.Add(this.SwapButton);
            this.Controls.Add(this.DecompressButton);
            this.Controls.Add(this.CompressButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.copyButton);
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
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button CompressButton;
        private System.Windows.Forms.Button DecompressButton;
        private System.Windows.Forms.Button SwapButton;
    }
}

