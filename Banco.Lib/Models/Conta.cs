namespace Contas.Lib.Models
{
    public abstract class Conta
    {
        public string nomeTitular { get; set; }
        public bool ativa { get; private set; }
        private double saldo;
        protected string tipoConta;
        internal int agencia { get; set; }
        protected internal string banco = "Banco do Brasil";
        protected string senhaSecreta = "1234";

        protected Conta(string titular, int agencia)
        {
            nomeTitular = titular;
            agencia = agencia;
            saldo = 0;
            ativa = true;
        }

        public void depositar(double valor)
        {
            if (!ativa)
            {
                Console.WriteLine("Operação inválida! A conta está desativada.");
                return;
            }

            saldo += valor;
            Console.WriteLine($"Depósito de R$ {valor} realizado para {nomeTitular}. Saldo: R$ {saldo}");
        }

        public void exibirSaldo()
        {
            if (!ativa)
            {
                Console.WriteLine("Operação inválida! A conta está desativada.");
                return;
            }

            Console.WriteLine($"Saldo atual de {nomeTitular}: R$ {saldo}");
        }

        protected double obterSaldo()
        {
            return saldo;
        }

        public abstract void sacar(double valor);

        public void desativarConta()
        {
            ativa = false;
            Console.WriteLine($"Conta de {nomeTitular} foi desativada.");
        }
    }
}