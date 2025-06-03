// Services/ETLService.cs
using System.Text.Json;

public class ETLService
{
    private readonly string _dwPath = "DW"; // pasta onde salva os JSON

    public ETLService()
    {
        if (!Directory.Exists(_dwPath))
            Directory.CreateDirectory(_dwPath);
    }

    public void EnviarContaParaDW(Cliente cliente)
    {
        var json = JsonSerializer.Serialize(cliente, new JsonSerializerOptions { WriteIndented = true });
        var filename = Path.Combine(_dwPath, $"Conta_{cliente.Id}.json");
        File.WriteAllText(filename, json);
    }

    public void EnviarPedidoParaDW(Pedido pedido)
    {
        var json = JsonSerializer.Serialize(pedido, new JsonSerializerOptions { WriteIndented = true });
        var filename = Path.Combine(_dwPath, $"Pedido_{pedido.Id}.json");
        File.WriteAllText(filename, json);
    }
}
