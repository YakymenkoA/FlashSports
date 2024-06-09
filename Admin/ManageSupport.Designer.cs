namespace Admin
{
    partial class ManageSupport
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
            this.MainGB = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.IsBlockedCB = new System.Windows.Forms.CheckBox();
            this.MainGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainGB
            // 
            this.MainGB.Controls.Add(this.IsBlockedCB);
            this.MainGB.Controls.Add(this.label3);
            this.MainGB.Controls.Add(this.PasswordTB);
            this.MainGB.Controls.Add(this.label2);
            this.MainGB.Controls.Add(this.LoginTB);
            this.MainGB.Controls.Add(this.label1);
            this.MainGB.Controls.Add(this.NameTB);
            this.MainGB.Controls.Add(this.ClearBtn);
            this.MainGB.Controls.Add(this.SaveBtn);
            this.MainGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainGB.Location = new System.Drawing.Point(0, 0);
            this.MainGB.Margin = new System.Windows.Forms.Padding(4);
            this.MainGB.Name = "MainGB";
            this.MainGB.Padding = new System.Windows.Forms.Padding(4);
            this.MainGB.Size = new System.Drawing.Size(468, 365);
            this.MainGB.TabIndex = 0;
            this.MainGB.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password";
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(56, 179);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(358, 22);
            this.PasswordTB.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Login";
            // 
            // LoginTB
            // 
            this.LoginTB.Location = new System.Drawing.Point(56, 117);
            this.LoginTB.Name = "LoginTB";
            this.LoginTB.Size = new System.Drawing.Size(358, 22);
            this.LoginTB.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(56, 58);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(358, 22);
            this.NameTB.TabIndex = 5;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(261, 283);
            this.ClearBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(153, 46);
            this.ClearBtn.TabIndex = 4;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(56, 283);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(153, 46);
            this.SaveBtn.TabIndex = 3;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // IsBlockedCB
            // 
            this.IsBlockedCB.AutoSize = true;
            this.IsBlockedCB.Location = new System.Drawing.Point(56, 222);
            this.IsBlockedCB.Name = "IsBlockedCB";
            this.IsBlockedCB.Size = new System.Drawing.Size(76, 20);
            this.IsBlockedCB.TabIndex = 11;
            this.IsBlockedCB.Text = "Blocked";
            this.IsBlockedCB.UseVisualStyleBackColor = true;
            // 
            // ManageSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 365);
            this.Controls.Add(this.MainGB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ManageSupport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Support";
            this.MainGB.ResumeLayout(false);
            this.MainGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MainGB;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LoginTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.CheckBox IsBlockedCB;
    }
}