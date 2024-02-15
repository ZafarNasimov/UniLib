using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Unilib.DatabaseUtil;
using Unilib.Models;

namespace Unilib.Pages.AddPages
{
    public class AddBookModel : PageModel
    {
        public IActionResult OnPost()
        {
            using (UnilibContext context = new())
            {
                var book = new Book();

                string ISBN = Request.Form["ISBN"];
                string title = Request.Form["Title"];
                string genre = Request.Form["Genre"];
                string publicationDate = Request.Form["PublicationDate"];

                book.ISBN = ISBN;
                book.Title = title;
                book.Genre = genre;
                book.Publication_Date = DateOnly.Parse(publicationDate);

                try
                {
                    context.Books.Add(book);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToPage("/Error");
                }
            }
            return RedirectToPage("/MainPages/Book");
        }
    }
}
