﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20201209220937_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-rc.1.20451.13");

            modelBuilder.Entity("API.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<int>("GateCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("KnownAs")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Zip")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Models.ContractFile", b =>
                {
                    b.Property<int>("ContractFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublicID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UnitID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ContractFileId");

                    b.HasIndex("UnitID");

                    b.HasIndex("UserId");

                    b.ToTable("ContractFiles");
                });

            modelBuilder.Entity("API.Models.Unit", b =>
                {
                    b.Property<int>("UnitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Occupancy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UnitDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("UnitLocation")
                        .HasColumnType("TEXT");

                    b.Property<int>("UnitNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UnitSpecificImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("UnitTypeID")
                        .HasColumnType("INTEGER");

                    b.HasKey("UnitID");

                    b.HasIndex("UnitTypeID");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("API.Models.UnitType", b =>
                {
                    b.Property<int>("UnitTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Depth")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("UnitTypeDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("UnitTypeImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("UnitTypeName")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Width")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("UnitTypeID");

                    b.ToTable("UnitType");
                });

            modelBuilder.Entity("API.Models.ContractFile", b =>
                {
                    b.HasOne("API.Models.Unit", "Unit")
                        .WithMany("Contracts")
                        .HasForeignKey("UnitID");

                    b.HasOne("API.Models.AppUser", "User")
                        .WithMany("ContractFiles")
                        .HasForeignKey("UserId");

                    b.Navigation("Unit");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Models.Unit", b =>
                {
                    b.HasOne("API.Models.UnitType", "UnitType")
                        .WithMany()
                        .HasForeignKey("UnitTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UnitType");
                });

            modelBuilder.Entity("API.Models.AppUser", b =>
                {
                    b.Navigation("ContractFiles");
                });

            modelBuilder.Entity("API.Models.Unit", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
