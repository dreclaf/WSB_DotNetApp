using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleCRUD.Data;
using System.Linq;

public class DeleteUserModel : PageModel
{
    private readonly AppDbContext _context;

    public string Username { get; set; }

    public DeleteUserModel(AppDbContext context)
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
        Username = user.Username;
        return Page();
    }

    public IActionResult OnPost(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        return RedirectToPage("Users");
    }
}
