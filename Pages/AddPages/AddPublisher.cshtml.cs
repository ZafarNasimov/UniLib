using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Unilib.DatabaseUtil;
using Unilib.Models;

namespace Unilib.Pages.AddPages
{
    public class AddPublisherModel : PageModel
    {
        public IActionResult OnPost()
        {
            using (UnilibContext context = new())
            {
                var publisher = new Publisher();

                string name = Request.Form["Name"];
                string address = Request.Form["Address"];
                string contactInfo = Request.Form["ContactInfo"];

                publisher.Name = name;
                publisher.Address = address;
                publisher.Contact_Info = contactInfo;

                try
                {
                    context.Publishers.Add(publisher);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToPage("/Error");
                }
            }
            return RedirectToPage("/MainPages/Publisher");
        }
    }
}
