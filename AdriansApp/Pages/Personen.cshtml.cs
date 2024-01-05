using AdriansApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdriansApp.Pages
{
    public class PersonenModel : PageModel
    {
        private readonly MyDbContext _context;

        public List<Person> PersonList { get; set; } = new List<Person>();

        [BindProperty]
        public Person NewPerson { get; set; }

        public PersonenModel(MyDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            PersonList = _context.Persons.ToList();
        }

        public IActionResult OnPost()
        {
            _context.Persons.Add(NewPerson);
            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}
