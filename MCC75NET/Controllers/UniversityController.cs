using MCC75NET.Models;
using MCC75NET.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MCC75NET.Controllers;
public class UniversityController : Controller
{
    private readonly UniversityRepository repository;

    public UniversityController(UniversityRepository repository)
    {
        this.repository = repository;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("email") == null)
        {
            return RedirectToAction("Unauthorized", "Error");
        }
        if (HttpContext.Session.GetString("role") != "Admin")
        {
            return RedirectToAction("Forbidden", "Error");
        }
        var universities = repository.GetAll();
        return View(universities);
    }

    public IActionResult Details(int id)
    {
        var university = repository.GetById(id);
        return View(university);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(University university)
    {
        var result = repository.Insert(university);
        if (result > 0)
            return RedirectToAction(nameof(Index));
        return View();
    }

    public IActionResult Edit(int id)
    {
        var university = repository.GetById(id);
        return View(university);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(University university)
    {
        var result = repository.Update(university);
        if (result > 0)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }

    public IActionResult Delete(int id)
    {
        var university = repository.GetById(id);
        return View(university);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int id)
    {
        var result = repository.Delete(id);
        if (result > 0)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
}
