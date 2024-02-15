using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Unilib.DatabaseUtil;
using Unilib.Models;

namespace Unilib.Pages.EditPages
{
    public class EditBookModel : PageModel
    {
        public Book book = new();

        public IActionResult OnGet(string ISBN)
        {
            using (UnilibContext context = new())
            {
                book = context.Books.FirstOrDefault(a => a.ISBN == ISBN);
                if (book == null)
                {
                    return RedirectToPage("/Error");
                }
            }
            return Page();
        }

        public IActionResult OnPost(string ISBN)
        {
            using (UnilibContext context = new())
            {
                var book = context.Books.FirstOrDefault(a => a.ISBN == ISBN);

                if (book == null)
                {
                    return RedirectToPage("/Error");
                }

                string title = Request.Form["Title"];
                string genre = Request.Form["Genre"];
                string publicationDate = Request.Form["PublicationDate"];

                book.Title = title;
                book.Genre = genre;
                book.Publication_Date = DateOnly.Parse(publicationDate);

                try
                {
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
