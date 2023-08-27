using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ProjetoFinal.Pages
{
    public class Notas : PageModel
    {
        private readonly ILogger<Notas> _logger;

        public Notas(ILogger<Notas> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}