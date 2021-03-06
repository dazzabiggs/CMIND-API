// <auto-generated />
using KB.CMIND.API.CMDetails.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KB.CMIND.API.CMDetails.Migrations
{
    [DbContext(typeof(CMDetailsContext))]
    partial class CMDetailsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("details_api")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("KB.CMIND.API.CMDetails.Entities.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnType("text");

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

            modelBuilder.Entity("KB.CMIND.API.CMDetails.Entities.ChildMinder", b =>
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

            modelBuilder.Entity("KB.CMIND.API.CMDetails.Entities.Client", b =>
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

            modelBuilder.Entity("KB.CMIND.API.CMDetails.Entities.Organisation", b =>
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

            modelBuilder.Entity("KB.CMIND.API.CMDetails.Entities.ChildMinder", b =>
                {
                    b.HasOne("KB.CMIND.API.CMDetails.Entities.Address", "Adddress")
                        .WithMany("ChildMinders")
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adddress");
                });

            modelBuilder.Entity("KB.CMIND.API.CMDetails.Entities.Organisation", b =>
                {
                    b.HasOne("KB.CMIND.API.CMDetails.Entities.Address", "Adddress")
                        .WithMany("Organisations")
                        .HasForeignKey("AddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adddress");
                });

            modelBuilder.Entity("KB.CMIND.API.CMDetails.Entities.Address", b =>
                {
                    b.Navigation("ChildMinders");

                    b.Navigation("Organisations");
                });
#pragma warning restore 612, 618
        }
    }
}
