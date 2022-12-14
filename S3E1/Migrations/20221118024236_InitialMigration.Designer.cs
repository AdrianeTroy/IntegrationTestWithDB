// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using S3E1.Data;

#nullable disable

namespace S3E1.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20221118024236_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("S3E1.Entities.CartItemEntity", b =>
                {
                    b.Property<Guid>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ItemPrice")
                        .HasColumnType("float");

                    b.Property<string>("ItemStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderEntityOrderID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ItemID");

                    b.HasIndex("OrderEntityOrderID");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("S3E1.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("OrderTotalPrice")
                        .HasColumnType("float");

                    b.Property<Guid>("UserOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderID");

                    b.HasIndex("UserOrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("S3E1.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("S3E1.Entities.CartItemEntity", b =>
                {
                    b.HasOne("S3E1.Entities.OrderEntity", null)
                        .WithMany("CartItemEntity")
                        .HasForeignKey("OrderEntityOrderID");
                });

            modelBuilder.Entity("S3E1.Entities.OrderEntity", b =>
                {
                    b.HasOne("S3E1.Entities.UserEntity", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("S3E1.Entities.OrderEntity", b =>
                {
                    b.Navigation("CartItemEntity");
                });

            modelBuilder.Entity("S3E1.Entities.UserEntity", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
