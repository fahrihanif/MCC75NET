using MCC75NET.Contexts;
using MCC75NET.Models;
using MCC75NET.ViewModels;

namespace MCC75NET.Repositories;

public class AccountRepository
{
    private readonly MyContext context;

    public AccountRepository(MyContext context)
    {
        this.context = context;
    }

    public bool Login(LoginVM loginVM)
    {
        var getAccounts = context.Employees.Join(
            context.Accounts,
            e => e.NIK,
            a => a.EmployeeNIK,
            (e, a) => new LoginVM
            {
                Email = e.Email,
                Password = a.Password
            });

        return getAccounts.Any(e => e.Email == loginVM.Email && e.Password == loginVM.Password);
    }

    public int Register(RegisterVM registerVM)
    {
        int result = 0;
        University university = new University
        {
            Name = registerVM.UniversityName
        };

        // Bikin kondisi untuk mengecek apakah data university sudah ada
        if (context.Universities.Any(u => u.Name == university.Name))
        {
            university.Id = context.Universities
                .FirstOrDefault(u => u.Name == university.Name)
                .Id;
        }
        else
        {
            context.Universities.Add(university);
            result = context.SaveChanges();
        }

        Education education = new Education
        {
            Major = registerVM.Major,
            Degree = registerVM.Degree,
            GPA = registerVM.GPA,
            UniversityId = university.Id
        };
        context.Educations.Add(education);
        result = context.SaveChanges();

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
        result = context.SaveChanges();

        Account account = new Account
        {
            EmployeeNIK = registerVM.NIK,
            Password = registerVM.Password
        };
        context.Accounts.Add(account);
        result = context.SaveChanges();

        AccountRole accountRole = new AccountRole
        {
            AccountNIK = registerVM.NIK,
            RoleId = 2
        };

        context.AccountRoles.Add(accountRole);
        result = context.SaveChanges();

        Profiling profiling = new Profiling
        {
            EmployeeNIK = registerVM.NIK,
            EducationId = education.Id
        };
        context.Profilings.Add(profiling);
        result = context.SaveChanges();

        return result;
    }
}
