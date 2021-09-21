﻿// <auto-generated />
using KB.CMIND.API.CMDetails.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KB.CMIND.API.CMDetails.Migrations
{
    [DbContext(typeof(CMDetailsContext))]
    [Migration("20210803191126_Addtest")]
    partial class Addtest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("details_api")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("KB.CMIND.API.CMDetails.Models.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("County")
                        .HasColumnType("text");

                    b.Property<string>("PostCode")
                        .HasColumnType("text");

                    b.Property<string>("Street1")
                        .HasColumnType("text");

                    b.Property<string>("Street2")
                        .HasColumnType("text");

                    b.Property<string>("Test")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("KB.CMIND.API.CMDetails.Models.ChildMinder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressID")
                        .HasColumnType("integer");

                    b.Property<string>("DOB")
                        .HasColumnType("text");

                    b.Property<string>("Firstname")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.ToTable("Childminders");
                });

            modelBuilder.Entity("KB.CMIND.API.CMDetails.Models.Organisation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressID")
                        .HasColumnType("integer");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("KB.CMIND.API.CMDetails.Models.ChildMinder", b =>
                {
                    b.HasOne("KB.CMIND.API.CMDetails.Models.Address", "Adddress")
                        .WithMany("ChildMinders")
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adddress");
                });

            modelBuilder.Entity("KB.CMIND.API.CMDetails.Models.Organisation", b =>
                {
                    b.HasOne("KB.CMIND.API.CMDetails.Models.Address", "Adddress")
                        .WithMany("Organisations")
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adddress");
                });

            modelBuilder.Entity("KB.CMIND.API.CMDetails.Models.Address", b =>
                {
                    b.Navigation("ChildMinders");

                    b.Navigation("Organisations");
                });
#pragma warning restore 612, 618
        }
    }
}
