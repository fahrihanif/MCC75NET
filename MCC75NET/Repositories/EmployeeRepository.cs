using MCC75NET.Contexts;
using MCC75NET.Models;
using MCC75NET.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC75NET.Repositories;

public class EmployeeRepository : IRepository<string, Employee>
{
    private readonly MyContext context;

    public EmployeeRepository(MyContext context)
    {
        this.context = context;
    }

    public int Delete(string key)
    {
        var entity = GetById(key);
        context.Remove(entity);
        return context.SaveChanges();
    }

    public List<Employee> GetAll()
    {
        return context.Employees.ToList();
    }

    public Employee GetById(string key)
    {
        return context.Employees.Find(key);
    }

    public int Insert(Employee entity)
    {
        context.Add(entity);
        return context.SaveChanges();
    }

    public int Update(Employee entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        return context.SaveChanges();
    }
}
