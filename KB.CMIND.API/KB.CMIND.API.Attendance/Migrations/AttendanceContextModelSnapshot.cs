// <auto-generated />
using KB.CMIND.API.Attendance.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KB.CMIND.API.Attendance.Migrations
{
    [DbContext(typeof(AttendanceContext))]
    partial class AttendanceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("attendance_api")
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

            modelBuilder.Entity("KB.CMIND.API.Attendance.Entities.AttendanceLog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AttendanceTypeID")
                        .HasColumnType("integer");

                    b.Property<int>("ChildID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("AttendanceTypeID");

                    b.ToTable("AttendanceLogs");
                });

            modelBuilder.Entity("KB.CMIND.API.Attendance.Entities.AttendanceType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("AttendanceTypes");
                });

            modelBuilder.Entity("KB.CMIND.API.Attendance.Entities.AttendanceLog", b =>
                {
                    b.HasOne("KB.CMIND.API.Attendance.Entities.AttendanceType", "AttendanceTypes")
                        .WithMany("Attendances")
                        .HasForeignKey("AttendanceTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttendanceTypes");
                });

            modelBuilder.Entity("KB.CMIND.API.Attendance.Entities.AttendanceType", b =>
                {
                    b.Navigation("Attendances");
                });
#pragma warning restore 612, 618
        }
    }
}
