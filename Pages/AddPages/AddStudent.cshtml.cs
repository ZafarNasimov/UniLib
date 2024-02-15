using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Unilib.DatabaseUtil;
using Unilib.Models;

namespace Unilib.Pages.AddPages
{
    public class AddStudentModel : PageModel
    {
        public IActionResult OnPost()
        {
            using (UnilibContext context = new())
            {
                var student = new Student();

                string name = Request.Form["Name"];
                string address = Request.Form["Address"];
                string email = Request.Form["Email"];

                student.Name = name;
                student.Address = address;
                student.Email = email;

                try
                {
                    context.Students.Add(student);
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
