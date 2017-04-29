namespace BuscaA
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_Tempo = new System.Windows.Forms.Label();
            this.lbl_Tempo = new System.Windows.Forms.Label();
            this.Iniciar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.p9 = new System.Windows.Forms.PictureBox();
            this.p6 = new System.Windows.Forms.PictureBox();
            this.p3 = new System.Windows.Forms.PictureBox();
            this.p8 = new System.Windows.Forms.PictureBox();
            this.p7 = new System.Windows.Forms.PictureBox();
            this.p5 = new System.Windows.Forms.PictureBox();
            this.p4 = new System.Windows.Forms.PictureBox();
            this.p2 = new System.Windows.Forms.PictureBox();
            this.p1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.p9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_Tempo
            // 
            this.txt_Tempo.AutoSize = true;
            this.txt_Tempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_Tempo.Location = new System.Drawing.Point(26, 30);
            this.txt_Tempo.Name = "txt_Tempo";
            this.txt_Tempo.Size = new System.Drawing.Size(125, 20);
            this.txt_Tempo.TabIndex = 0;
            this.txt_Tempo.Text = "Tempo restante:";
            // 
            // lbl_Tempo
            // 
            this.lbl_Tempo.AutoSize = true;
            this.lbl_Tempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_Tempo.Location = new System.Drawing.Point(155, 31);
            this.lbl_Tempo.Name = "lbl_Tempo";
            this.lbl_Tempo.Size = new System.Drawing.Size(0, 20);
            this.lbl_Tempo.TabIndex = 1;
            // 
            // Iniciar
            // 
            this.Iniciar.Location = new System.Drawing.Point(298, 471);
            this.Iniciar.Name = "Iniciar";
            this.Iniciar.Size = new System.Drawing.Size(75, 23);
            this.Iniciar.TabIndex = 2;
            this.Iniciar.Text = "Iniciar";
            this.Iniciar.UseVisualStyleBackColor = true;
            this.Iniciar.Click += new System.EventHandler(this.Iniciar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 54);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(657, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // p9
            // 
            this.p9.Location = new System.Drawing.Point(443, 339);
            this.p9.Name = "p9";
            this.p9.Size = new System.Drawing.Size(203, 122);
            this.p9.TabIndex = 24;
            this.p9.TabStop = false;
            // 
            // p6
            // 
            this.p6.Location = new System.Drawing.Point(443, 214);
            this.p6.Name = "p6";
            this.p6.Size = new System.Drawing.Size(203, 122);
            this.p6.TabIndex = 23;
            this.p6.TabStop = false;
            // 
            // p3
            // 
            this.p3.Location = new System.Drawing.Point(443, 88);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(203, 122);
            this.p3.TabIndex = 22;
            this.p3.TabStop = false;
            // 
            // p8
            // 
            this.p8.Location = new System.Drawing.Point(237, 339);
            this.p8.Name = "p8";
            this.p8.Size = new System.Drawing.Size(203, 122);
            this.p8.TabIndex = 21;
            this.p8.TabStop = false;
            // 
            // p7
            // 
            this.p7.Location = new System.Drawing.Point(31, 339);
            this.p7.Name = "p7";
            this.p7.Size = new System.Drawing.Size(203, 122);
            this.p7.TabIndex = 20;
            this.p7.TabStop = false;
            // 
            // p5
            // 
            this.p5.Location = new System.Drawing.Point(237, 213);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(203, 122);
            this.p5.TabIndex = 19;
            this.p5.TabStop = false;
            // 
            // p4
            // 
            this.p4.Location = new System.Drawing.Point(31, 213);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(203, 122);
            this.p4.TabIndex = 18;
            this.p4.TabStop = false;
            // 
            // p2
            // 
            this.p2.Location = new System.Drawing.Point(237, 88);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(203, 122);
            this.p2.TabIndex = 17;
            this.p2.TabStop = false;
            // 
            // p1
            // 
            this.p1.Location = new System.Drawing.Point(31, 88);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(203, 122);
            this.p1.TabIndex = 16;
            this.p1.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "H1",
            "H2",
            "H3"});
            this.comboBox1.Location = new System.Drawing.Point(601, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(68, 21);
            this.comboBox1.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 506);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.p9);
            this.Controls.Add(this.p6);
            this.Controls.Add(this.p3);
            this.Controls.Add(this.p8);
            this.Controls.Add(this.p7);
            this.Controls.Add(this.p5);
            this.Controls.Add(this.p4);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Iniciar);
            this.Controls.Add(this.lbl_Tempo);
            this.Controls.Add(this.txt_Tempo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "8-Puzzle";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label txt_Tempo;
        private System.Windows.Forms.Label lbl_Tempo;
        private System.Windows.Forms.Button Iniciar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox p9;
        private System.Windows.Forms.PictureBox p6;
        private System.Windows.Forms.PictureBox p3;
        private System.Windows.Forms.PictureBox p8;
        private System.Windows.Forms.PictureBox p7;
        private System.Windows.Forms.PictureBox p5;
        private System.Windows.Forms.PictureBox p4;
        private System.Windows.Forms.PictureBox p2;
        private System.Windows.Forms.PictureBox p1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

