using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Unilib.DatabaseUtil;
using Unilib.Models;

namespace Unilib.Pages.EditPages
{
    public class EditAuthorModel : PageModel
    {
        public Author author = new();
        public IActionResult OnGet(int id)
        {
            using(UnilibContext context = new())
            {
                author = context.Authors.FirstOrDefault(a => a.Id == id);
                if (author == null)
                {
                    return RedirectToPage("/NotFound");
                }
            }       
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            using (UnilibContext context = new())
            {
                var author = context.Authors.FirstOrDefault(a => a.Id == id);

                if (author == null)
                {
                    return RedirectToPage("/NotFound");
                }

                string name = Request.Form["Name"];
                string biography = Request.Form["Biography"];

                author.Name = name;
                author.Biography = biography;

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToPage("/Error"); 
                }
            }
            return RedirectToPage("/MainPages/Author");
        }
    }
}
