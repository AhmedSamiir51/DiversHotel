﻿// <auto-generated />
using System;
using Divers_Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Divers_Hotel.Migrations
{
    [DbContext(typeof(HotelModel))]
    [Migration("20210823012843_addseasonmeal")]
    partial class addseasonmeal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Divers_Hotel.Models.MealPlan", b =>
                {
                    b.Property<int>("MealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MealId");

                    b.ToTable("MealPlans");
                });

            modelBuilder.Entity("Divers_Hotel.Models.MealSeason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameSeason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MealSeasons");
                });

            modelBuilder.Entity("Divers_Hotel.Models.PriceMealsPerSeason", b =>
                {
                    b.Property<int>("MealID")
                        .HasColumnType("int");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("MealID", "SeasonId");

                    b.HasIndex("SeasonId");

                    b.ToTable("PriceMealsPerSeasons");
                });

            modelBuilder.Entity("Divers_Hotel.Models.PriceRoomsPerSeason", b =>
                {
                    b.Property<int>("IdRoom")
                        .HasColumnType("int");

                    b.Property<int>("IdSeason")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("IdRoom", "IdSeason");

                    b.HasIndex("IdSeason");

                    b.ToTable("PriceRoomsPerSeason");
                });

            modelBuilder.Entity("Divers_Hotel.Models.ReservationModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Adult")
                        .HasColumnType("int");

                    b.Property<DateTime>("Check_In")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Check_Out")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Children")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NameMale")
                        .HasColumnType("int");

                    b.Property<int>("RoomType")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ReservationModel");
                });

            modelBuilder.Entity("Divers_Hotel.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Divers_Hotel.Models.RoomSeason", b =>
                {
                    b.Property<int>("SeasonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameSeason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("SeasonID");

                    b.ToTable("RoomSeasons");
                });

            modelBuilder.Entity("Divers_Hotel.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLoggin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Divers_Hotel.Models.PriceMealsPerSeason", b =>
                {
                    b.HasOne("Divers_Hotel.Models.MealPlan", "MealPlan")
                        .WithMany("priceMealsPerSeasons")
                        .HasForeignKey("MealID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Divers_Hotel.Models.MealSeason", "MealSeason")
                        .WithMany("priceMealsPerSeasons")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MealPlan");

                    b.Navigation("MealSeason");
                });

            modelBuilder.Entity("Divers_Hotel.Models.PriceRoomsPerSeason", b =>
                {
                    b.HasOne("Divers_Hotel.Models.Room", "Room")
                        .WithMany("priceRoomsPerSeason")
                        .HasForeignKey("IdRoom")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Divers_Hotel.Models.RoomSeason", "RoomSeason")
                        .WithMany("priceRoomsPerSeason")
                        .HasForeignKey("IdSeason")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("RoomSeason");
                });

            modelBuilder.Entity("Divers_Hotel.Models.MealPlan", b =>
                {
                    b.Navigation("priceMealsPerSeasons");
                });

            modelBuilder.Entity("Divers_Hotel.Models.MealSeason", b =>
                {
                    b.Navigation("priceMealsPerSeasons");
                });

            modelBuilder.Entity("Divers_Hotel.Models.Room", b =>
                {
                    b.Navigation("priceRoomsPerSeason");
                });

            modelBuilder.Entity("Divers_Hotel.Models.RoomSeason", b =>
                {
                    b.Navigation("priceRoomsPerSeason");
                });
#pragma warning restore 612, 618
        }
    }
}
