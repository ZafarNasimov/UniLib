using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Unilib.DatabaseUtil;
using Unilib.Models;

namespace Unilib.Pages.EditPages
{
    public class ReturnBookModel : PageModel
    {
        public BookStudent borrowedBook = new();
        public IActionResult OnGet(int Id) 
        {
            using (UnilibContext context = new()) 
            {
                borrowedBook = context.BookStudents.FirstOrDefault(a => a.Id == Id);
            }
            return Page();
        }
        public IActionResult OnPost(int Id)
        {
            using (UnilibContext context = new())
            {
                borrowedBook = context.BookStudents.FirstOrDefault(a => a.Id == Id);

                if (borrowedBook == null)
                {
                    return RedirectToPage("/Error");
                }

                string returnDate = Request.Form["ReturnDate"];

                borrowedBook.Return_Date = DateOnly.Parse(returnDate);

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToPage("/Error");
                }
            }
            return RedirectToPage("/MainPages/Book_Student");
        }
    }
}
