
namespace Veritabanı_Veri_Aktarımı
{
    partial class kaydetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kaydetForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.veritabaniAdi = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.sifreBox = new System.Windows.Forms.TextBox();
            this.kullaniciAdiBox = new System.Windows.Forms.TextBox();
            this.sunucuAdresiBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.sifreBox);
            this.groupBox1.Controls.Add(this.kullaniciAdiBox);
            this.groupBox1.Controls.Add(this.sunucuAdresiBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 228);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kaydedilecek Veriler";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(614, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Veritabanı adı:";
            // 
            // veritabaniAdi
            // 
            this.veritabaniAdi.Location = new System.Drawing.Point(722, 200);
            this.veritabaniAdi.Name = "veritabaniAdi";
            this.veritabaniAdi.Size = new System.Drawing.Size(148, 20);
            this.veritabaniAdi.TabIndex = 7;
            this.veritabaniAdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(42, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(247, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sifreBox
            // 
            this.sifreBox.Location = new System.Drawing.Point(141, 127);
            this.sifreBox.Name = "sifreBox";
            this.sifreBox.PasswordChar = '*';
            this.sifreBox.Size = new System.Drawing.Size(148, 23);
            this.sifreBox.TabIndex = 6;
            this.sifreBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kullaniciAdiBox
            // 
            this.kullaniciAdiBox.Location = new System.Drawing.Point(141, 90);
            this.kullaniciAdiBox.Name = "kullaniciAdiBox";
            this.kullaniciAdiBox.Size = new System.Drawing.Size(148, 23);
            this.kullaniciAdiBox.TabIndex = 5;
            this.kullaniciAdiBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // sunucuAdresiBox
            // 
            this.sunucuAdresiBox.Location = new System.Drawing.Point(141, 53);
            this.sunucuAdresiBox.Name = "sunucuAdresiBox";
            this.sunucuAdresiBox.Size = new System.Drawing.Size(148, 23);
            this.sunucuAdresiBox.TabIndex = 4;
            this.sunucuAdresiBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parola ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kullanıcı Adı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sunucu Adresi";
            // 
            // kaydetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(353, 253);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.veritabaniAdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "kaydetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kaydet";
            this.Load += new System.EventHandler(this.kaydetForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox sifreBox;
        private System.Windows.Forms.TextBox kullaniciAdiBox;
        private System.Windows.Forms.TextBox sunucuAdresiBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox veritabaniAdi;
    }
}