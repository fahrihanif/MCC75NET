using MCC75NET.Contexts;
using MCC75NET.Models;
using MCC75NET.Repositories;
using MCC75NET.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MCC75NET.Controllers;
public class EducationController : Controller
{
    private readonly MyContext context;
    private readonly EducationRepository repository;

    public EducationController(MyContext context, EducationRepository repository)
    {
        this.context = context;
        this.repository = repository;
    }

    public IActionResult Index()
    {
        var results = repository.GetAllEducationUniversities();
        return View(results);
    }

    public IActionResult Details(int id)
    {
        var education = repository.GetByIdEducationUniversities(id);
        return View(education);
    }

    public IActionResult Create()
    {
        var universites = context.Universities.ToList()
            .Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Name
            });

        ViewBag.University = universites;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EducationUniversityVM education)
    {
        string addComma = education.GPA.ToString().Insert(1, ",");
        double changeToDouble = Convert.ToDouble(addComma);
        education.GPA = changeToDouble;

        var result = repository.Insert(new Education
        {
            Id = education.Id,
            Degree = education.Degree,
            GPA = education.GPA,
            Major = education.Major,
            UniversityId = Convert.ToInt16(education.UniversityName)
        });
        if (result > 0)
            return RedirectToAction(nameof(Index));
        return View();
    }

    public IActionResult Edit(int id)
    {
        var education = repository.GetByIdEducationUniversities(id);
        var universites = context.Universities.ToList()
            .Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Name
            });

        ViewBag.University = universites;
        return View(education);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(EducationUniversityVM education)
    {
        var result = repository.Update(new Education
        {
            Id = education.Id,
            Degree = education.Degree,
            GPA = education.GPA,
            Major = education.Major,
            UniversityId = Convert.ToInt16(education.UniversityName)
        });
        if (result > 0)
            return RedirectToAction(nameof(Index));

        return View();
    }

    public IActionResult Delete(int id)
    {
        var education = repository.GetByIdEducationUniversities(id);
        return View(education);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int id)
    {
        var result = repository.Delete(id);
        if (result > 0)
            return RedirectToAction(nameof(Index));

        return View();
    }
}
