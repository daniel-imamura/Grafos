// Daniel Henry Matheus Imamura   RA: 20128

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteArvore
{
    class Caminho
    {
        private int distancia;
        private int preco;
        private int verticePai;
        public Caminho(int distancia, int preco, int verticePai)
        {
            Distancia = distancia;
            Preco = preco;
            VerticePai = verticePai; 
        }
       

        public Caminho(int distancia, int verticePai)
        {
            Distancia = distancia;
            VerticePai = verticePai;
        }

        public int Distancia { get => distancia; set => distancia = value; }
        public int Preco { get => preco; set => preco = value; }
        public int VerticePai { get => verticePai; set => verticePai = value; }
    }
}
