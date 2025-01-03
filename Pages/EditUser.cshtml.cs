using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleCRUD.Data;
using System.Linq;

public class EditUserModel : PageModel
{
    private readonly AppDbContext _context;

    [BindProperty]
    public int Id { get; set; }

    [BindProperty]
    public string Username { get; set; }

    public EditUserModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return RedirectToPage("Users");
        }
        Id = user.Id;
        Username = user.Username;
        return Page();
    }

    public IActionResult OnPost()
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == Id);
        if (user != null)
        {
            user.Username = Username;
            _context.SaveChanges();
            return RedirectToPage("Users");
        }
        return Page();
    }
}
