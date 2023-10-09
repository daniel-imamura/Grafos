// Daniel Henry Matheus Imamura   RA: 20128

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TesteArvore
{
    public partial class Form1 : Form
    {
        Arvore<Cidade> arvore = null;        
        Grafo oGrafo;
        Graphics g;
        string arquivoCidades = "";
        string arquivoCaminhos = "";
        string[] vetCidades = null;        
        public Form1()
        {
            InitializeComponent();
            arvore = new Arvore<Cidade>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dlgAbrir.Title = "Abrir arquivo de cidades";
            if(dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                arquivoCidades = dlgAbrir.FileName;
            }

            dlgAbrir.Title = "Abrir arquivo de caminhos";
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                arquivoCaminhos = dlgAbrir.FileName;
            }

            oGrafo = new Grafo();
            oGrafo.LerCidades(arquivoCidades, arquivoCaminhos);
            string[] linhasCaminhos = File.ReadAllLines(arquivoCaminhos);
            string[] linhasCidades = File.ReadAllLines(arquivoCidades);            

            Cidade cidade = new Cidade();            

            vetCidades = new string[linhasCidades.Length];

            int meioDoArquivo = linhasCidades.Length / 2; // busca o meio do arquivo para gerar árvore balanceada
            int primMetade = meioDoArquivo;

            for(int segMetade = meioDoArquivo; segMetade < linhasCidades.Length; segMetade++) // Leitura do arquivo texto a partir do meio
            {
                string nomeDaCidade = linhasCidades[segMetade].Substring(0, 15).TrimEnd(); // busca nome da cidade
                vetCidades[segMetade] = nomeDaCidade;
                cidade = new Cidade(nomeDaCidade, segMetade); // cidade da segunda metade do arquivo
                arvore.Incluir(cidade); // inclui cidade na árvore binária

                primMetade--;
                if (primMetade >= 0)
                {
                    nomeDaCidade = linhasCidades[primMetade].Substring(0, 15).TrimEnd(); 
                    vetCidades[primMetade] = nomeDaCidade;
                    cidade = new Cidade(nomeDaCidade, primMetade); // cidade da primeira metade do arquivo
                    arvore.Incluir(cidade);
                }                                    
            }
            
            this.Paint += picBoxMapa_Paint;           
            g = picBoxMapa.CreateGraphics();
        }

        private void btnAdicionarCidade_Click(object sender, EventArgs e)
        {
            if(txtCidade.Text != null)
            {
                Array.Resize(ref vetCidades, vetCidades.Length + 1); // Redimensiona vetor
                vetCidades[vetCidades.Length - 1] = txtCidade.Text.TrimStart().TrimEnd(); // insere cidade na última posição
                Cidade cidade = new Cidade(txtCidade.Text);
                arvore.Incluir(cidade); // inclui cidade
                MessageBox.Show("Cidade adicionada");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(txtCidade.Text != null)
            {                
                Cidade cidade = new Cidade(txtCidade.Text);
                if (arvore.Existe(cidade))
                {                                                          
                    bool encontrou = false;
                    if (arvore.Excluir(cidade) && arvore.ApagarNo(cidade)) 
                    {
                        MessageBox.Show("Cidade excluída!");
                        for(int i = 0; i < vetCidades.Length; i++) // Reorganização dos índices do vetor
                        {                            
                            if (vetCidades[i] == txtCidade.Text)
                                encontrou = true;
                            
                            if (encontrou && vetCidades.Length != i + 1)
                                vetCidades[i] = vetCidades[i + 1];
                        }
                    }
                    Array.Resize(ref vetCidades, vetCidades.Length - 1); // Redimensiona vetor                
                }
            }            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lsbSaida.Items.Clear();

            int origem = -1;
            int destino = -1;
            for(int i=0; i < vetCidades.Length; i++) // busca o indice da cidade a partir do nome
            {
                if (txtOrigem.Text == vetCidades[i])
                    origem = i;
                if (txtDestino.Text == vetCidades[i])
                    destino = i;
            }

            if (origem == -1 || destino == -1)
                MessageBox.Show("Cidades não encontradas!");
            else
            {
                lsbSaida.Items.Add(oGrafo.Caminho(origem, destino, lsbSaida));
                lsbSaida.Items.Add("");
                this.Invalidate(); // Redesenha na tela
            }                     
        }

        private void picBoxMapa_Paint(object sender, PaintEventArgs e)
        {           
            oGrafo.DesenharCaminhos(g, picBoxMapa.Width, picBoxMapa.Height, "C:\\temp\\Cidades.txt");                            
        }
    }
}
