namespace Contas.Lib.Models
{
    public class ContaSalario : Conta
    {
        private int saquesRestantes = 3;

        public ContaSalario(string titular, int agencia) : base(titular, agencia)
        {
            tipoConta = "Salário";
        }

        public override void sacar(double valor)
        {
            if (!ativa)
            {
                Console.WriteLine("Operação inválida! A conta está desativada.");
                return;
            }

            if (saquesRestantes > 0 && valor <= obterSaldo())
            {
                depositar(-valor);
                saquesRestantes--;
                Console.WriteLine($"Saque de R$ {valor} realizado. Restam {saquesRestantes} saques este mês.");
            }
            else if (saquesRestantes == 0)
            {
                Console.WriteLine("Limite de saques excedido este mês!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente.");
            }
        }
    }
}