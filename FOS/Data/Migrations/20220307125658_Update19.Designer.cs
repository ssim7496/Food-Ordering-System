﻿// <auto-generated />
using System;
using FOS_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FOS.Data.Migrations
{
    [DbContext(typeof(FOSDBContext))]
    [Migration("20220307125658_Update19")]
    partial class Update19
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FOS_API.Data.MenuCategory", b =>
                {
                    b.Property<int>("MenuCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuCategoryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Order")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)");

                    b.HasKey("MenuCategoryId");

                    b.ToTable("MenuCategories");

                    b.HasData(
                        new
                        {
                            MenuCategoryId = 1,
                            Name = "Starters",
                            Order = 1.0
                        },
                        new
                        {
                            MenuCategoryId = 2,
                            Name = "Salads",
                            Order = 2.0
                        },
                        new
                        {
                            MenuCategoryId = 3,
                            Name = "Wraps",
                            Order = 3.0
                        },
                        new
                        {
                            MenuCategoryId = 4,
                            Name = "Burgers",
                            Order = 4.0
                        },
                        new
                        {
                            MenuCategoryId = 5,
                            Name = "Pasta",
                            Order = 5.0
                        });
                });

            modelBuilder.Entity("FOS_API.Data.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("MenuCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Order")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("MenuItemId");

                    b.HasIndex("MenuCategoryId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            Description = "Nachos guacamole Nachos layered with cheddar cheese, jalapenos, sour cream, fresh salsa and guacamole",
                            MenuCategoryId = 1,
                            Name = "Nachos",
                            Order = 1.0,
                            Price = 75.0,
                            Visible = true
                        },
                        new
                        {
                            MenuItemId = 2,
                            Description = "Marinated grilled chicken wings prepared in your choice of sauce, per-peri, lemon and herb or barbeque",
                            MenuCategoryId = 1,
                            Name = "Grilled chicken wings",
                            Order = 2.0,
                            Price = 70.0,
                            Visible = true
                        },
                        new
                        {
                            MenuItemId = 3,
                            Description = "Chicken livers pan seared with chilli, garlic, ginger, napped with a creamy tomato sauce served with bruschetta",
                            MenuCategoryId = 1,
                            Name = "Chicken Livers Peri-Peri",
                            Order = 3.0,
                            Price = 58.0,
                            Visible = true
                        },
                        new
                        {
                            MenuItemId = 4,
                            Description = "Tomato, onion, cucumber, peppers, feta cheese and olives",
                            MenuCategoryId = 2,
                            Name = "Greek Salad",
                            Order = 4.0,
                            Price = 68.0,
                            Visible = true
                        },
                        new
                        {
                            MenuItemId = 5,
                            Description = "Avocado and prawns served with a tantalizing seafood dressing",
                            MenuCategoryId = 2,
                            Name = "Avocado and prawn salad",
                            Order = 5.0,
                            Price = 125.0,
                            Visible = true
                        },
                        new
                        {
                            MenuItemId = 6,
                            Description = "Beef strips, stir fried vegetables prepared in a peri-peri sauce",
                            MenuCategoryId = 3,
                            Name = "Beef wrap",
                            Order = 6.0,
                            Price = 98.0,
                            Visible = true
                        },
                        new
                        {
                            MenuItemId = 7,
                            Description = "Strips of tender chicken fillet sautéed with fresh peppers, halloumi cheese and sweet and sour sauce",
                            MenuCategoryId = 3,
                            Name = "Chicken wrap",
                            Order = 7.0,
                            Price = 96.0,
                            Visible = true
                        },
                        new
                        {
                            MenuItemId = 8,
                            Description = "Homemade beef patty topped with crispy bacon, tempura onions, avocado guacamole, smoky cheddar, home-made tomato salsa and fresh rocket",
                            MenuCategoryId = 4,
                            Name = "Famous burger",
                            Order = 8.0,
                            Price = 143.0,
                            Visible = true
                        },
                        new
                        {
                            MenuItemId = 9,
                            Description = "Chicken Fillet topped with fresh pineapple and sweet chilli basting",
                            MenuCategoryId = 4,
                            Name = "Chicken cheese & pineapple",
                            Order = 9.0,
                            Price = 108.0,
                            Visible = true
                        },
                        new
                        {
                            MenuItemId = 10,
                            Description = "Fried mushroom and ham in a creamy garlic sauce",
                            MenuCategoryId = 5,
                            Name = "Pasta alfredo",
                            Order = 10.0,
                            Price = 105.0,
                            Visible = true
                        },
                        new
                        {
                            MenuItemId = 11,
                            Description = "Grilled prawns finished with a chilli infused creamy tomato sauce",
                            MenuCategoryId = 5,
                            Name = "Prawn pasta",
                            Order = 11.0,
                            Price = 135.0,
                            Visible = true
                        },
                        new
                        {
                            MenuItemId = 12,
                            Description = "Char grilled chicken strips pan fried with white wine, garlic mushroom and a creamy pesto sauce",
                            MenuCategoryId = 5,
                            Name = "Pesto chicken",
                            Order = 12.0,
                            Price = 125.0,
                            Visible = true
                        });
                });

            modelBuilder.Entity("FOS_API.Data.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCompleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOrdered")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatePrepared")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatusID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("OrderStatusID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FOS_API.Data.OrderItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("MenuItemID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MenuItemID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("FOS_API.Data.OrderStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("OrderStatuses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Ordered"
                        },
                        new
                        {
                            ID = 2,
                            Description = "Prepared"
                        },
                        new
                        {
                            ID = 3,
                            Description = "Complete"
                        });
                });

            modelBuilder.Entity("FOS.Data.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FOS_API.Data.MenuItem", b =>
                {
                    b.HasOne("FOS_API.Data.MenuCategory", "MenuCategory")
                        .WithMany()
                        .HasForeignKey("MenuCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuCategory");
                });

            modelBuilder.Entity("FOS_API.Data.Order", b =>
                {
                    b.HasOne("FOS_API.Data.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("FOS_API.Data.OrderItem", b =>
                {
                    b.HasOne("FOS_API.Data.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FOS_API.Data.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
