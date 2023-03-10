// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopping_center.Models;

namespace Shopping_center.Migrations
{
    [DbContext(typeof(ProductDBContext))]
    [Migration("20230228053412_new1")]
    partial class new1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BussinessModel.Products", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductDetails")
                        .IsRequired()
                        .HasColumnType("Nvarchar(300)");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.HasKey("PId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BussinessModel.PurchaseProduct", b =>
                {
                    b.Property<int>("PurchaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PId")
                        .HasColumnType("int");

                    b.Property<int>("UId")
                        .HasColumnType("int");

                    b.HasKey("PurchaseID");

                    b.HasIndex("PId");

                    b.HasIndex("UId");

                    b.ToTable("PurchaseProducts");
                });

            modelBuilder.Entity("BussinessModel.Users", b =>
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

            modelBuilder.Entity("BussinessModel.PurchaseProduct", b =>
                {
                    b.HasOne("BussinessModel.Products", "Products")
                        .WithMany()
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BussinessModel.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
