using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Unilib.DatabaseUtil;

namespace Unilib.Pages.MainPages
{
    public class StudentModel : PageModel
    {
        public IActionResult OnPostDelete(int id)
        {
            using (UnilibContext context = new())
            {
                var student = context.Students.Find(id);

                if (student == null)
                {
                    return NotFound();
                }

                context.Students.Remove(student);
                context.SaveChanges();
            }


            return RedirectToPage("/MainPages/Student");
        }
    }
}
