﻿// <auto-generated />
using System;
using MCC75NET.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MCC75NET.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230220091940_UpdatedUniqueKey")]
    partial class UpdatedUniqueKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MCC75NET.Models.Account", b =>
                {
                    b.Property<string>("EmployeeNIK")
                        .HasColumnType("nchar(5)")
                        .HasColumnName("employee_nik");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.HasKey("EmployeeNIK");

                    b.ToTable("tb_m_accounts");
                });

            modelBuilder.Entity("MCC75NET.Models.AccountRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNIK")
                        .IsRequired()
                        .HasColumnType("nchar(5)")
                        .HasColumnName("account_nik");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("AccountNIK");

                    b.HasIndex("RoleId");

                    b.ToTable("tb_tr_account_roles");
                });

            modelBuilder.Entity("MCC75NET.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nchar(5)")
                        .HasColumnName("degree");

                    b.Property<double>("GPA")
                        .HasColumnType("double")
                        .HasColumnName("gpa");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("major");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int")
                        .HasColumnName("university_id");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("tb_m_educations");
                });

            modelBuilder.Entity("MCC75NET.Models.Employee", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("nchar(5)")
                        .HasColumnName("nik");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("hiring_date");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("NIK");

                    b.HasIndex("Email", "PhoneNumber")
                        .IsUnique()
                        .HasFilter("[phone_number] IS NOT NULL");

                    b.ToTable("tb_m_employees");
                });

            modelBuilder.Entity("MCC75NET.Models.Profiling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EducationId")
                        .HasColumnType("int")
                        .HasColumnName("education_id");

                    b.Property<string>("EmployeeNIK")
                        .IsRequired()
                        .HasColumnType("nchar(5)")
                        .HasColumnName("employee_nik");

                    b.HasKey("Id");

                    b.HasIndex("EducationId");

                    b.HasIndex("EmployeeNIK");

                    b.ToTable("tb_tr_profilings");
                });

            modelBuilder.Entity("MCC75NET.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tb_m_roles");
                });

            modelBuilder.Entity("MCC75NET.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tb_m_universities");
                });

            modelBuilder.Entity("MCC75NET.Models.Account", b =>
                {
                    b.HasOne("MCC75NET.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("MCC75NET.Models.Account", "EmployeeNIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MCC75NET.Models.AccountRole", b =>
                {
                    b.HasOne("MCC75NET.Models.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountNIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MCC75NET.Models.Role", "Role")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MCC75NET.Models.Education", b =>
                {
                    b.HasOne("MCC75NET.Models.University", "University")
                        .WithMany("Educations")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("MCC75NET.Models.Profiling", b =>
                {
                    b.HasOne("MCC75NET.Models.Education", "Education")
                        .WithMany("Profilings")
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MCC75NET.Models.Employee", "Employees")
                        .WithMany("Profilings")
                        .HasForeignKey("EmployeeNIK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Education");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("MCC75NET.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("MCC75NET.Models.Education", b =>
                {
                    b.Navigation("Profilings");
                });

            modelBuilder.Entity("MCC75NET.Models.Employee", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("Profilings");
                });

            modelBuilder.Entity("MCC75NET.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("MCC75NET.Models.University", b =>
                {
                    b.Navigation("Educations");
                });
#pragma warning restore 612, 618
        }
    }
}
