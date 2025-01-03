using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleCRUD.Data;
using System.Linq;

public class LoginModel : PageModel
{
    private readonly AppDbContext _context;

    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public string Message { get; set; }

    public LoginModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == Username && u.Password == Password);
        if (user != null)
        {
            return RedirectToPage("Users"); // Redirect to the Users page
        }

        Message = "Invalid username or password.";
        return Page();
    }
}
