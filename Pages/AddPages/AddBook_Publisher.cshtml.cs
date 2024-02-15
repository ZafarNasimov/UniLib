using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unilib.DatabaseUtil;
using Unilib.Models;

namespace Unilib.Pages.AddPages
{
    public class AddBook_PublisherModel : PageModel
    {
        public IActionResult OnPost()
        {
            using (UnilibContext context = new())
            {
                var book_publisher = new BookPublisher();

                string ISBN = Request.Form["ISBN"];
                int publisher_id = Convert.ToInt32(Request.Form["Publisher_id"]);

                book_publisher.ISBN = ISBN;
                book_publisher.Publisher_id = publisher_id;

                try
                {
                    context.BookPublishers.Add(book_publisher);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return RedirectToPage("/Error");
                }
            }
            return RedirectToPage("/MainPages/Book_Publisher");
        }
    }
}
