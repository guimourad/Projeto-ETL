// Controllers/ContaController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/conta")]
public class ContaController : ControllerBase
{
    private static List<Cliente> clientes = new();
    private readonly ETLService _etl;

    public ContaController(ETLService etl)
    {
        _etl = etl;
    }

    [HttpPost("criar")]
    public IActionResult CriarConta([FromBody] Cliente cliente)
    {
        if (clientes.Any(c => c.Email == cliente.Email))
            return Conflict("Email já cadastrado.");

        clientes.Add(cliente);

        // Dispara agente ETL
        _etl.EnviarContaParaDW(cliente);

        return Ok(new { mensagem = "Conta criada com sucesso.", cliente.Id });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Cliente login)
    {
        var cliente = clientes.FirstOrDefault(c => c.Email == login.Email && c.Senha == login.Senha);
        if (cliente == null)
            return Unauthorized("Email ou senha inválidos.");

        return Ok(new { mensagem = "Login efetuado com sucesso.", cliente.Id });
    }
}
