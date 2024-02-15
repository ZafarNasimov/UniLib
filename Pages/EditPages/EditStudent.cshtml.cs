using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Unilib.DatabaseUtil;
using Unilib.Models;

namespace Unilib.Pages.EditPages
{
    public class EditStudentModel : PageModel
    {
        public Student student = new();
        public IActionResult OnGet(int id)
        {
            using (UnilibContext context = new())
            {
                student = context.Students.FirstOrDefault(a => a.Id == id);
                if (student == null)
                {
                    return RedirectToPage("/NotFound");
                }
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            using (UnilibContext context = new())
            {
                var student = context.Students.FirstOrDefault(a => a.Id == id);

                if (student == null)
                {
                    return RedirectToPage("/NotFound");
                }

                string name = Request.Form["Name"];
                string address = Request.Form["Address"];
                string email = Request.Form["Email"];

                student.Name = name;
                student.Address = address;
                student.Email = email;

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToPage("/Error");
                }
            }
            return RedirectToPage("/MainPages/Student");
        }
    }
}
