using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleCRUD.Data;
using System.Collections.Generic;
using System.Linq;

public class UsersModel : PageModel
{
    private readonly AppDbContext _context;

    public List<User> Users { get; set; } = new();

    public UsersModel(AppDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        // Fetch all users from the database
        Users = _context.Users.ToList();
    }
}
