﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticaFinal.Lib.DAL;

namespace PracticaFinal.Web.Migrations
{
    [DbContext(typeof(PracticaFinalContext))]
    partial class PracticaFinalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PracticaFinal.Lib.Core.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Surname1");

                    b.Property<string>("Surname2");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("PracticaFinal.Lib.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Marca");

                    b.Property<string>("Modelo");

                    b.Property<DateTime?>("PublicationDate");

                    b.Property<int>("Puerta");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Car");
                });

            modelBuilder.Entity("PracticaFinal.Lib.Models.Relations.Reserva", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CarId");

                    b.Property<int>("DaysReservado");

                    b.Property<Guid>("MemberId");

                    b.Property<DateTime>("ReservaOn");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("MemberId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("PracticaFinal.Lib.Models.Admin", b =>
                {
                    b.HasBaseType("PracticaFinal.Lib.Core.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("PracticaFinal.Lib.Models.Member", b =>
                {
                    b.HasBaseType("PracticaFinal.Lib.Core.User");

                    b.HasDiscriminator().HasValue("Member");
                });

            modelBuilder.Entity("PracticaFinal.Lib.Models.Furgo", b =>
                {
                    b.HasBaseType("PracticaFinal.Lib.Models.Car");

                    b.HasDiscriminator().HasValue("Furgo");
                });

            modelBuilder.Entity("PracticaFinal.Lib.Models.Truck", b =>
                {
                    b.HasBaseType("PracticaFinal.Lib.Models.Car");

                    b.HasDiscriminator().HasValue("Truck");
                });

            modelBuilder.Entity("PracticaFinal.Lib.Models.Relations.Reserva", b =>
                {
                    b.HasOne("PracticaFinal.Lib.Models.Car", "Car")
                        .WithMany("Reservas")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PracticaFinal.Lib.Models.Member", "Member")
                        .WithMany("Reservas")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}