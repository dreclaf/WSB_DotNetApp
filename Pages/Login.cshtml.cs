using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class LoginModel : PageModel
{
    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public string Message { get; set; }

    public IActionResult OnPost()
    {
        if (Username == "admin" && Password == "password123")
        {
            Message = "Login successful!";
            return RedirectToPage("Index"); // Redirect to another page, e.g., Index
        }

        Message = "Invalid username or password.";
        return Page();
    }
}
