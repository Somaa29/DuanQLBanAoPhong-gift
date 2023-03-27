﻿// <auto-generated />
using System;
using Assignmentc_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignmentc_4.Migrations
{
    [DbContext(typeof(AsmDbContext))]
    partial class AsmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignmentc_4.Models.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("HoaDon", (string)null);
                });

            modelBuilder.Entity("Assignmentc_4.Models.BillDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdHD")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdHD");

                    b.HasIndex("IdSP");

                    b.ToTable("BillDetails");
                });

            modelBuilder.Entity("Assignmentc_4.Models.Cart", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Assignmentc_4.Models.CartDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IDSP");

                    b.HasIndex("UserID");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("Assignmentc_4.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongTon")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("Assignmentc_4.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Assignmentc_4.Models.Bill", b =>
                {
                    b.HasOne("Assignmentc_4.Models.User", "User")
                        .WithMany("Bills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Assignmentc_4.Models.BillDetail", b =>
                {
                    b.HasOne("Assignmentc_4.Models.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("IdHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_HD");

                    b.HasOne("Assignmentc_4.Models.Product", "Product")
                        .WithMany("Details")
                        .HasForeignKey("IdSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_SP");

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Assignmentc_4.Models.Cart", b =>
                {
                    b.HasOne("Assignmentc_4.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("Assignmentc_4.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Assignmentc_4.Models.CartDetail", b =>
                {
                    b.HasOne("Assignmentc_4.Models.Product", "Product")
                        .WithMany("CartDetails")
                        .HasForeignKey("IDSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignmentc_4.Models.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Assignmentc_4.Models.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });

            modelBuilder.Entity("Assignmentc_4.Models.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("Assignmentc_4.Models.Product", b =>
                {
                    b.Navigation("CartDetails");

                    b.Navigation("Details");
                });

            modelBuilder.Entity("Assignmentc_4.Models.User", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Cart")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
