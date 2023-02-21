using MCC75NET.Contexts;
using MCC75NET.Models;
using MCC75NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MCC75NET.Controllers;
public class EmployeeController : Controller
{
    private readonly MyContext context;

    public EmployeeController(MyContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        var employees = context.Employees.Select(e => new EmployeeVM
        {
            NIK = e.NIK,
            Email = e.Email,
            BirthDate = e.BirthDate,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Gender = e.Gender,
            HiringDate = e.HiringDate,
            PhoneNumber = e.PhoneNumber
        }).ToList();
        return View(employees);
    }

    public IActionResult Details(int id)
    {
        var e = context.Employees.Find(id);
        return View(new EmployeeVM
        {
            NIK = e.NIK,
            Email = e.Email,
            BirthDate = e.BirthDate,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Gender = e.Gender,
            HiringDate = e.HiringDate,
            PhoneNumber = e.PhoneNumber
        });
    }

    public IActionResult Create()
    {
        var gender = new List<SelectListItem>
        {
            new SelectListItem
            {
                Value = "0",
                Text = "Male"
            },
            new SelectListItem
            {
                Value = "1",
                Text = "Female"
            }
        };

        ViewBag.Gender = gender;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EmployeeVM e)
    {
        context.Add(new Employee
        {
            NIK = e.NIK,
            Email = e.Email,
            BirthDate = e.BirthDate,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Gender = e.Gender,
            HiringDate = e.HiringDate,
            PhoneNumber = e.PhoneNumber
        });
        var result = context.SaveChanges();
        if (result > 0)
            return RedirectToAction(nameof(Index));
        return View();
    }

    public IActionResult Edit(string id)
    {
        var gender = new List<SelectListItem>
        {
            new SelectListItem
            {
                Value = "0",
                Text = "Male"
            },
            new SelectListItem
            {
                Value = "1",
                Text = "Female"
            }
        };

        ViewBag.Gender = gender;

        var e = context.Employees.Find(id);
        return View(new EmployeeVM
        {
            NIK = e.NIK,
            Email = e.Email,
            BirthDate = e.BirthDate,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Gender = e.Gender,
            HiringDate = e.HiringDate,
            PhoneNumber = e.PhoneNumber
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(EmployeeVM e)
    {
        context.Entry(new Employee
        {
            NIK = e.NIK,
            Email = e.Email,
            BirthDate = e.BirthDate,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Gender = e.Gender,
            HiringDate = e.HiringDate,
            PhoneNumber = e.PhoneNumber
        }).State = EntityState.Modified;

        var result = context.SaveChanges();
        if (result > 0)
            return RedirectToAction(nameof(Index));

        return View();
    }

    public IActionResult Delete(string id)
    {
        var e = context.Employees.Find(id);
        return View(new EmployeeVM
        {
            NIK = e.NIK,
            Email = e.Email,
            BirthDate = e.BirthDate,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Gender = e.Gender,
            HiringDate = e.HiringDate,
            PhoneNumber = e.PhoneNumber
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(string id)
    {
        var e = context.Employees.Find(id);
        context.Remove(e);
        var result = context.SaveChanges();
        if (result > 0)
            return RedirectToAction(nameof(Index));

        return View();
    }
}
