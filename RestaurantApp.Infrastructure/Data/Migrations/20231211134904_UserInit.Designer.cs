﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantApp.Infrastructure.Data;

#nullable disable

namespace RestaurantApp.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231211134904_UserInit")]
    partial class UserInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantApp.Domain.Users.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RoleId");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("RestaurantApp.Domain.Users.Entities.Role", b =>
                {
                    b.OwnsOne("RestaurantApp.Domain.Users.ValueObjects.RoleName", "Name", b1 =>
                        {
                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("RoleId");

                            b1.ToTable("Roles");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantApp.Domain.Users.User", b =>
                {
                    b.HasOne("RestaurantApp.Domain.Users.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("RestaurantApp.Domain.Users.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("nvarchar(30)")
                                .HasColumnName("LastName");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("RestaurantApp.Domain.Users.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("PasswordHash")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PasswordHash");

                            b1.Property<byte[]>("PasswordSalt")
                                .IsRequired()
                                .HasColumnType("varbinary(max)")
                                .HasColumnName("PasswordSalt");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("RestaurantApp.Domain.Users.ValueObjects.Phone", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(13)
                                .HasColumnType("nvarchar(13)")
                                .HasColumnName("PhoneNumber");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("RestaurantApp.Domain.Users.ValueObjects.UserEmail", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("Email");

                            b1.Property<string>("NormalizedEmail")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("NormalizedEmail");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();

                    b.Navigation("PhoneNumber")
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
