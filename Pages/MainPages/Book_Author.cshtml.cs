using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unilib.DatabaseUtil;

namespace Unilib.Pages.MainPages
{
    public class Book_AuthorModel : PageModel
    {
        public IActionResult OnPostDelete(int Id)
        {
            using (UnilibContext context = new())
            {
                var book_author = context.BookAuthors.Find(Id);

                if (book_author == null)
                {
                    return NotFound();
                }

                context.BookAuthors.Remove(book_author);
                context.SaveChanges();
            }


            return RedirectToPage("/MainPages/Book_Author");
        }
    }
}
