// Daniel Henry Matheus Imamura   RA: 20128

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace TesteArvore
{
    class Grafo
    {
        List<Cidade> cidades; // lista de cidades representado os vértices do grafo
        Caminho[,] adjMatrix; // matriz de caminho representando as arestas do grafo        
        Arvore<Cidade> arvore = null; 
        int numCidades; // equivalente a números de vértices

        /// DIJKSTRA
        Caminho[] percurso;
        int infinity = int.MaxValue;
        int verticeAtual; // global usada para indicar o vértice atualmente sendo visitado
        int doInicioAteAtual; // global usada para ajustar menor caminho com Djikstra
        int nTree;
        List<string> listaCaminho; // lista com o caminho de cidades no percurso encontrado

        public Grafo()
        {
            arvore = new Arvore<Cidade>();
            cidades = new List<Cidade>();            
            adjMatrix = new Caminho[53, 53]; // instanciado com a quantidade de cidades no arquivo original
            percurso = new Caminho[53];
            listaCaminho = new List<string>();
            numCidades = 0;
            nTree = 0;
            numCidades = 0;
        }
        public void DesenharCaminhos(Graphics g, int width, int height, string arquivoCidades)
        {
            string[] todasLinhas = File.ReadAllLines(arquivoCidades);
            SolidBrush preenchimento = new SolidBrush(Color.Blue);
            Pen caneta = new Pen(Color.Red);

            float x1 = 0, y1 = 0, x2 = 0, y2 = 0;
            bool origemJaExiste = false;
            
            for(int i = 0; i < listaCaminho.Count; i++) // pesquisa na lista de cidades do percurso final
            {
                foreach(string linha in todasLinhas)
                {
                    string nomeDaCidade = linha.Substring(0, 15).TrimStart().TrimEnd();

                    if (nomeDaCidade == listaCaminho[i] && origemJaExiste == false) // caso a cidade seja encontrada e seja a origem
                    {
                        // coordenadas da cidade
                        x1 = float.Parse(linha.Substring(16, 5).Replace(",", ".")); 
                        y1 = float.Parse(linha.Substring(22, 5).Replace(",", "."));
                        listaCaminho.Remove(listaCaminho[i]); // remove a cidade do percurso
                        i--; // decremento pois removeu uma cidade e os índices irão realocar
                        origemJaExiste = true;
                        break;
                    }

                    if (nomeDaCidade == listaCaminho[i] && origemJaExiste == true) // caso as cidades seguintes sejam encontradas após origem
                    {
                        // coordenadas da cidade
                        x2 = float.Parse(linha.Substring(16, 5).Replace(",", "."));
                        y2 = float.Parse(linha.Substring(22, 5).Replace(",", "."));                        
                        listaCaminho.Remove(listaCaminho[i]); // remove a cidade do percurso
                        i--; // decremento pois removeu uma cidade e os índices irão realocar
                        break;
                    }
                }
                if (x1 != 0 && y1 != 0 && x2 != 0 && y2 != 0)
                {
                    Point pt1 = new Point((int)(x1 * width), (int)(y1 * height)); // Cria o ponto da cidade 1
                    Point pt2 = new Point((int)(x2 * width), (int)(y2 * height)); // Cria o ponto da cidade 2
                    g.DrawLine(caneta, pt1, pt2);
                    x1 = x2;
                    y1 = y2;
                    x2 = 0;
                    y2 = 0;
                }
            }
        }
        public void LerCidades(string arquivoCidades, string arquivoCaminhos)
        {        
            string[] todasLinhas = File.ReadAllLines(arquivoCidades);         
            for (int j = 0; j < todasLinhas.Length; j++)
                for (int k = 0; k < todasLinhas.Length; k++)
                    adjMatrix[j, k] = new Caminho(infinity, infinity, infinity); 

            foreach (string linha in todasLinhas)
            {
                int fimDoNome = linha.IndexOf("0");
                string nomeDaCidade = linha.Substring(0, fimDoNome).TrimEnd(); // buscar nome das cidades
                NovoVertice(nomeDaCidade); 
            }

            todasLinhas = File.ReadAllLines(arquivoCaminhos);

            foreach (string linha in todasLinhas)
            {
                string origem = linha.Substring(0, 14).TrimEnd().TrimStart();
                string destino = linha.Substring(14, 15).TrimEnd().TrimStart();
                string distancia = linha.Substring(30, 4).TrimEnd().TrimStart();
                string preco = linha.Substring(35, 4).TrimEnd().TrimStart();

                for (int o = 0; o < numCidades; o++)
                {
                    if (cidades[o].NomeDaCidade == origem)
                    {
                        for (int d = 0; d < numCidades; d++)
                        {
                            if (cidades[d].NomeDaCidade == destino)
                            {
                                NovaAresta(o, d, int.Parse(distancia), int.Parse(preco));
                                NovaAresta(d, o, int.Parse(distancia), int.Parse(preco));
                            }
                        }
                    }
                }
            }

            percurso = new Caminho[numCidades];

        }
        public void NovoVertice(string nomeDaCidade)
        {
            Cidade cidade = new Cidade(nomeDaCidade);
            cidades.Add(cidade);
            numCidades++;           
        }
        public void NovaAresta(int inicio, int fim, int distancia, int preco)
        {
            adjMatrix[inicio, fim] = new Caminho(distancia, preco, -1); 
        }
        
        public string Caminho(int inicioDoPercurso, int finalDoPercurso, ListBox lista)
        {            
            for (int j = 0; j < numCidades; j++)
                cidades[j].FoiVisitado = false;

            cidades[inicioDoPercurso].FoiVisitado = true;
            for (int j = 0; j < numCidades; j++)
            {
                // anotamos no vetor percurso a distância entre o inicioDoPercurso e cada vértice
                // se não há ligação direta, o valor da distância será infinity
                Caminho tempDist = adjMatrix[inicioDoPercurso, j];
                percurso[j] = new Caminho(tempDist.Distancia, inicioDoPercurso);
            }

            for (int nTree = 0; nTree < numCidades; nTree++)
            {
                // Procuramos a saída não visitada do vértice inicioDoPercurso com a menor distância
                int indiceDoMenor = ObterMenor();

                // e anotamos essa menor distância
                int distanciaMinima = percurso[indiceDoMenor].Distancia;


                // o vértice com a menor distância passa a ser o vértice atual
                // para compararmos com a distância calculada em AjustarMenorCaminho()
                verticeAtual = indiceDoMenor;
                doInicioAteAtual = percurso[indiceDoMenor].Distancia;

                // visitamos o vértice com a menor distância desde o inicioDoPercurso
                cidades[verticeAtual].FoiVisitado = true;
                AjustarMenorCaminho(lista);
            }

            return ExibirPercursos(inicioDoPercurso, finalDoPercurso, lista);
        }

        public int ObterMenor()
        {
            int distanciaMinima = infinity;
            int indiceDaMinima = 0;
            for (int j = 0; j < numCidades; j++)
                if (!(cidades[j].FoiVisitado) && (percurso[j].Distancia < distanciaMinima))
                {
                    distanciaMinima = percurso[j].Distancia;
                    indiceDaMinima = j;
                }
            return indiceDaMinima;
        }
        
        public void AjustarMenorCaminho(ListBox lista)
        {
            for (int coluna = 0; coluna < numCidades; coluna++)
                if (!cidades[coluna].FoiVisitado)       // para cada vértice ainda não visitado
                {
                    // acessamos a distância desde o vértice atual (pode ser infinity)
                    Caminho atualAteMargem = adjMatrix[verticeAtual, coluna];

                    // calculamos a distância desde inicioDoPercurso passando por vertice atual até
                    // esta saída
                    int doInicioAteMargem = doInicioAteAtual + atualAteMargem.Distancia;

                    // quando encontra uma distância menor, marca o vértice a partir do
                    // qual chegamos no vértice de índice coluna, e a soma da distância
                    // percorrida para nele chegar
                    int distanciaDoCaminho = percurso[coluna].Distancia;                    

                    if (doInicioAteMargem < distanciaDoCaminho)
                    {
                        percurso[coluna].VerticePai = verticeAtual;
                        percurso[coluna].Distancia = doInicioAteMargem;                                             
                    }
                }           
        }
        

        public string ExibirPercursos(int inicioDoPercurso, int finalDoPercurso, ListBox lista)
        {
            string linha = "", resultado = "";
            for (int j = 0; j < numCidades; j++)
            {
                linha += cidades[j].NomeDaCidade + "=";
                if (percurso[j].Distancia == infinity)
                    linha += "inf";
                else
                    linha += percurso[j].Distancia;
                string pai = cidades[percurso[j].VerticePai].NomeDaCidade;
                linha += "(" + pai + ") ";
            }            
            lista.Items.Add("");
            lista.Items.Add("");
            lista.Items.Add("Caminho entre " + cidades[inicioDoPercurso].NomeDaCidade +
                                       " e " + cidades[finalDoPercurso].NomeDaCidade);
            
            listaCaminho.Add(cidades[inicioDoPercurso].NomeDaCidade);

            lista.Items.Add("");

            int onde = finalDoPercurso;
            Stack<string> pilha = new Stack<string>();

            int cont = 0;            
            while (onde != inicioDoPercurso)
            {
                onde = percurso[onde].VerticePai;
                pilha.Push(cidades[onde].NomeDaCidade);
                if (cidades[onde].NomeDaCidade != cidades[inicioDoPercurso].NomeDaCidade) // Adiciona cidade a lista de percurso
                {
                    listaCaminho.Add(cidades[onde].NomeDaCidade);                  
                }
                    
                cont++;
            }

            while (pilha.Count != 0)
            {
                resultado += pilha.Pop();
                if (pilha.Count != 0)
                    resultado += " --> ";
            }

            if ((cont == 1) && (percurso[finalDoPercurso].Distancia == infinity))
                resultado = "Não há caminho";
            else
            {                
                resultado += " --> " + cidades[finalDoPercurso].NomeDaCidade;
                listaCaminho.Add(cidades[finalDoPercurso].NomeDaCidade);
            }

            return resultado;
        }
    
    }
}