﻿// <auto-generated />
using KB.CMIND.API.Incidents.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KB.CMIND.API.Incidents.Migrations
{
    [DbContext(typeof(IncidentsContext))]
    partial class IncidentsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("incidents_api")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("KB.AUTH.Middleware.Entities.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClientID")
                        .HasColumnType("text");

                    b.Property<string>("ClientSecret")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("ClientDetails");
                });

            modelBuilder.Entity("KB.CMIND.API.Incidents.Entities.Incident", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ChildID")
                        .HasColumnType("integer");

                    b.Property<int>("IncidentTypeID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("IncidentTypeID");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("KB.CMIND.API.Incidents.Entities.IncidentType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("IncidentTypes");
                });

            modelBuilder.Entity("KB.CMIND.API.Incidents.Entities.Incident", b =>
                {
                    b.HasOne("KB.CMIND.API.Incidents.Entities.IncidentType", "IncidentTypes")
                        .WithMany("Incidents")
                        .HasForeignKey("IncidentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IncidentTypes");
                });

            modelBuilder.Entity("KB.CMIND.API.Incidents.Entities.IncidentType", b =>
                {
                    b.Navigation("Incidents");
                });
#pragma warning restore 612, 618
        }
    }
}
