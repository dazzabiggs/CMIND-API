// <auto-generated />
using System;
using KB.CMIND.API.ParentChild.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KB.CMIND.API.ParentChild.Migrations
{
    [DbContext(typeof(ParentChildContext))]
    [Migration("20210803184313_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("child_record_api")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ChildParent", b =>
                {
                    b.Property<int>("ChildrenID")
                        .HasColumnType("integer");

                    b.Property<int>("ParentsID")
                        .HasColumnType("integer");

                    b.HasKey("ChildrenID", "ParentsID");

                    b.HasIndex("ParentsID");

                    b.ToTable("ChildParent");
                });

            modelBuilder.Entity("KB.CMIND.API.ParentChild.Models.Address", b =>
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

                    b.HasKey("ID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("KB.CMIND.API.ParentChild.Models.Child", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressID")
                        .HasColumnType("integer");

                    b.Property<string>("Allergies")
                        .HasColumnType("text");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Firstname")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("KB.CMIND.API.ParentChild.Models.Parent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressID")
                        .HasColumnType("integer");

                    b.Property<string>("Firstname")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("ChildParent", b =>
                {
                    b.HasOne("KB.CMIND.API.ParentChild.Models.Child", null)
                        .WithMany()
                        .HasForeignKey("ChildrenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KB.CMIND.API.ParentChild.Models.Parent", null)
                        .WithMany()
                        .HasForeignKey("ParentsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KB.CMIND.API.ParentChild.Models.Child", b =>
                {
                    b.HasOne("KB.CMIND.API.ParentChild.Models.Address", "Adddress")
                        .WithMany("Children")
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adddress");
                });

            modelBuilder.Entity("KB.CMIND.API.ParentChild.Models.Parent", b =>
                {
                    b.HasOne("KB.CMIND.API.ParentChild.Models.Address", "Adddress")
                        .WithMany("Parents")
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adddress");
                });

            modelBuilder.Entity("KB.CMIND.API.ParentChild.Models.Address", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Parents");
                });
#pragma warning restore 612, 618
        }
    }
}
