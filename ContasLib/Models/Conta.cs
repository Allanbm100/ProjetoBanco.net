namespace ContasLib.Models;

public class Conta
{
    public int Id { get; set; }
    public required string Titular { get; set; }
    public required string Numero { get; set; }
    public decimal Saldo { get; set; }
}
