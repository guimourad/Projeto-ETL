public class Pedido
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ClienteId { get; set; }
    public List<ItemPedido> Itens { get; set; } = new();
    public decimal ValorTotal { get; set; }
    public DateTime DataFaturamento { get; set; } = DateTime.UtcNow;
}