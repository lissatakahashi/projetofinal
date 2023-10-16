using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjetoFinal.Pages;
public class Index : PageModel
{
    // private readonly ILogger<Index> _logger;

    // public Index(ILogger<Index> logger)
    // public Index()
    // {
    //     // _logger = logger;
    // }

    public void OnGet()
    {
        
    }
}

public record AlunoModel(
    int? Id,
    string Nome,
    DateTime DataNascimento,
    string Telefone
);