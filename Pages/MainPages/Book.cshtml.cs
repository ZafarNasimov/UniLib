using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unilib.DatabaseUtil;

namespace Unilib.Pages.MainPages
{
    public class BookModel : PageModel
    {
        public IActionResult OnPostDelete(string ISBN)
        {
            using (UnilibContext context = new())
            {
                var book = context.Books.Find(ISBN);

                if (book == null)
                {
                    return NotFound();
                }

                context.Books.Remove(book);
                context.SaveChanges();
            }


            return RedirectToPage("/MainPages/Book");
        }
    }
}
