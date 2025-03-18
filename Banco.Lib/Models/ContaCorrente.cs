namespace Contas.Lib.Models
{
    public class ContaCorrente : Conta
    {
        private double chequeEspecial = 500;

        public ContaCorrente(string titular, int agencia) : base(titular, agencia)
        {
            tipoConta = "Corrente";
        }

        public override void sacar(double valor)
        {
            if (!ativa)
            {
                Console.WriteLine("Operação inválida! A conta está desativada.");
                return;
            }

            if (valor <= obterSaldo() + chequeEspecial)
            {
                depositar(-valor);
                Console.WriteLine($"Saque de R$ {valor} realizado. Saldo: R$ {obterSaldo()}. Cheque especial disponível: R$ {chequeEspecial}");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente, mesmo com cheque especial.");
            }
        }
    }
}