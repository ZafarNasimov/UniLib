using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unilib.DatabaseUtil;

namespace Unilib.Pages.MainPages
{
    public class Book_StudentModel : PageModel
    {
        public IActionResult OnPostDelete(int Id)
        {
            using (UnilibContext context = new())
            {
                var book_student = context.BookStudents.Find(Id);

                if (book_student == null)
                {
                    return NotFound();
                }

                context.BookStudents.Remove(book_student);
                context.SaveChanges();
            }


            return RedirectToPage("/MainPages/Book_Student");
        }
    }
}
