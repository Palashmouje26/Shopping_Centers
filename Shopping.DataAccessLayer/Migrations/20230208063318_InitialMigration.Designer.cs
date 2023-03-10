// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Shopping_center.Models;

namespace Shopping.DataAccessLayer.Migrations
{
    [DbContext(typeof(ProductDBContext))]
    [Migration("20230208063318_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shopping_center.Models.Products", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductDetails")
                        .HasColumnType("Nvarchar(300)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.HasKey("PId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shopping_center.Models.Users", b =>
                {
                    b.Property<int>("UId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhoneNo")
                        .HasColumnType("Nvarchar(12)");

                    b.Property<string>("UserAddress")
                        .HasColumnType("Nvarchar(300)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.HasKey("UId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
