﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(ScadaDBContext))]
    partial class ScadaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("webapi.model.Alarm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnalogInputId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Limit")
                        .HasColumnType("REAL");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AnalogInputId");

                    b.ToTable("Alarms");
                });

            modelBuilder.Entity("webapi.model.AnalogInput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdressId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("HighLimit")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsScanning")
                        .HasColumnType("INTEGER");

                    b.Property<double>("LowLimit")
                        .HasColumnType("REAL");

                    b.Property<double>("ScanTime")
                        .HasColumnType("REAL");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.ToTable("AnalogInputs");
                });

            modelBuilder.Entity("webapi.model.AnalogOutput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdressId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("HighLimit")
                        .HasColumnType("REAL");

                    b.Property<double>("InitialValue")
                        .HasColumnType("REAL");

                    b.Property<double>("LowLimit")
                        .HasColumnType("REAL");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.ToTable("AnalogOutputs");
                });

            modelBuilder.Entity("webapi.model.DigitalInput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdressId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsScanning")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ScanTime")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.ToTable("DigitalInputs");
                });

            modelBuilder.Entity("webapi.model.DigitalOutput", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdressId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("InitialValue")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.ToTable("DigitalOutputs");
                });

            modelBuilder.Entity("webapi.model.IOAdress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("webapi.model.Alarm", b =>
                {
                    b.HasOne("webapi.model.AnalogInput", "AnalogInput")
                        .WithMany("Alarms")
                        .HasForeignKey("AnalogInputId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnalogInput");
                });

            modelBuilder.Entity("webapi.model.AnalogInput", b =>
                {
                    b.HasOne("webapi.model.IOAdress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("webapi.model.AnalogOutput", b =>
                {
                    b.HasOne("webapi.model.IOAdress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("webapi.model.DigitalInput", b =>
                {
                    b.HasOne("webapi.model.IOAdress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("webapi.model.DigitalOutput", b =>
                {
                    b.HasOne("webapi.model.IOAdress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("webapi.model.AnalogInput", b =>
                {
                    b.Navigation("Alarms");
                });
#pragma warning restore 612, 618
        }
    }
}
