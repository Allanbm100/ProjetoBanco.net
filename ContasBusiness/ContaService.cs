using ContasLib.Models;
using ContasData;

namespace ContasBusiness;

public class ContaService
{
    private readonly ContaDbContext _context;

    public ContaService(ContaDbContext context)
    {
        _context = context;
    }

    public List<Conta> ListarTodas() =>
        _context.Contas.ToList();

    public Conta? ObterPorId(int id) =>
        _context.Contas.Find(id);

    public Conta Criar(Conta conta)
    {
        _context.Contas.Add(conta);
        _context.SaveChanges();
        return conta;
    }

    public bool Atualizar(Conta conta)
    {
        var existente = _context.Contas.Find(conta.Id);
        if (existente == null) return false;

        existente.Titular = conta.Titular;
        existente.Numero = conta.Numero;
        existente.Saldo = conta.Saldo;

        _context.SaveChanges();
        return true;
    }

    public bool Remover(int id)
    {
        var conta = _context.Contas.Find(id);
        if (conta == null) return false;

        _context.Contas.Remove(conta);
        _context.SaveChanges();
        return true;
    }
}
