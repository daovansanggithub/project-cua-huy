namespace QuanLi100
{
    partial class Formdangnhap
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
            this.textBoxTK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btndn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxTK
            // 
            this.textBoxTK.Location = new System.Drawing.Point(192, 111);
            this.textBoxTK.Name = "textBoxTK";
            this.textBoxTK.Size = new System.Drawing.Size(265, 22);
            this.textBoxTK.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tài Khoản";
            // 
            // btndn
            // 
            this.btndn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btndn.Location = new System.Drawing.Point(245, 228);
            this.btndn.Name = "btndn";
            this.btndn.Size = new System.Drawing.Size(97, 53);
            this.btndn.TabIndex = 2;
            this.btndn.Text = "Đăng Nhập";
            this.btndn.UseVisualStyleBackColor = false;
            this.btndn.Click += new System.EventHandler(this.btndn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mật Khẩu";
            // 
            // textBoxMK
            // 
            this.textBoxMK.Location = new System.Drawing.Point(192, 186);
            this.textBoxMK.Name = "textBoxMK";
            this.textBoxMK.Size = new System.Drawing.Size(265, 22);
            this.textBoxMK.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "tài khoản : admin / user\r\nmật khâu: matkhau_admin / user";
            // 
            // Formdangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(527, 353);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMK);
            this.Controls.Add(this.btndn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTK);
            this.Name = "Formdangnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập phần mềm";
            this.Load += new System.EventHandler(this.Formdangnhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btndn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMK;
        private System.Windows.Forms.Label label3;
    }
}

