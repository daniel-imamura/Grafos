
namespace TesteArvore
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picBoxMapa = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrigem = new System.Windows.Forms.TextBox();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAdicionarCidade = new System.Windows.Forms.Button();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdicionarCaminho = new System.Windows.Forms.Button();
            this.lsbSaida = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMapa)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxMapa
            // 
            this.picBoxMapa.Image = global::TesteArvore.Properties.Resources.mapaEspanhaPortugal;
            this.picBoxMapa.InitialImage = ((System.Drawing.Image)(resources.GetObject("picBoxMapa.InitialImage")));
            this.picBoxMapa.Location = new System.Drawing.Point(72, 161);
            this.picBoxMapa.Margin = new System.Windows.Forms.Padding(4);
            this.picBoxMapa.Name = "picBoxMapa";
            this.picBoxMapa.Size = new System.Drawing.Size(717, 578);
            this.picBoxMapa.TabIndex = 1;
            this.picBoxMapa.TabStop = false;
            this.picBoxMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoxMapa_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "De:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Para:";
            // 
            // txtOrigem
            // 
            this.txtOrigem.Location = new System.Drawing.Point(94, 30);
            this.txtOrigem.Margin = new System.Windows.Forms.Padding(4);
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(132, 23);
            this.txtOrigem.TabIndex = 4;
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(316, 30);
            this.txtDestino.Margin = new System.Windows.Forms.Padding(4);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(132, 23);
            this.txtDestino.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(480, 15);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 34);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAdicionarCidade
            // 
            this.btnAdicionarCidade.Location = new System.Drawing.Point(1053, 15);
            this.btnAdicionarCidade.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdicionarCidade.Name = "btnAdicionarCidade";
            this.btnAdicionarCidade.Size = new System.Drawing.Size(103, 34);
            this.btnAdicionarCidade.TabIndex = 7;
            this.btnAdicionarCidade.Text = "Adicionar ";
            this.btnAdicionarCidade.UseVisualStyleBackColor = true;
            this.btnAdicionarCidade.Click += new System.EventHandler(this.btnAdicionarCidade_Click);
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(749, 37);
            this.txtCidade.Margin = new System.Windows.Forms.Padding(4);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(276, 23);
            this.txtCidade.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 39);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cidade:";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(1053, 57);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(103, 33);
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.Text = "Excluir ";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(860, 187);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Resultados";
            // 
            // btnAdicionarCaminho
            // 
            this.btnAdicionarCaminho.Location = new System.Drawing.Point(480, 57);
            this.btnAdicionarCaminho.Name = "btnAdicionarCaminho";
            this.btnAdicionarCaminho.Size = new System.Drawing.Size(100, 44);
            this.btnAdicionarCaminho.TabIndex = 13;
            this.btnAdicionarCaminho.Text = "Adicionar Caminho";
            this.btnAdicionarCaminho.UseVisualStyleBackColor = true;
            // 
            // lsbSaida
            // 
            this.lsbSaida.FormattingEnabled = true;
            this.lsbSaida.ItemHeight = 16;
            this.lsbSaida.Location = new System.Drawing.Point(863, 222);
            this.lsbSaida.Name = "lsbSaida";
            this.lsbSaida.Size = new System.Drawing.Size(309, 436);
            this.lsbSaida.TabIndex = 15;
            // 
            // dlgAbrir
            // 
            this.dlgAbrir.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 948);
            this.Controls.Add(this.lsbSaida);
            this.Controls.Add(this.btnAdicionarCaminho);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.btnAdicionarCidade);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.txtOrigem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picBoxMapa);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picBoxMapa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrigem;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAdicionarCidade;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdicionarCaminho;
        private System.Windows.Forms.ListBox lsbSaida;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog dlgAbrir;
    }
}

