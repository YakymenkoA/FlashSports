namespace Client
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.ClientAvatar = new System.Windows.Forms.PictureBox();
            this.CandyAmount = new System.Windows.Forms.Label();
            this.CandyIcon = new System.Windows.Forms.PictureBox();
            this.MainGB = new System.Windows.Forms.GroupBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EmailTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.AddCandyBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ClientAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CandyIcon)).BeginInit();
            this.MainGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientAvatar
            // 
            this.ClientAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientAvatar.Location = new System.Drawing.Point(7, 18);
            this.ClientAvatar.Margin = new System.Windows.Forms.Padding(4);
            this.ClientAvatar.Name = "ClientAvatar";
            this.ClientAvatar.Size = new System.Drawing.Size(344, 343);
            this.ClientAvatar.TabIndex = 0;
            this.ClientAvatar.TabStop = false;
            this.ClientAvatar.Click += new System.EventHandler(this.ClientAvatar_Click);
            // 
            // CandyAmount
            // 
            this.CandyAmount.AutoSize = true;
            this.CandyAmount.Location = new System.Drawing.Point(573, 26);
            this.CandyAmount.Name = "CandyAmount";
            this.CandyAmount.Size = new System.Drawing.Size(127, 16);
            this.CandyAmount.TabIndex = 5;
            this.CandyAmount.Text = "{Amount of candies}";
            // 
            // CandyIcon
            // 
            this.CandyIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CandyIcon.BackgroundImage")));
            this.CandyIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CandyIcon.Location = new System.Drawing.Point(534, 18);
            this.CandyIcon.Name = "CandyIcon";
            this.CandyIcon.Size = new System.Drawing.Size(33, 33);
            this.CandyIcon.TabIndex = 4;
            this.CandyIcon.TabStop = false;
            // 
            // MainGB
            // 
            this.MainGB.Controls.Add(this.PasswordTB);
            this.MainGB.Controls.Add(this.label3);
            this.MainGB.Controls.Add(this.EmailTB);
            this.MainGB.Controls.Add(this.label2);
            this.MainGB.Controls.Add(this.NameTB);
            this.MainGB.Controls.Add(this.label1);
            this.MainGB.Controls.Add(this.CloseBtn);
            this.MainGB.Controls.Add(this.SaveBtn);
            this.MainGB.Controls.Add(this.AddCandyBtn);
            this.MainGB.Controls.Add(this.ClientAvatar);
            this.MainGB.Controls.Add(this.CandyAmount);
            this.MainGB.Controls.Add(this.CandyIcon);
            this.MainGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGB.Location = new System.Drawing.Point(0, 0);
            this.MainGB.Name = "MainGB";
            this.MainGB.Size = new System.Drawing.Size(710, 516);
            this.MainGB.TabIndex = 6;
            this.MainGB.TabStop = false;
            // 
            // PasswordTB
            // 
            this.PasswordTB.Location = new System.Drawing.Point(376, 257);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(309, 22);
            this.PasswordTB.TabIndex = 14;
            this.PasswordTB.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Password:";
            // 
            // EmailTB
            // 
            this.EmailTB.Location = new System.Drawing.Point(376, 202);
            this.EmailTB.Name = "EmailTB";
            this.EmailTB.Size = new System.Drawing.Size(309, 22);
            this.EmailTB.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Email:";
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(376, 149);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(309, 22);
            this.NameTB.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name:";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(417, 440);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(175, 64);
            this.CloseBtn.TabIndex = 8;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(176, 440);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(175, 64);
            this.SaveBtn.TabIndex = 7;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // AddCandyBtn
            // 
            this.AddCandyBtn.Location = new System.Drawing.Point(534, 57);
            this.AddCandyBtn.Name = "AddCandyBtn";
            this.AddCandyBtn.Size = new System.Drawing.Size(162, 35);
            this.AddCandyBtn.TabIndex = 6;
            this.AddCandyBtn.Text = "Add More Candies";
            this.AddCandyBtn.UseVisualStyleBackColor = true;
            this.AddCandyBtn.Click += new System.EventHandler(this.AddCandyBtn_Click);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 516);
            this.Controls.Add(this.MainGB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Profile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Profile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ClientAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CandyIcon)).EndInit();
            this.MainGB.ResumeLayout(false);
            this.MainGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ClientAvatar;
        private System.Windows.Forms.Label CandyAmount;
        private System.Windows.Forms.PictureBox CandyIcon;
        private System.Windows.Forms.GroupBox MainGB;
        private System.Windows.Forms.Button AddCandyBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EmailTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.Label label1;
    }
}