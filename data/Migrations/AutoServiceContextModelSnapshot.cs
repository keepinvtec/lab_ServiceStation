﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab2;

#nullable disable

namespace lr2ServiceStation.Migrations
{
    [DbContext(typeof(AutoServiceContext))]
    partial class AutoServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("lab2.Car", b =>
                {
                    b.Property<string>("VINcode")
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("EngDisplacement")
                        .HasColumnType("float");

                    b.Property<string>("Manufacture")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("YearOfProd")
                        .HasColumnType("int");

                    b.HasKey("VINcode");

                    b.HasAlternateKey("VINcode", "EngDisplacement", "Mileage");

                    b.ToTable("Cars", t =>
                        {
                            t.HasCheckConstraint("YearOfProd", "YearOfProd > 2000 AND YearOfProd < 2022");
                        });
                });

            modelBuilder.Entity("lab2.Client", b =>
                {
                    b.Property<int>("PHnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PHnumber"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PHnumber");

                    b.ToTable("Clients");

                    b.UseTptMappingStrategy();

                    b.HasData(
                        new
                        {
                            PHnumber = 1,
                            FullName = "Tom Cruise"
                        });
                });

            modelBuilder.Entity("lab2.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentId"));

                    b.Property<int>("ClientPHnumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfEnroll")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("ClientPHnumber");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            EnrollmentId = 1,
                            ClientPHnumber = 1,
                            DateOfEnroll = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("lab2.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<string>("CarVINcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(18)");

                    b.Property<int>("ClientPHnumber")
                        .HasColumnType("int");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CarVINcode");

                    b.HasIndex("ClientPHnumber");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("lab2.ListOfProvidedServices", b =>
                {
                    b.Property<int>("ListOfProvidedServicesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListOfProvidedServicesId"));

                    b.Property<int>("InvoiceOrderId")
                        .HasColumnType("int");

                    b.Property<int>("ListOfServicesServiceID")
                        .HasColumnType("int");

                    b.HasKey("ListOfProvidedServicesId");

                    b.HasIndex("InvoiceOrderId");

                    b.HasIndex("ListOfServicesServiceID");

                    b.ToTable("ListsOfProvidedServices");
                });

            modelBuilder.Entity("lab2.ListOfServices", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceID"));

                    b.Property<double>("Complexity")
                        .HasColumnType("float");

                    b.Property<double>("CostOfAnHour")
                        .HasColumnType("float");

                    b.Property<string>("NameOfService")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceID");

                    b.ToTable("ListsOfServices");
                });

            modelBuilder.Entity("lab2.ListOfSpareParts", b =>
                {
                    b.Property<int>("SPnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SPnumber"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceOrderId")
                        .HasColumnType("int");

                    b.Property<string>("NameOfPart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("SPnumber");

                    b.HasIndex("InvoiceOrderId");

                    b.ToTable("ListsOfSpareParts");
                });

            modelBuilder.Entity("lab2.VIPclient", b =>
                {
                    b.HasBaseType("lab2.Client");

                    b.Property<int>("YearsOfService")
                        .HasColumnType("int");

                    b.ToTable("VIPs");
                });

            modelBuilder.Entity("lab2.ObsoleteClient", b =>
                {
                    b.HasBaseType("lab2.VIPclient");

                    b.Property<DateTime>("DateOfDeletion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.ToTable("Obsoletes", (string)null);
                });

            modelBuilder.Entity("lab2.Enrollment", b =>
                {
                    b.HasOne("lab2.Client", "Client")
                        .WithMany("Enrollments")
                        .HasForeignKey("ClientPHnumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("lab2.Invoice", b =>
                {
                    b.HasOne("lab2.Car", "Car")
                        .WithMany("Invoices")
                        .HasForeignKey("CarVINcode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lab2.Client", "Client")
                        .WithMany("Invoices")
                        .HasForeignKey("ClientPHnumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("lab2.ListOfProvidedServices", b =>
                {
                    b.HasOne("lab2.Invoice", "Invoice")
                        .WithMany("ListOfProvidedServices")
                        .HasForeignKey("InvoiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lab2.ListOfServices", "ListOfServices")
                        .WithMany("ListOfProvidedServices")
                        .HasForeignKey("ListOfServicesServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("ListOfServices");
                });

            modelBuilder.Entity("lab2.ListOfSpareParts", b =>
                {
                    b.HasOne("lab2.Invoice", "Invoice")
                        .WithMany("ListOfSpareParts")
                        .HasForeignKey("InvoiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("lab2.VIPclient", b =>
                {
                    b.HasOne("lab2.Client", null)
                        .WithOne()
                        .HasForeignKey("lab2.VIPclient", "PHnumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("lab2.ObsoleteClient", b =>
                {
                    b.HasOne("lab2.VIPclient", null)
                        .WithOne()
                        .HasForeignKey("lab2.ObsoleteClient", "PHnumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("lab2.Car", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("lab2.Client", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("lab2.Invoice", b =>
                {
                    b.Navigation("ListOfProvidedServices");

                    b.Navigation("ListOfSpareParts");
                });

            modelBuilder.Entity("lab2.ListOfServices", b =>
                {
                    b.Navigation("ListOfProvidedServices");
                });
#pragma warning restore 612, 618
        }
    }
}