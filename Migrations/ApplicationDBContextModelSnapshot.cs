﻿// <auto-generated />
using System;
using InsuranceAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InsuranceAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InsuranceAPI.Models.DamagedPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ExpertiseReportID")
                        .HasColumnType("integer");

                    b.Property<bool>("IsRepairable")
                        .HasColumnType("boolean");

                    b.Property<string>("PartName")
                        .HasColumnType("text");

                    b.Property<decimal>("PartPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ExpertiseReportID");

                    b.ToTable("DamagedPart");
                });

            modelBuilder.Entity("InsuranceAPI.Models.Expert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("City")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Expert");
                });

            modelBuilder.Entity("InsuranceAPI.Models.ExpertiseReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DamagedPoint")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImpactPoint")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Incident")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("IncidentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("LaborCost")
                        .HasColumnType("numeric");

                    b.Property<string>("LaborDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PaintAndAdditions")
                        .HasColumnType("integer");

                    b.Property<int>("Reduction")
                        .HasColumnType("integer");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ServiceOrderId")
                        .HasColumnType("integer");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("VehicleConditionBeforeIncident")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ServiceOrderId")
                        .IsUnique();

                    b.ToTable("ExpertiseReport");
                });

            modelBuilder.Entity("InsuranceAPI.Models.Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AgencyCode")
                        .HasColumnType("integer");

                    b.Property<int>("City")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Insurance");
                });

            modelBuilder.Entity("InsuranceAPI.Models.ServiceOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AssociatedExpertID")
                        .HasColumnType("integer");

                    b.Property<int?>("AtFaultCity")
                        .HasColumnType("integer");

                    b.Property<string>("AtFaultFullName")
                        .HasColumnType("text");

                    b.Property<int?>("AtFaultInsuranceID")
                        .HasColumnType("integer");

                    b.Property<string>("AtFaultPolicyNumber")
                        .HasColumnType("text");

                    b.Property<string>("IssueDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VehicleGenre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VehicleLicensePlate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VehicleMakerAndModel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VehicleSeriesNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VehicleWeight")
                        .HasColumnType("integer");

                    b.Property<int>("VictimCity")
                        .HasColumnType("integer");

                    b.Property<string>("VictimFullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("VictimInsuranceID")
                        .HasColumnType("integer");

                    b.Property<string>("VictimPolicyNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedExpertID");

                    b.HasIndex("AtFaultInsuranceID");

                    b.HasIndex("VictimInsuranceID");

                    b.ToTable("ServiceOrder");
                });

            modelBuilder.Entity("InsuranceAPI.Models.DamagedPart", b =>
                {
                    b.HasOne("InsuranceAPI.Models.ExpertiseReport", "ExpertiseReport")
                        .WithMany("DamagedParts")
                        .HasForeignKey("ExpertiseReportID");

                    b.Navigation("ExpertiseReport");
                });

            modelBuilder.Entity("InsuranceAPI.Models.ExpertiseReport", b =>
                {
                    b.HasOne("InsuranceAPI.Models.ServiceOrder", "ServiceOrder")
                        .WithOne("ExpertiseReport")
                        .HasForeignKey("InsuranceAPI.Models.ExpertiseReport", "ServiceOrderId");

                    b.Navigation("ServiceOrder");
                });

            modelBuilder.Entity("InsuranceAPI.Models.ServiceOrder", b =>
                {
                    b.HasOne("InsuranceAPI.Models.Expert", "AssociatedExpert")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("AssociatedExpertID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsuranceAPI.Models.Insurance", "AtFaultInsurance")
                        .WithMany("ServiceOrdersAtFault")
                        .HasForeignKey("AtFaultInsuranceID");

                    b.HasOne("InsuranceAPI.Models.Insurance", "VictimInsurance")
                        .WithMany("ServiceOrdersVictim")
                        .HasForeignKey("VictimInsuranceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedExpert");

                    b.Navigation("AtFaultInsurance");

                    b.Navigation("VictimInsurance");
                });

            modelBuilder.Entity("InsuranceAPI.Models.Expert", b =>
                {
                    b.Navigation("ServiceOrders");
                });

            modelBuilder.Entity("InsuranceAPI.Models.ExpertiseReport", b =>
                {
                    b.Navigation("DamagedParts");
                });

            modelBuilder.Entity("InsuranceAPI.Models.Insurance", b =>
                {
                    b.Navigation("ServiceOrdersAtFault");

                    b.Navigation("ServiceOrdersVictim");
                });

            modelBuilder.Entity("InsuranceAPI.Models.ServiceOrder", b =>
                {
                    b.Navigation("ExpertiseReport");
                });
#pragma warning restore 612, 618
        }
    }
}
