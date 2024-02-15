using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unilib.DatabaseUtil;
using Unilib.Models;

namespace Unilib.Pages.AddPages
{
    public class AddBook_StudentModel : PageModel
    {
        public IActionResult OnPost()
        {
            using (UnilibContext context = new())
            {
                var book_student = new BookStudent();

                string ISBN = Request.Form["ISBN"];
                int student_id = Convert.ToInt32(Request.Form["Student_id"]);
                DateOnly borrowedDate = DateOnly.Parse(Request.Form["BorrowingDate"]);

                book_student.ISBN = ISBN;
                book_student.Student_id = student_id;
                book_student.Borrowing_Date = borrowedDate;

                try
                {
                    context.BookStudents.Add(book_student);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    return RedirectToPage("/Error");
                }
            }
            return RedirectToPage("/MainPages/Book_Student");
        }
    }
}
