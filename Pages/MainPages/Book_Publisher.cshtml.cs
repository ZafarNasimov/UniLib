using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unilib.DatabaseUtil;

namespace Unilib.Pages.MainPages
{
    public class Book_PublisherModel : PageModel
    {
        public IActionResult OnPostDelete(string ISBN)
        {
            using (UnilibContext context = new())
            {
                var book_publisher = context.BookPublishers.Find(ISBN);

                if (book_publisher == null)
                {
                    return NotFound();
                }

                context.BookPublishers.Remove(book_publisher);
                context.SaveChanges();
            }


            return RedirectToPage("/MainPages/Book_Publisher");
        }
    }
}
