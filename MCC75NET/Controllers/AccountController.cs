using MCC75NET.Repositories;
using MCC75NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MCC75NET.Controllers;
public class AccountController : Controller
{
    private readonly AccountRepository repository;

    public AccountController(AccountRepository repository)
    {
        this.repository = repository;
    }

    public IActionResult Index()
    {
        return View();
    }

    // GET : Account/Register
    public IActionResult Register()
    {
        var genders = new List<SelectListItem>{
            new SelectListItem
            {
                Value = "0",
                Text = "Male"
            },
            new SelectListItem
            {
                Value = "1",
                Text = "Female"
            },
        };

        ViewBag.Genders = genders;
        return View();
    }

    // POST : Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterVM registerVM)
    {
        if (ModelState.IsValid)
        {
            var result = repository.Register(registerVM);
            if (result > 0)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        return View();
    }

    // GET : Account/Login
    public IActionResult Login()
    {
        return View();
    }

    // POST : Account/Login
    // Parameter LoginVM {Email, Password}
    // Validasi Email exist?, Password equal?
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginVM loginVM)
    {
        if (repository.Login(loginVM))
        {
            return RedirectToAction("Index", "Home");
        }
        ModelState.AddModelError(string.Empty, "Account or Password Not Found!");
        return View();
    }
}
