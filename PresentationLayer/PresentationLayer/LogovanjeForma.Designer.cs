namespace PresentationLayer
{
    partial class LogovanjeForma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogovanjeForma));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUnosLozinke = new System.Windows.Forms.TextBox();
            this.buttonPrijaviSeLogovanjeForma = new System.Windows.Forms.Button();
            this.textBoxUnosKorisnickogImena = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOGOVANJE U APLIKACIJU";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Korisničko ime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lozinka";
            // 
            // textBoxUnosLozinke
            // 
            this.textBoxUnosLozinke.Location = new System.Drawing.Point(169, 231);
            this.textBoxUnosLozinke.Multiline = true;
            this.textBoxUnosLozinke.Name = "textBoxUnosLozinke";
            this.textBoxUnosLozinke.Size = new System.Drawing.Size(164, 30);
            this.textBoxUnosLozinke.TabIndex = 4;
            // 
            // buttonPrijaviSeLogovanjeForma
            // 
            this.buttonPrijaviSeLogovanjeForma.Location = new System.Drawing.Point(169, 290);
            this.buttonPrijaviSeLogovanjeForma.Name = "buttonPrijaviSeLogovanjeForma";
            this.buttonPrijaviSeLogovanjeForma.Size = new System.Drawing.Size(164, 35);
            this.buttonPrijaviSeLogovanjeForma.TabIndex = 5;
            this.buttonPrijaviSeLogovanjeForma.Text = "Prijavi se";
            this.buttonPrijaviSeLogovanjeForma.UseVisualStyleBackColor = true;
            this.buttonPrijaviSeLogovanjeForma.Click += new System.EventHandler(this.buttonPrijaviSeLogovanjeForma_Click);
            // 
            // textBoxUnosKorisnickogImena
            // 
            this.textBoxUnosKorisnickogImena.Location = new System.Drawing.Point(169, 174);
            this.textBoxUnosKorisnickogImena.Multiline = true;
            this.textBoxUnosKorisnickogImena.Name = "textBoxUnosKorisnickogImena";
            this.textBoxUnosKorisnickogImena.Size = new System.Drawing.Size(164, 30);
            this.textBoxUnosKorisnickogImena.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(217, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LogovanjeForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 376);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxUnosKorisnickogImena);
            this.Controls.Add(this.buttonPrijaviSeLogovanjeForma);
            this.Controls.Add(this.textBoxUnosLozinke);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "LogovanjeForma";
            this.Text = "Logovanje Forma";
            this.Load += new System.EventHandler(this.LogovanjeForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUnosLozinke;
        private System.Windows.Forms.Button buttonPrijaviSeLogovanjeForma;
        private System.Windows.Forms.TextBox textBoxUnosKorisnickogImena;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

