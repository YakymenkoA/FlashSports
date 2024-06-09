namespace Support
{
    partial class ClientChat
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
            this.ChatGB = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.MessageGB = new System.Windows.Forms.GroupBox();
            this.MessageTB = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.ChatGB.SuspendLayout();
            this.MessageGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChatGB
            // 
            this.ChatGB.Controls.Add(this.MessageGB);
            this.ChatGB.Controls.Add(this.textBox1);
            this.ChatGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatGB.Location = new System.Drawing.Point(0, 0);
            this.ChatGB.Name = "ChatGB";
            this.ChatGB.Size = new System.Drawing.Size(453, 777);
            this.ChatGB.TabIndex = 0;
            this.ChatGB.TabStop = false;
            this.ChatGB.Text = "Chat with {UserName}:";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(3, 18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(447, 580);
            this.textBox1.TabIndex = 0;
            // 
            // MessageGB
            // 
            this.MessageGB.Controls.Add(this.ClearBtn);
            this.MessageGB.Controls.Add(this.SendBtn);
            this.MessageGB.Controls.Add(this.MessageTB);
            this.MessageGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageGB.Location = new System.Drawing.Point(3, 598);
            this.MessageGB.Name = "MessageGB";
            this.MessageGB.Size = new System.Drawing.Size(447, 176);
            this.MessageGB.TabIndex = 1;
            this.MessageGB.TabStop = false;
            this.MessageGB.Text = "Your Message :";
            // 
            // MessageTB
            // 
            this.MessageTB.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageTB.Location = new System.Drawing.Point(3, 18);
            this.MessageTB.Multiline = true;
            this.MessageTB.Name = "MessageTB";
            this.MessageTB.Size = new System.Drawing.Size(441, 99);
            this.MessageTB.TabIndex = 0;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(58, 123);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(136, 43);
            this.SendBtn.TabIndex = 3;
            this.SendBtn.Text = "Send Message";
            this.SendBtn.UseVisualStyleBackColor = true;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(242, 123);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(136, 43);
            this.ClearBtn.TabIndex = 4;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            // 
            // ClientChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 777);
            this.Controls.Add(this.ChatGB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ClientChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Chat";
            this.ChatGB.ResumeLayout(false);
            this.ChatGB.PerformLayout();
            this.MessageGB.ResumeLayout(false);
            this.MessageGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ChatGB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox MessageGB;
        private System.Windows.Forms.TextBox MessageTB;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Button ClearBtn;
    }
}