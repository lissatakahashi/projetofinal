using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjetoFinal.Pages
{
    public class Alunos : PageModel
    {
        public List<AlunoModel> AlunosList { get; set; } = new();
        // private readonly ILogger<Alunos> _logger;

        // public Alunos(ILogger<Alunos> logger)
        // {
        //     _logger = logger;
        // }

        public void OnGet([FromRoute] int skip=0, [FromRoute] int take=25)
        {
            List<AlunoModel> alunos = new();

            for (int i = 0; i < 1000; i++)
            {
                alunos.Add(new AlunoModel(i,
                    $"Nome {i}",
                    DateTime.Now,
                    $"Telefone {i}")
                );
            }

            AlunosList = alunos.Skip(skip).Take(take).ToList();
        }
    }
    
}