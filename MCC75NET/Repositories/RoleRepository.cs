using MCC75NET.Contexts;
using MCC75NET.Models;
using MCC75NET.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC75NET.Repositories;

public class RoleRepository : IRepository<int, Role>
{
    private readonly MyContext context;

    public RoleRepository(MyContext context)
    {
        this.context = context;
    }

    public int Delete(int key)
    {
        var entity = GetById(key);
        context.Remove(entity);
        return context.SaveChanges();
    }

    public List<Role> GetAll()
    {
        return context.Roles.ToList();
    }

    public Role GetById(int key)
    {
        return context.Roles.Find(key);
    }

    public int Insert(Role entity)
    {
        context.Add(entity);
        return context.SaveChanges();
    }

    public int Update(Role entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        return context.SaveChanges();
    }
}
