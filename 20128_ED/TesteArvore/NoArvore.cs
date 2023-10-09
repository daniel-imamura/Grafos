// Daniel Henry Matheus Imamura   RA: 20128

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TesteArvore
{
    class NoArvore<Dado> : IComparable<NoArvore<Dado>> where Dado : IComparable<Dado>
    {        
        Dado info;
        NoArvore<Dado> esquerdo, direito;

        public Dado Info 
        {
            get => info;
            set => info = value;
        }

        public NoArvore(Dado informacao)
        {
            this.Info = informacao;
            this.Esquerdo = null;
            this.Direito = null;
        }
        public NoArvore()
        {
            
        }
       
        public int CompareTo(NoArvore<Dado> outro)
        {
            return this.Info.CompareTo(outro.Info);
        }

        public bool Equals(NoArvore<Dado> outro)
        {
            return this.Info.Equals(outro.Info);
        }

        public NoArvore<Dado> Esquerdo { get => esquerdo; set => esquerdo = value; }
        public NoArvore<Dado> Direito { get => direito; set => direito = value; }       
    }
}
