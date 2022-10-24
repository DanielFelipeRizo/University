﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityApiBackend.DataAccess;

#nullable disable

namespace UniversityApiBackend.Migrations
{
    [DbContext(typeof(UniversityDBContext))]
    [Migration("20221021220930_relacion_User_baseEntity")]
    partial class relacion_User_baseEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BaseEntityUser", b =>
                {
                    b.Property<int>("BentityId")
                        .HasColumnType("int");

                    b.Property<int>("usersBEId")
                        .HasColumnType("int");

                    b.HasKey("BentityId", "usersBEId");

                    b.HasIndex("usersBEId");

                    b.ToTable("BaseEntityUser");
                });

            modelBuilder.Entity("CategoryCourse", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "CoursesId");

                    b.HasIndex("CoursesId");

                    b.ToTable("CategoryCourse");
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.Property<int>("coursesId")
                        .HasColumnType("int");

                    b.HasKey("StudentsId", "coursesId");

                    b.HasIndex("coursesId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("UniversityApiBackend.models.dataModels.BaseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("deletedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BaseEntity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseEntity");
                });

            modelBuilder.Entity("UniversityApiBackend.models.dataModels.Category", b =>
                {
                    b.HasBaseType("UniversityApiBackend.models.dataModels.BaseEntity");

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Category");
                });

            modelBuilder.Entity("UniversityApiBackend.models.dataModels.Course", b =>
                {
                    b.HasBaseType("UniversityApiBackend.models.dataModels.BaseEntity");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("courseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("longCourseDescription")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("objectives")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("shortCourseDescription")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<string>("targetPublic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasDiscriminator().HasValue("Course");
                });

            modelBuilder.Entity("UniversityApiBackend.models.dataModels.index", b =>
                {
                    b.HasBaseType("UniversityApiBackend.models.dataModels.BaseEntity");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasIndex("CourseId")
                        .IsUnique()
                        .HasFilter("[CourseId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("index");
                });

            modelBuilder.Entity("UniversityApiBackend.models.dataModels.Student", b =>
                {
                    b.HasBaseType("UniversityApiBackend.models.dataModels.BaseEntity");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("lastNameStudent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("UniversityApiBackend.models.dataModels.User", b =>
                {
                    b.HasBaseType("UniversityApiBackend.models.dataModels.BaseEntity");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("BaseEntityUser", b =>
                {
                    b.HasOne("UniversityApiBackend.models.dataModels.BaseEntity", null)
                        .WithMany()
                        .HasForeignKey("BentityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityApiBackend.models.dataModels.User", null)
                        .WithMany()
                        .HasForeignKey("usersBEId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoryCourse", b =>
                {
                    b.HasOne("UniversityApiBackend.models.dataModels.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityApiBackend.models.dataModels.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseStudent", b =>
                {
                    b.HasOne("UniversityApiBackend.models.dataModels.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityApiBackend.models.dataModels.Course", null)
                        .WithMany()
                        .HasForeignKey("coursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UniversityApiBackend.models.dataModels.index", b =>
                {
                    b.HasOne("UniversityApiBackend.models.dataModels.Course", "Course")
                        .WithOne("index")
                        .HasForeignKey("UniversityApiBackend.models.dataModels.index", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("UniversityApiBackend.models.dataModels.Course", b =>
                {
                    b.Navigation("index")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}