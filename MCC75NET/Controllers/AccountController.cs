using MCC75NET.Contexts;
using MCC75NET.Models;
using MCC75NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MCC75NET.Controllers;
public class AccountController : Controller
{
    private readonly MyContext context;

    public AccountController(MyContext context)
    {
        this.context = context;
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
            // Bikin kondisi untuk mengecek apakah data university sudah ada
            University university = new University
            {
                Name = registerVM.UniversityName
            };
            context.Universities.Add(university);
            context.SaveChanges();

            Education education = new Education
            {
                Major = registerVM.Major,
                Degree = registerVM.Degree,
                GPA = registerVM.GPA,
                UniversityId = university.Id
            };
            context.Educations.Add(education);
            context.SaveChanges();

            Employee employee = new Employee
            {
                NIK = registerVM.NIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                BirthDate = registerVM.BirthDate,
                Gender = registerVM.Gender,
                HiringDate = registerVM.HiringDate,
                Email = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
            };
            context.Employees.Add(employee);
            context.SaveChanges();

            Account account = new Account
            {
                EmployeeNIK = registerVM.NIK,
                Password = registerVM.Password
            };
            context.Accounts.Add(account);
            context.SaveChanges();

            AccountRole accountRole = new AccountRole
            {
                AccountNIK = registerVM.NIK,
                RoleId = 2
            };

            context.AccountRoles.Add(accountRole);
            context.SaveChanges();

            Profiling profiling = new Profiling
            {
                EmployeeNIK = registerVM.NIK,
                EducationId = education.Id
            };
            context.Profilings.Add(profiling);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    // GET : Account/Login

    // POST : Account/Login
    // Parameter LoginVM {Email, Password}
    // Validasi Email exist?, Password equal?
}
