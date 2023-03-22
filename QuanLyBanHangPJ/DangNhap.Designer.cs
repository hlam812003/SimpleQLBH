namespace QuanLyBanHangPJ
{
    partial class DangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DangNhapInput = new System.Windows.Forms.TextBox();
            this.MatKhauInput = new System.Windows.Forms.TextBox();
            this.dangNhap_btn = new System.Windows.Forms.Button();
            this.xoa_btn = new System.Windows.Forms.Button();
            this.huy_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(68, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Đăng Nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(68, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật Khẩu";
            // 
            // DangNhapInput
            // 
            this.DangNhapInput.Location = new System.Drawing.Point(330, 63);
            this.DangNhapInput.MinimumSize = new System.Drawing.Size(277, 35);
            this.DangNhapInput.Name = "DangNhapInput";
            this.DangNhapInput.Size = new System.Drawing.Size(277, 35);
            this.DangNhapInput.TabIndex = 3;
            this.DangNhapInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MatKhauInput
            // 
            this.MatKhauInput.Location = new System.Drawing.Point(330, 160);
            this.MatKhauInput.MinimumSize = new System.Drawing.Size(277, 35);
            this.MatKhauInput.Name = "MatKhauInput";
            this.MatKhauInput.Size = new System.Drawing.Size(277, 35);
            this.MatKhauInput.TabIndex = 3;
            this.MatKhauInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MatKhauInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MatKhauInput_KeyPress);
            // 
            // dangNhap_btn
            // 
            this.dangNhap_btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dangNhap_btn.Location = new System.Drawing.Point(68, 285);
            this.dangNhap_btn.Name = "dangNhap_btn";
            this.dangNhap_btn.Size = new System.Drawing.Size(133, 51);
            this.dangNhap_btn.TabIndex = 4;
            this.dangNhap_btn.Text = "Đăng Nhập";
            this.dangNhap_btn.UseVisualStyleBackColor = true;
            this.dangNhap_btn.Click += new System.EventHandler(this.dangNhap_btn_Click);
            // 
            // xoa_btn
            // 
            this.xoa_btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.xoa_btn.Location = new System.Drawing.Point(271, 285);
            this.xoa_btn.Name = "xoa_btn";
            this.xoa_btn.Size = new System.Drawing.Size(133, 51);
            this.xoa_btn.TabIndex = 5;
            this.xoa_btn.Text = "Xóa";
            this.xoa_btn.UseVisualStyleBackColor = true;
            this.xoa_btn.Click += new System.EventHandler(this.xoa_btn_Click);
            // 
            // huy_btn
            // 
            this.huy_btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.huy_btn.Location = new System.Drawing.Point(474, 285);
            this.huy_btn.Name = "huy_btn";
            this.huy_btn.Size = new System.Drawing.Size(133, 51);
            this.huy_btn.TabIndex = 6;
            this.huy_btn.Text = "Hủy";
            this.huy_btn.UseVisualStyleBackColor = true;
            this.huy_btn.Click += new System.EventHandler(this.huy_btn_Click);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 405);
            this.Controls.Add(this.huy_btn);
            this.Controls.Add(this.xoa_btn);
            this.Controls.Add(this.dangNhap_btn);
            this.Controls.Add(this.MatKhauInput);
            this.Controls.Add(this.DangNhapInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DangNhap";
            this.Text = "Đăng Nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox DangNhapInput;
        private TextBox MatKhauInput;
        private Button dangNhap_btn;
        private Button xoa_btn;
        private Button huy_btn;
    }
}