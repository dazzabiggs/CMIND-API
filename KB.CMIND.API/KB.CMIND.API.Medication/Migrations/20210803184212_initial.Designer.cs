﻿// <auto-generated />
using System;
using KB.CMIND.API.Medication.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KB.CMIND.API.Medication.Migrations
{
    [DbContext(typeof(MedicationContext))]
    [Migration("20210803184212_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("medication_api")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("KB.CMIND.API.Medication.Models.MedicationDelivery", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ChildID")
                        .HasColumnType("integer");

                    b.Property<string>("Dosage")
                        .HasColumnType("text");

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MedicationItemID")
                        .HasColumnType("integer");

                    b.Property<string>("Times")
                        .HasColumnType("text");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ID");

                    b.HasIndex("MedicationItemID");

                    b.ToTable("MedicationDelivery");
                });

            modelBuilder.Entity("KB.CMIND.API.Medication.Models.MedicationItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("MedicationTypeID")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("MedicationTypeID");

                    b.ToTable("MedicationItems");
                });

            modelBuilder.Entity("KB.CMIND.API.Medication.Models.MedicationType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("MedicationTypes");
                });

            modelBuilder.Entity("KB.CMIND.API.Medication.Models.MedicationDelivery", b =>
                {
                    b.HasOne("KB.CMIND.API.Medication.Models.MedicationItem", "MedicationItems")
                        .WithMany("MedicationDeliveries")
                        .HasForeignKey("MedicationItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicationItems");
                });

            modelBuilder.Entity("KB.CMIND.API.Medication.Models.MedicationItem", b =>
                {
                    b.HasOne("KB.CMIND.API.Medication.Models.MedicationType", "MedicationTypes")
                        .WithMany("MedicationItems")
                        .HasForeignKey("MedicationTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicationTypes");
                });

            modelBuilder.Entity("KB.CMIND.API.Medication.Models.MedicationItem", b =>
                {
                    b.Navigation("MedicationDeliveries");
                });

            modelBuilder.Entity("KB.CMIND.API.Medication.Models.MedicationType", b =>
                {
                    b.Navigation("MedicationItems");
                });
#pragma warning restore 612, 618
        }
    }
}
