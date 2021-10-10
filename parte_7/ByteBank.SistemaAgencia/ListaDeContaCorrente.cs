using ByteBank.Modelos;
using System;

namespace ByteBank.SistemaAgencia
{
    public class ListaDeContaCorrente
    {
        private ContaCorrente[] _itens;
        private int _proximaPosicao;
        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }
        public ContaCorrente this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }

        public ListaDeContaCorrente(int capacidadeInicial = 5)
        {
            _itens = new ContaCorrente[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void MeuMetodo(string texto = "texti padrao", int numero = 5)
        {

        }

        public void Adicionar(ContaCorrente item)
        {
            VerificarCapacidade(_proximaPosicao+1);

            Console.WriteLine($"Adicionando item na posição: {_proximaPosicao}");
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }



        public void Remover(ContaCorrente item)
        {
            int indexItem = -1;

            for(int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente itemAtual = _itens[i];

                if (itemAtual.Equals(item))
                {
                    indexItem = i;
                    break;
                }
            }

            for(int i = indexItem; i < _proximaPosicao-1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public void EscreverListaNaTela()
        {
            for(int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente conta = _itens[i];
                Console.WriteLine($"Conta número: {conta.Agencia} {conta.Numero}");
            }
        }

        public ContaCorrente GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentException(nameof(indice));
            }
            return _itens[indice];
        }

        public void AdicionarVarios(params ContaCorrente[] itens)
        {
            foreach (ContaCorrente conta in itens)
            {
                Adicionar(conta);
            }
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            Console.WriteLine($"_itens.Length: {_itens.Length} | tamanhoNecessario: {tamanhoNecessario}");
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;
            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            Console.WriteLine("Aumentando capacidade da lista.");

            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

            for(int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
                Console.WriteLine(".");
            }

            _itens = novoArray;


        }
    }    
}
