namespace QuanLi100
{
    partial class Formtim
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxtim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewtim = new System.Windows.Forms.DataGridView();
            this.buttonve = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewtim)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(795, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxtim
            // 
            this.textBoxtim.Location = new System.Drawing.Point(507, 192);
            this.textBoxtim.Name = "textBoxtim";
            this.textBoxtim.Size = new System.Drawing.Size(271, 22);
            this.textBoxtim.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "TÌm kiếm thông tin";
            // 
            // dataGridViewtim
            // 
            this.dataGridViewtim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewtim.Location = new System.Drawing.Point(1, 220);
            this.dataGridViewtim.Name = "dataGridViewtim";
            this.dataGridViewtim.RowHeadersWidth = 51;
            this.dataGridViewtim.RowTemplate.Height = 24;
            this.dataGridViewtim.Size = new System.Drawing.Size(891, 363);
            this.dataGridViewtim.TabIndex = 3;
            // 
            // buttonve
            // 
            this.buttonve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonve.Location = new System.Drawing.Point(723, 12);
            this.buttonve.Name = "buttonve";
            this.buttonve.Size = new System.Drawing.Size(147, 31);
            this.buttonve.TabIndex = 4;
            this.buttonve.Text = "Về đăng nhập";
            this.buttonve.UseVisualStyleBackColor = false;
            this.buttonve.Click += new System.EventHandler(this.buttonve_Click);
            // 
            // Formtim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(893, 584);
            this.Controls.Add(this.buttonve);
            this.Controls.Add(this.dataGridViewtim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxtim);
            this.Controls.Add(this.button1);
            this.Name = "Formtim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TÌm thông tin sách";
            this.Load += new System.EventHandler(this.Formtim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewtim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxtim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewtim;
        private System.Windows.Forms.Button buttonve;
    }
}