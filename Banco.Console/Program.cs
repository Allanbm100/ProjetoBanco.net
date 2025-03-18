using Contas.Lib.Models;

internal class Program
{
    private static void Main()
    {
        var contas = new List<Conta>();

        criarConta(contas);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Escolha uma das opções:");
            Console.WriteLine("1 - Criar Conta");
            Console.WriteLine("2 - Operar nas contas");
            Console.WriteLine("3 - Sair");
            Console.Write("Opção: ");

            string opcao = Console.ReadLine();

            if (opcao == "3")
            {
                Console.WriteLine("Saindo...");
                break;
            }

            switch (opcao)
            {
                case "1":
                    criarConta(contas);
                    break;

                case "2":
                    operarConta(contas);
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    private static void criarConta(List<Conta> contas)
    {
        Console.Clear();
        Console.WriteLine("Antes de operar, você precisa criar uma conta.");

        Console.Write("Informe o nome do titular da conta: ");
        string titular = Console.ReadLine();

        Console.Write("Informe o número da agência: ");
        int agencia = int.Parse(Console.ReadLine());

        Console.WriteLine("Escolha o tipo de conta:");
        Console.WriteLine("1 - Conta Corrente");
        Console.WriteLine("2 - Conta Poupança");
        Console.WriteLine("3 - Conta Salário");
        Console.Write("Opção: ");
        string tipoConta = Console.ReadLine();

        Conta novaConta = null;

        switch (tipoConta)
        {
            case "1":
                novaConta = new ContaCorrente(titular, agencia);
                break;

            case "2":
                novaConta = new ContaPoupanca(titular, agencia);
                break;

            case "3":
                novaConta = new ContaSalario(titular, agencia);
                break;

            default:
                Console.WriteLine("Opção de tipo de conta inválida!");
                return;
        }

        contas.Add(novaConta);
        Console.WriteLine($"Conta {tipoConta} criada com sucesso para {titular}!");
        Console.WriteLine("Agora você pode começar a operar na sua conta. Digite qualquer tecla...");
        Console.ReadKey();
    }

    private static void operarConta(List<Conta> contas)
    {
        Console.Clear();
        Console.WriteLine("Escolha o titular da conta que deseja operar:\n");

        foreach (var conta in contas)
        {
            Console.WriteLine($"Titular: {conta.nomeTitular}");
        }

        Console.Write("\nDigite o nome do titular para escolher a conta: ");
        string titularEscolhido = Console.ReadLine();

        var contaEscolhida = contas.Find(c => c.nomeTitular.Equals(titularEscolhido, StringComparison.OrdinalIgnoreCase));

        if (contaEscolhida == null)
        {
            Console.WriteLine("Conta não encontrada!");
            return;
        }

        if (!contaEscolhida.ativa)
        {
            Console.WriteLine("Esta conta está desativada e não pode realizar operações.");
            return;
        }

        Console.WriteLine("\nEscolha uma operação:");
        Console.WriteLine("1 - Depósito");
        Console.WriteLine("2 - Saque");
        Console.WriteLine("3 - Exibir saldo");
        Console.WriteLine("4 - Desativar conta");
        Console.Write("Opção: ");

        string opcaoOperacao = Console.ReadLine();

        switch (opcaoOperacao)
        {
            case "1":
                Console.Write("Informe o valor do depósito: R$ ");
                double valorDeposito = double.Parse(Console.ReadLine());
                contaEscolhida.depositar(valorDeposito);
                break;

            case "2":
                Console.Write("Informe o valor do saque: R$ ");
                double valorSaque = double.Parse(Console.ReadLine());
                contaEscolhida.sacar(valorSaque);
                break;

            case "3":
                contaEscolhida.exibirSaldo();
                break;

            case "4":
                contaEscolhida.desativarConta();
                break;

            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }
}