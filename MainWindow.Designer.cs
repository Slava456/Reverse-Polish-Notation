namespace TestRPN
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
            this.bt = new System.Windows.Forms.Button();
            this.tbIn = new System.Windows.Forms.TextBox();
            this.tbOut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bt
            // 
            this.bt.Location = new System.Drawing.Point(92, 84);
            this.bt.Name = "bt";
            this.bt.Size = new System.Drawing.Size(75, 23);
            this.bt.TabIndex = 0;
            this.bt.Text = "test";
            this.bt.UseVisualStyleBackColor = true;
            this.bt.Click += new System.EventHandler(this.bt_Click);
            // 
            // tbIn
            // 
            this.tbIn.Location = new System.Drawing.Point(80, 35);
            this.tbIn.Name = "tbIn";
            this.tbIn.Size = new System.Drawing.Size(100, 20);
            this.tbIn.TabIndex = 1;
            // 
            // tbOut
            // 
            this.tbOut.Location = new System.Drawing.Point(80, 131);
            this.tbOut.Name = "tbOut";
            this.tbOut.Size = new System.Drawing.Size(100, 20);
            this.tbOut.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 199);
            this.Controls.Add(this.tbOut);
            this.Controls.Add(this.tbIn);
            this.Controls.Add(this.bt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt;
        private System.Windows.Forms.TextBox tbIn;
        private System.Windows.Forms.TextBox tbOut;
    }
}

