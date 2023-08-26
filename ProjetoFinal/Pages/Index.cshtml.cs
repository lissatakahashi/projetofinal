using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjetoFinal.Pages;
public class Index : PageModel
{
    public List<AlunoModel> Alunos { get; set; } = new();
    // private readonly ILogger<Index> _logger;

    // public Index(ILogger<Index> logger)
    // public Index()
    // {
    //     // _logger = logger;
    // }

    public void OnGet()
    {
        for (int i = 0; i < 10; i++)
        {
            Alunos.Add(new AlunoModel(i, 
                $"Nome {i}", 
                DateTime.Now,
                $"Telefone {i}")
            );
        } 
    }
}

public record AlunoModel(
    int? Id,
    string Nome,
    DateTime DataNascimento,
    string Telefone
);