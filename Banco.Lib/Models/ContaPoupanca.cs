namespace Contas.Lib.Models
{
    public class ContaPoupanca : Conta
    {
        private double taxaJuros = 0.05;

        public ContaPoupanca(string titular, int agencia) : base(titular, agencia)
        {
            tipoConta = "Poupança";
        }

        public void AplicarJuros()
        {
            if (!ativa)
            {
                Console.WriteLine("Operação inválida! A conta está desativada.");
                return;
            }

            double rendimento = obterSaldo() * taxaJuros;
            depositar(rendimento);
            Console.WriteLine($"Juros de R$ {rendimento} aplicados! Novo saldo: R$ {obterSaldo()}");
        }

        public override void sacar(double valor)
        {
            if (!ativa)
            {
                Console.WriteLine("Operação inválida! A conta está desativada.");
                return;
            }

            if (valor <= obterSaldo())
            {
                depositar(-valor);
                Console.WriteLine($"Saque de R$ {valor} realizado da conta poupança.");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para saque.");
            }
        }
    }
}