using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleCRUD.Data;

public class AddUserModel : PageModel
{
    private readonly AppDbContext _context;

    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public AddUserModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            _context.Users.Add(new User { Username = Username, Password = Password });
            _context.SaveChanges();
            return RedirectToPage("Users");
        }
        return Page();
    }
}
