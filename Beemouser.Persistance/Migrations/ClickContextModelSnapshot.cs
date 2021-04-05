﻿// <auto-generated />
using System;
using Beemouser.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Beemouser.Persistance.Migrations
{
    [DbContext(typeof(ClickContext))]
    partial class ClickContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Beemouser.Domain.Models.Click", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ClickedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("WindowOwnerName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clicks");
                });
#pragma warning restore 612, 618
        }
    }
}