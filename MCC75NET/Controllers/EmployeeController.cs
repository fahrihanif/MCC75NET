using MCC75NET.Models;
using MCC75NET.Repositories;
using MCC75NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MCC75NET.Controllers;
public class EmployeeController : Controller
{
    private readonly EmployeeRepository repository;

    public EmployeeController(EmployeeRepository repository)
    {
        this.repository = repository;
    }

    public IActionResult Index()
    {
        var employees = repository.GetAll().Select(e => new EmployeeVM
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

    public IActionResult Details(string id)
    {
        var e = repository.GetById(id);
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
        var result = repository.Insert(new Employee
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

        var e = repository.GetById(id);
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
        var result = repository.Update(new Employee
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
        if (result > 0)
            return RedirectToAction(nameof(Index));

        return View();
    }

    public IActionResult Delete(string id)
    {
        var e = repository.GetById(id);
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
        var result = repository.Delete(id);
        if (result > 0)
            return RedirectToAction(nameof(Index));

        return View();
    }
}
