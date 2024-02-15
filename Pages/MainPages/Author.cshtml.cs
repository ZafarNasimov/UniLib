using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Unilib.DatabaseUtil;

namespace Unilib.Pages.MainPages
{
    public class AuthorModel : PageModel
    {
        public IActionResult OnPostDelete(int id)
        {
            using (UnilibContext context = new())
            {
                var author = context.Authors.Find(id);

                if (author == null)
                {
                    return NotFound();
                }

                context.Authors.Remove(author);
                context.SaveChanges();
            }


            return RedirectToPage("/MainPages/Author");
        }
    }
}
