// Controllers/PedidoController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/pedido")]
public class PedidoController : ControllerBase
{
    private static List<Pedido> pedidos = new();
    private readonly ETLService _etl;

    public PedidoController(ETLService etl)
    {
        _etl = etl;
    }

    [HttpPost("faturar")]
    public IActionResult FaturarPedido([FromBody] Pedido pedido)
    {
        pedido.DataFaturamento = DateTime.UtcNow;
        pedido.ValorTotal = pedido.Itens.Sum(i => i.PrecoUnitario * i.Quantidade);
        pedidos.Add(pedido);

        // Dispara agente ETL - salvar pedido completo no DW (aqui em JSON)
        _etl.EnviarPedidoParaDW(pedido);

        return Ok(new { mensagem = "Pedido faturado com sucesso.", pedido.Id, pedido.ValorTotal });
    }
}
