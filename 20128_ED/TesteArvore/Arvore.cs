// Daniel Henry Matheus Imamura   RA: 20128

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace TesteArvore
{
    class Arvore<Dado> where Dado : IComparable<Dado>, new()
    {        
        NoArvore<Dado> raiz, atual, antecessor;        
        public Arvore()
        {
            raiz = null;
            atual = antecessor = null;            
        }        
       
        public void Incluir(Dado dado)
        {
            IncluirNovoRegistro(dado); // chama o método privado
        }

        private void IncluirNovoRegistro(Dado novoRegistro)
        {
            if (Existe(novoRegistro))
                MessageBox.Show("[Erro] Cidade já existente");
            else
            {
                // o novoRegistro tem uma chave inexistente, então criamos 
                // um novo nó para armazená-lo e depois ligamos esse nó na
                // árvore
                var novoNo = new NoArvore<Dado>(novoRegistro);

                // se a árvore está vazia, a raiz passará a apontar esse novo nó
                if (raiz == null)
                    raiz = novoNo;
                else
                  // nesse caso, antecessor aponta o pai do novo registro e
                  // verificamos em qual ramo o novo nó será ligado
                  if (novoRegistro.CompareTo(antecessor.Info) < 0)  // novo é menor que antecessor 
                    antecessor.Esquerdo = novoNo;        // vamos para a esquerda
                else
                    antecessor.Direito = novoNo;		 // ou vamos para a direita

            }
        }
        public bool Existe(Dado procurado)
        {
            antecessor = null;
            atual = raiz;
            while (atual != null)
            {
                if (atual.Info.CompareTo(procurado) == 0) // atual aponta o nó com o registro procurado, antecessor aponta seu "pai"
                    return true;

                antecessor = atual;
                if (procurado.CompareTo(atual.Info) < 0)
                    atual = atual.Esquerdo;     // Desloca apontador para o ramo à esquerda
                else
                    atual = atual.Direito;     // Desloca apontador para o ramo à direita
            }
            return false;       // Se local == null, a chave não existe
        }
       
     
        private int QtosNos(NoArvore<Dado> noAtual)
        {
            if (noAtual == null)  // árvore vazia ou descendente de folha
                return 0;

            return 1 +                 // conta o nó atual
                QtosNos(noAtual.Esquerdo) + // conta nós da subárvore esquerda
                QtosNos(noAtual.Direito);  // conta nós da subárvore direita
        }
        
        public int QtosNos()
        {
            return QtosNos(raiz); // chama método privado
        }

        public bool Excluir(Dado procurado)
        {
            return Excluir(ref raiz);


            bool Excluir(ref NoArvore<Dado> atual)
            {
                NoArvore<Dado> atualAnt;
                if (atual == null)
                    return false;
                else
                  if (atual.Info.CompareTo(procurado) > 0)
                {
                    var temp = atual.Esquerdo;
                    bool result = Excluir(ref temp);
                    atual.Esquerdo = temp;
                    return result;
                }
                else
                    if (atual.Info.CompareTo(procurado) < 0)
                {
                    var temp = atual.Direito;
                    bool result = Excluir(ref temp);
                    atual.Esquerdo = temp;
                    return result;
                }
                else
                {
                    atualAnt = atual;   // nó a retirar 
                    if (atual.Direito == null)
                        atual = atual.Esquerdo;
                    else
                      if (atual.Esquerdo == null)
                        atual = atual.Direito;
                    else
                    {   // pai de 2 filhos 
                        var temp = atual.Esquerdo;
                        Rearranjar(ref temp, ref atualAnt);
                        atual.Esquerdo = temp;
                        atualAnt = null;  // libera o nó excluído
                    }
                    return true;
                    }
            }

            void Rearranjar(ref NoArvore<Dado> aux, ref NoArvore<Dado> atualAnt)
            {
                if (aux.Direito != null)
                {
                    NoArvore<Dado> temp = aux.Direito;
                    Rearranjar(ref temp, ref atualAnt);  // Procura Maior
                    aux.Direito = temp;
                }
                else
                {                           // Guarda os dados do nó a excluir
                    atualAnt.Info = aux.Info;   // troca conteúdo!
                    atualAnt = aux;             // funciona com a passagem por referência
                    aux = aux.Esquerdo;
                }
            }

        }

        public bool ApagarNo(Dado registroARemover)
        {
            atual = raiz;
            antecessor = null;
            bool ehFilhoEsquerdo = true;
            while (atual.Info.CompareTo(registroARemover) != 0)  // enqto não acha a chave a remover
            {
                antecessor = atual;
                if (atual.Info.CompareTo(registroARemover) > 0)
                {
                    ehFilhoEsquerdo = true;
                    atual = atual.Esquerdo;
                }
                else
                {
                    ehFilhoEsquerdo = false;
                    atual = atual.Direito;
                }

                if (atual == null)  // neste caso, a chave a remover não existe e não pode
                    return false;   // ser excluída, dai retornamos falso indicando isso
            }  // fim do while

            // se fluxo de execução vem para este ponto, a chave a remover foi encontrada
            // e o ponteiro atual indica o nó que contém essa chave

            if ((atual.Esquerdo == null) && (atual.Direito == null))  // é folha, nó com 0 filhos
            {
                if (atual == raiz)
                    raiz = null;   // exclui a raiz e a árvore fica vazia
                else
                    if (ehFilhoEsquerdo)        // se for filho esquerdo, o antecessor deixará 
                    antecessor.Esquerdo = null;  // de ter um descendente esquerdo
                else                        // se for filho direito, o antecessor deixará de 
                    antecessor.Direito = null;  // apontar para esse filho

                atual = antecessor;  // feito para atual apontar um nó válido ao sairmos do método
            }
            else   // verificará as duas outras possibilidades, exclusão de nó com 1 ou 2 filhos
                if (atual.Direito == null)   // neste caso, só tem o filho esquerdo
            {
                if (atual == raiz)
                    raiz = atual.Esquerdo;
                else
                    if (ehFilhoEsquerdo)
                    antecessor.Esquerdo = atual.Esquerdo;
                else
                    antecessor.Direito = atual.Esquerdo;
                atual = antecessor;
            }
            else
                    if (atual.Esquerdo == null)  // neste caso, só tem o filho direito
            {
                if (atual == raiz)
                    raiz = atual.Direito;
                else
                    if (ehFilhoEsquerdo)
                    antecessor.Esquerdo = atual.Direito;
                else
                    antecessor.Direito = atual.Direito;
                atual = antecessor;
            }
            else // tem os dois descendentes
            {
                NoArvore<Dado> menorDosMaiores = ProcuraMenorDosMaioresDescendentes(atual);
                atual.Info = menorDosMaiores.Info;
                menorDosMaiores = null; // para liberar o nó trocado da memória
            }
            return true;
        }

        public NoArvore<Dado> ProcuraMenorDosMaioresDescendentes(NoArvore<Dado> noAExcluir)
        {
            NoArvore<Dado> paiDoSucessor = noAExcluir;
            NoArvore<Dado> sucessor = noAExcluir;
            NoArvore<Dado> atual = noAExcluir.Direito;   // vai ao ramo direito do nó a ser excluído, pois este ramo contém
            // os descendentes que são maiores que o nó a ser excluído 
            while (atual != null)
            {
                if (atual.Esquerdo != null)
                    paiDoSucessor = atual;
                sucessor = atual;
                atual = atual.Esquerdo;
            }

            if (sucessor != noAExcluir.Direito)
            {
                paiDoSucessor.Esquerdo = sucessor.Direito;
                sucessor.Direito = noAExcluir.Direito;
            }
            return sucessor;
        }

        public NoArvore<Dado> Raiz { get => raiz; set => raiz = value; }
        public NoArvore<Dado> Atual { get => atual; set => atual = value; }
        public NoArvore<Dado> Antecessor { get => antecessor; set => antecessor = value; }
    }
}
