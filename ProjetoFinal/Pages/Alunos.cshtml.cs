using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjetoFinal.Pages;

    public class Alunos : PageModel
    {
        public List<AlunoModel> AlunosList { get; set; } = new();
        // private readonly ILogger<Alunos> _logger;

        // public Alunos(ILogger<Alunos> logger)
        // {
        //     _logger = logger;
        // }

        public void OnGet()
        {
            for (int i = 0; i < 10; i++)
            {
                AlunosList.Add(new AlunoModel(i,
                    $"Nome {i}",
                    DateTime.Now,
                    $"Telefone {i}")
                );
            }
        }
    }
    
