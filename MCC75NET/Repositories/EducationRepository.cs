using MCC75NET.Contexts;
using MCC75NET.Models;
using MCC75NET.Repositories.Interface;
using MCC75NET.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MCC75NET.Repositories;

public class EducationRepository : IRepository<int, Education>
{
    private readonly MyContext context;
    private readonly UniversityRepository universityRepository;

    public EducationRepository(MyContext context, UniversityRepository universityRepository)
    {
        this.context = context;
        this.universityRepository = universityRepository;
    }

    public int Delete(int key)
    {
        int result = 0;
        var entity = GetById(key);
        if (entity == null)
        {
            return result;
        }

        context.Remove(entity);
        result = context.SaveChanges();

        return result;
    }

    public List<Education> GetAll()
    {
        return context.Educations.ToList();
    }

    public Education GetById(int key)
    {
        return context.Educations.Find(key);
    }

    public int Insert(Education entity)
    {
        int result = 0;
        context.Add(entity);
        result = context.SaveChanges();
        return result;
    }

    public int Update(Education entity)
    {
        int result = 0;
        context.Entry(entity).State = EntityState.Modified;
        result = context.SaveChanges();

        return result;
    }

    public List<EducationUniversityVM> GetAllEducationUniversities()
    {
        var results = (from e in GetAll()
                       join u in universityRepository.GetAll()
                       on e.UniversityId equals u.Id
                       select new EducationUniversityVM
                       {
                           Id = e.Id,
                           Degree = e.Degree,
                           GPA = e.GPA,
                           Major = e.Major,
                           UniversityName = u.Name
                       }).ToList();

        return results;
    }

    public EducationUniversityVM GetByIdEducationUniversities(int key)
    {
        var results = (EducationUniversityVM)from e in GetAll()
                                             join u in universityRepository.GetAll()
                                             on e.UniversityId equals u.Id
                                             where e.Id == key
                                             select new EducationUniversityVM
                                             {
                                                 Id = e.Id,
                                                 Degree = e.Degree,
                                                 GPA = e.GPA,
                                                 Major = e.Major,
                                                 UniversityName = u.Name
                                             };

        return results;
    }
}
