using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Unilib.DatabaseUtil;
using Unilib.Models;

namespace Unilib.Pages.AddPages
{
    public class AddBook_AuthorModel : PageModel
    {
        public IActionResult OnPost()
        {
            using (UnilibContext context = new())
            {
                var book_author = new BookAuthor();

                string ISBN = Request.Form["ISBN"];
                int author_id = Convert.ToInt32(Request.Form["Author_id"]);

                book_author.ISBN = ISBN;
                book_author.Author_id = author_id;

                try
                {
                    context.BookAuthors.Add(book_author);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return RedirectToPage("/Error");
                }
            }
            return RedirectToPage("/MainPages/Book_Author");
        }
    }
}
