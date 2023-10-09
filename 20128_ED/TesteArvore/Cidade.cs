// Daniel Henry Matheus Imamura   RA: 20128

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteArvore
{
    class Cidade : IComparable<Cidade>
    {
        private int indiceCidade;
        private string nomeDaCidade;
        private bool estaAtivo;
        private bool foiVisitado;

        public Cidade(string nomeDaCidade, int indiceCidade)
        {           
            NomeDaCidade = nomeDaCidade;
            IndiceCidade = indiceCidade;
            EstaAtivo = true;
            FoiVisitado = false;
        }
        public Cidade() { }

        public Cidade(string nomeDaCidade)
        {
            NomeDaCidade = nomeDaCidade;
            IndiceCidade = -1;
                       
        }

        public int TamanhoRegistro => throw new NotImplementedException();

        public int IndiceCidade { get => indiceCidade; set => indiceCidade = value; }
        public string NomeDaCidade { get => nomeDaCidade; set => nomeDaCidade = value; }
        public bool EstaAtivo { get => estaAtivo; set => estaAtivo = value; }
        public bool FoiVisitado { get => foiVisitado; set => foiVisitado = value; }

        public int CompareTo(Cidade outro)
        {
            if (this.NomeDaCidade.CompareTo(outro.NomeDaCidade) == 0)
                return 0;
            else if (this.NomeDaCidade.CompareTo(outro.NomeDaCidade) < 0)
                return -1;
            else
                return 1;           
        }        
    }
}