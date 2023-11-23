using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Model;

namespace ProjetoFinal.Pages.Nota
{
    public class Create : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public NotaModel NotaModel { get; set; } = new();
        public AlunoModel AlunoModel { get; set; } = new();
        public List<AlunoModel>? AlunoList { get; set; }
        public List<NotaModel>? NotaList { get; set; }

        public Create(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            NotaList = await _context.Notas!.ToListAsync();
            AlunoList = await _context.Alunos!.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int nota, int aluno)
        {
            var selectedNota = await _context.Notas!.Include(e => e.Alunos).FirstOrDefaultAsync(e => e.NotaID == aluno);
            var selectedAluno = await _context.Alunos!.FindAsync(aluno);

            if (selectedNota == null || selectedAluno == null)
            {
                return NotFound();
            }

            selectedNota.Alunos!.Add(selectedAluno);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}