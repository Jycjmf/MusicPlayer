namespace MusicPlayer
{
    partial class FormLrc
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
            this.LabelLrc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelLrc
            // 
            this.LabelLrc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelLrc.ForeColor = System.Drawing.Color.White;
            this.LabelLrc.Location = new System.Drawing.Point(12, 9);
            this.LabelLrc.Name = "LabelLrc";
            this.LabelLrc.Size = new System.Drawing.Size(294, 30);
            this.LabelLrc.TabIndex = 1;
            this.LabelLrc.Text = "label1";
            // 
            // FormLrc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(318, 48);
            this.ControlBox = false;
            this.Controls.Add(this.LabelLrc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLrc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FormLrc";
            this.Load += new System.EventHandler(this.FormLrc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelLrc;
    }
}