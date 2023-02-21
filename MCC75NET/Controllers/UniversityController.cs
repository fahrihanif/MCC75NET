using MCC75NET.Contexts;
using MCC75NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MCC75NET.Controllers;
public class UniversityController : Controller
{
    private readonly MyContext context;

    public UniversityController(MyContext context)
    {
        this.context = context;
    }

    public IActionResult Index()
    {
        var universities = context.Universities.ToList();
        return View(universities);
    }

    public IActionResult Details(int id)
    {
        var university = context.Universities.Find(id);
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
        context.Add(university);
        var result = context.SaveChanges();
        if (result > 0)
            return RedirectToAction(nameof(Index));
        return View();
    }

    public IActionResult Edit(int id)
    {
        var university = context.Universities.Find(id);
        return View(university);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(University university)
    {
        context.Entry(university).State = EntityState.Modified;
        var result = context.SaveChanges();
        if (result > 0)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }

    public IActionResult Delete(int id)
    {
        var university = context.Universities.Find(id);
        return View(university);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int id)
    {
        var university = context.Universities.Find(id);
        context.Remove(university);
        var result = context.SaveChanges();
        if (result > 0)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
}
