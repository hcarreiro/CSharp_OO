using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListaDeObject
    {
        private object[] _itens;
        private int _proximaPosicao;
        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }
        public object this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }

        public ListaDeObject(int capacidadeInicial = 5)
        {
            _itens = new object[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void MeuMetodo(string texto = "texti padrao", int numero = 5)
        {

        }

        public void Adicionar(object item)
        {
            VerificarCapacidade(_proximaPosicao + 1);

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }



        public void Remover(object item)
        {
            int indexItem = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                object itemAtual = _itens[i];

                if (itemAtual.Equals(item))
                {
                    indexItem = i;
                    break;
                }
            }

            for (int i = indexItem; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public void EscreverListaNaTela()
        {
            for (int i = 0; i < _proximaPosicao; i++)
            {
                object conta = _itens[i];
            }
        }

        public object GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentException(nameof(indice));
            }
            return _itens[indice];
        }

        public void AdicionarVarios(params object[] itens)
        {
            foreach (object item in itens)
            {
                Adicionar(item);
            }
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;
            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            object[] novoArray = new object[tamanhoNecessario];

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
            }

            _itens = novoArray;

        }
    }
}
