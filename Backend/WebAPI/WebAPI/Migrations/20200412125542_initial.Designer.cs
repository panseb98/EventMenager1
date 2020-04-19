﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Database;

namespace WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200412125542_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.Authorization.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("USER_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("USER_BIRTH")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnName("USER_CITY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnName("USER_EMAIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnName("USER_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Password")
                        .HasColumnName("USER_PASSWORD")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnName("USER_PASSWORD_SALT")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Surname")
                        .HasColumnName("USER_SURNAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnName("USER_NICK")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebAPI.Models.Events.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EVENT_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EventCreation")
                        .HasColumnName("EVENT_CREATION")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventDate")
                        .HasColumnName("ECENT_DATE")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventDescription")
                        .HasColumnName("EVENT_DESC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventLocation")
                        .HasColumnName("EVENT_LOCATION")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .HasColumnName("EVENT_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventTypeId")
                        .HasColumnName("EVENT_TYPE_ID")
                        .HasColumnType("int");

                    b.Property<int>("EventUserId")
                        .HasColumnName("EVENT_USER_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("EventUserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("WebAPI.Models.Events.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EVENT_TYPE_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EventTypeName")
                        .HasColumnName("EVENT_TYPE_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("WebAPI.Models.Events.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RECEIPT_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnName("RECEIPT_EVENT_ID")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnName("RECEIPT_USER_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("WebAPI.Models.Events.ReceiptItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RECEIPT_PROD_ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnName("RECEIPT_PROD_AMOUNT")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnName("RECEIPT_PROD_PRICE")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .HasColumnName("RECEIPT_PROD_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReceiptId")
                        .HasColumnName("RECEIPT_PROD_REC_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiptId");

                    b.ToTable("ReceiptItems");
                });

            modelBuilder.Entity("WebAPI.Models.Events.Event", b =>
                {
                    b.HasOne("WebAPI.Models.Events.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Authorization.User", "EventUser")
                        .WithMany()
                        .HasForeignKey("EventUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAPI.Models.Events.Receipt", b =>
                {
                    b.HasOne("WebAPI.Models.Events.Event", "Event")
                        .WithMany("EventReceipts")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Authorization.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebAPI.Models.Events.ReceiptItem", b =>
                {
                    b.HasOne("WebAPI.Models.Events.Receipt", "Receipt")
                        .WithMany("Items")
                        .HasForeignKey("ReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}