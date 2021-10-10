﻿namespace _07_ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; } //Propriedade onde temos apenas o get e o set sem lógica específica
        public int Conta { get; set; }
        public static int TotalDeContasCriadas { get; private set; } //Colocamos o set privado para que ninguém possa manipular esse dado externamente

        private int _agencia;
        public int Agencia
        {
            get
            {
                return _agencia;
            }
            set
            {
                if(value <= 0)
                {
                    return;
                }
                _agencia = value;

            }
        }

        private double _saldo = 100; //Por convenção usamos '_' no início de nomes de atributos da classe
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                _saldo += value;
            }
        }

        //Construtor
        public ContaCorrente(int agencia, int conta)
        {
            Agencia = agencia;
            Conta = conta;

            TotalDeContasCriadas++;
        }

        public bool Sacar(double valor)
        {
            if (_saldo < valor)
            {
                return false;
            }
            else
            {
                _saldo -= valor;
                return true;
            }
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (_saldo < valor)
            {
                return false;
            }

            // Poderíamos ter o else ou não. Não temos porque já temos o returno no if, ou seja se entrar no if ele sai da função
            // e se ele não entrar no if executa a instrução abaixo.
            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;

        }

        //=============== GETTERS E SETTERS ANTIGOS VERSÃO 1 ===============
        /*
        public void SetSaldo(double saldo)
        {
            if (saldo < 0)
            {
                return;
            }

            _saldo += saldo;
        }

        public double GetSaldo()
        {
            return _saldo;
        }
        */
    }
}