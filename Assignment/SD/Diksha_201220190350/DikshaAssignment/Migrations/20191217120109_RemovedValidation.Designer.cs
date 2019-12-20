﻿// <auto-generated />
using DikshaAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DikshaAssignment.Migrations
{
    [DbContext(typeof(EmployeeDBContext))]
    [Migration("20191217120109_RemovedValidation")]
    partial class RemovedValidation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DikshaAssignment.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Address = "New York",
                            CompanyName = "XYZ Inc",
                            Designation = "Developer",
                            EmailId = "john@yopmail.com",
                            FirstName = "John",
                            LastName = "Watson",
                            Salary = 30000f,
                            isActive = true
                        },
                        new
                        {
                            EmployeeId = 2,
                            Address = "North America",
                            CompanyName = "Test Inc",
                            Designation = "QA",
                            EmailId = "elena@yopmail.com",
                            FirstName = "Elena",
                            LastName = "Snowball",
                            Salary = 50000f,
                            isActive = true
                        },
                        new
                        {
                            EmployeeId = 3,
                            Address = "South America",
                            CompanyName = "ABC Inc",
                            Designation = "Deveploer",
                            EmailId = "tom@yopmail.com",
                            FirstName = "Tom",
                            LastName = "William",
                            Salary = 40000f,
                            isActive = true
                        },
                        new
                        {
                            EmployeeId = 4,
                            Address = "London",
                            CompanyName = "Lol Inc",
                            Designation = "UI Developer",
                            EmailId = "suzi@yopmail.com",
                            FirstName = "Suzi",
                            LastName = "Cook",
                            Salary = 35000f,
                            isActive = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
