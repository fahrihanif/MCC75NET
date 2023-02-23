using MCC75NET.Models;
using MCC75NET.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MCC75NET.Controllers;
public class RoleController : Controller
{
    private readonly RoleRepository repository;

    public RoleController(RoleRepository repository)
    {
        this.repository = repository;
    }

    public IActionResult Index()
    {
        var roles = repository.GetAll();
        return View(roles);
    }
    public IActionResult Details(int id)
    {
        var role = repository.GetById(id);
        return View(role);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Role role)
    {
        var result = repository.Insert(role);
        if (result > 0)
            return RedirectToAction(nameof(Index));
        return View();
    }

    public IActionResult Edit(int id)
    {
        var role = repository.GetById(id);
        return View(role);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Role role)
    {
        var result = repository.Update(role);
        if (result > 0)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }

    public IActionResult Delete(int id)
    {
        var role = repository.GetById(id);
        return View(role);
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
