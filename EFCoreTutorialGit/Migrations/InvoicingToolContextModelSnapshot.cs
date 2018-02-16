﻿// <auto-generated />
using EFCoreTutorialGit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EFCoreTutorialGit.Migrations
{
    [DbContext(typeof(InvoicingToolContext))]
    partial class InvoicingToolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreTutorialGit.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<float?>("Amount");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("Date");

                    b.Property<string>("InvoiceName");

                    b.Property<int?>("InvoiceSchedId");

                    b.Property<bool?>("IsAccured");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("Date");

                    b.HasKey("InvoiceId");

                    b.HasIndex("InvoiceSchedId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("EFCoreTutorialGit.InvoiceSchedule", b =>
                {
                    b.Property<int>("InvoiceSchedId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MailId");

                    b.Property<int?>("MailId1");

                    b.Property<string>("ReferenceNo");

                    b.Property<DateTime?>("SchedEndDate")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("SchedStartDate")
                        .HasColumnType("Date");

                    b.Property<string>("ScheduleName");

                    b.Property<string>("ScheduleType");

                    b.HasKey("InvoiceSchedId");

                    b.HasIndex("MailId1");

                    b.ToTable("InvoiceSchedule");
                });

            modelBuilder.Entity("EFCoreTutorialGit.Mail", b =>
                {
                    b.Property<int>("MailId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("InvoiceSchedId");

                    b.Property<bool?>("IsHTML");

                    b.Property<bool?>("IsSent");

                    b.Property<string>("MailBody");

                    b.Property<string>("MailSubject");

                    b.Property<string>("MailTo");

                    b.HasKey("MailId");

                    b.HasIndex("InvoiceSchedId")
                        .IsUnique()
                        .HasFilter("[InvoiceSchedId] IS NOT NULL");

                    b.ToTable("Mail");
                });

            modelBuilder.Entity("EFCoreTutorialGit.Invoice", b =>
                {
                    b.HasOne("EFCoreTutorialGit.InvoiceSchedule", "InvoiceSchedule")
                        .WithMany("Invoices")
                        .HasForeignKey("InvoiceSchedId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreTutorialGit.InvoiceSchedule", b =>
                {
                    b.HasOne("EFCoreTutorialGit.Mail", "Mail")
                        .WithMany()
                        .HasForeignKey("MailId1");
                });

            modelBuilder.Entity("EFCoreTutorialGit.Mail", b =>
                {
                    b.HasOne("EFCoreTutorialGit.InvoiceSchedule", "InvoiceSchedules")
                        .WithOne()
                        .HasForeignKey("EFCoreTutorialGit.Mail", "InvoiceSchedId");
                });
#pragma warning restore 612, 618
        }
    }
}
