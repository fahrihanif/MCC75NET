using MCC75NET.Repositories;
using MCC75NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MCC75NET.Controllers;
public class AccountController : Controller
{
    private readonly AccountRepository repository;
    private readonly IConfiguration configuration;

    public AccountController(AccountRepository repository, IConfiguration configuration)
    {
        this.repository = repository;
        this.configuration = configuration;
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
            var userdata = repository.GetUserdata(loginVM.Email);
            var roles = repository.GetRolesByNIK(loginVM.Email);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, userdata.Email),
                new Claim(ClaimTypes.Name, userdata.FullName)
            };

            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signIn
                );

            var generateToken = new JwtSecurityTokenHandler().WriteToken(token);

            HttpContext.Session.SetString("jwtoken", generateToken);

            return RedirectToAction(nameof(Index), "Home");
        }
        ModelState.AddModelError(string.Empty, "Account or Password Not Found!");
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction(nameof(Index), "Home");
    }
}
