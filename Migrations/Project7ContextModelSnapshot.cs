﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project7.Data;

#nullable disable

namespace Project7.Migrations
{
    [DbContext(typeof(Project7Context))]
    partial class Project7ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project7.Models.TaskListModel", b =>
                {
                    b.Property<int>("TaskListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskListId"));

                    b.Property<string>("TaskListTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserModelUserId")
                        .HasColumnType("int");

                    b.HasKey("TaskListId");

                    b.HasIndex("UserModelUserId");

                    b.ToTable("TaskListModel");
                });

            modelBuilder.Entity("Project7.Models.TaskModel", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<DateTime>("TaskDeadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskListId")
                        .HasColumnType("int");

                    b.Property<int?>("TaskListModelTaskListId")
                        .HasColumnType("int");

                    b.Property<string>("TaskTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TaskId");

                    b.HasIndex("TaskListModelTaskListId");

                    b.ToTable("TaskModel");
                });

            modelBuilder.Entity("Project7.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("FirsstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserModel");
                });

            modelBuilder.Entity("Project7.Models.TaskListModel", b =>
                {
                    b.HasOne("Project7.Models.UserModel", null)
                        .WithMany("TasksList")
                        .HasForeignKey("UserModelUserId");
                });

            modelBuilder.Entity("Project7.Models.TaskModel", b =>
                {
                    b.HasOne("Project7.Models.TaskListModel", null)
                        .WithMany("TaskList")
                        .HasForeignKey("TaskListModelTaskListId");
                });

            modelBuilder.Entity("Project7.Models.TaskListModel", b =>
                {
                    b.Navigation("TaskList");
                });

            modelBuilder.Entity("Project7.Models.UserModel", b =>
                {
                    b.Navigation("TasksList");
                });
#pragma warning restore 612, 618
        }
    }
}
