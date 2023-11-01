using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjetoFinal.Data;
using ProjetoFinal.Model;

namespace ProjetoFinal.Pages.Aluno
{
    public class Delete : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public AlunoModel AlunoModel { get; set; } = new();

        public Delete(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Alunos == null) {
                return NotFound();
            }

            var alunoModel = await _context.Alunos.FirstOrDefaultAsync(aluno => aluno.AlunoID == id);

            if (alunoModel == null) {
                return NotFound();
            }

            AlunoModel = alunoModel;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id) {
            var alunoToDelete = await _context.Alunos!.FindAsync(id);

            if (alunoToDelete == null) {
                return NotFound();
            }

            try {
                _context.Alunos.Remove(alunoToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Aluno/Index");
            } catch (DbUpdateException) {
                return Page();
            }
        }
    }
}