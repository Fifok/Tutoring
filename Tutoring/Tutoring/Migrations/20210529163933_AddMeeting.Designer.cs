﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tutoring.Db;

namespace Tutoring.Migrations
{
    [DbContext(typeof(TutoringContext))]
    [Migration("20210529163933_AddMeeting")]
    partial class AddMeeting
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tutoring.Models.Db.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.ContentItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContentType")
                        .HasColumnType("int");

                    b.Property<int>("TutorialId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TutorialId");

                    b.ToTable("ContentItem");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.Meeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TutoringId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TutoringId");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.StudentTutoring", b =>
                {
                    b.Property<int>("TutoringId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("TutoringId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentTutoring");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.Tutorial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Tutorials");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.TutorialTag", b =>
                {
                    b.Property<int>("TutorialId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("TutorialId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("TutorialTag");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.TutoringModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Tutorings");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.UserMeeting", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("MeetingId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "MeetingId");

                    b.HasIndex("MeetingId");

                    b.ToTable("UserMeeting");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.Comment", b =>
                {
                    b.HasOne("Tutoring.Models.Db.Models.User", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.ContentItem", b =>
                {
                    b.HasOne("Tutoring.Models.Db.Models.Tutorial", "Tutorial")
                        .WithMany("Content")
                        .HasForeignKey("TutorialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tutorial");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.Meeting", b =>
                {
                    b.HasOne("Tutoring.Models.Db.Models.User", "Author")
                        .WithMany("CreatedMeetings")
                        .HasForeignKey("AuthorId")
                        .IsRequired();

                    b.HasOne("Tutoring.Models.Db.Models.TutoringModel", "Tutoring")
                        .WithMany("Meetings")
                        .HasForeignKey("TutoringId")
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Tutoring");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.StudentTutoring", b =>
                {
                    b.HasOne("Tutoring.Models.Db.Models.User", "Student")
                        .WithMany("ParticipateTutorings")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tutoring.Models.Db.Models.TutoringModel", "Tutoring")
                        .WithMany("Students")
                        .HasForeignKey("TutoringId")
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Tutoring");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.Tutorial", b =>
                {
                    b.HasOne("Tutoring.Models.Db.Models.User", "Author")
                        .WithMany("CreatedTutorials")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.TutorialTag", b =>
                {
                    b.HasOne("Tutoring.Models.Db.Models.Tag", "Tag")
                        .WithMany("Tutorials")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tutoring.Models.Db.Models.Tutorial", "Tutorial")
                        .WithMany("Tags")
                        .HasForeignKey("TutorialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("Tutorial");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.TutoringModel", b =>
                {
                    b.HasOne("Tutoring.Models.Db.Models.User", "Teacher")
                        .WithMany("CreatedTutorings")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.UserMeeting", b =>
                {
                    b.HasOne("Tutoring.Models.Db.Models.Meeting", "Meeting")
                        .WithMany("Users")
                        .HasForeignKey("MeetingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tutoring.Models.Db.Models.User", "User")
                        .WithMany("ParticipateMeetings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meeting");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.Meeting", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.Tag", b =>
                {
                    b.Navigation("Tutorials");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.Tutorial", b =>
                {
                    b.Navigation("Content");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.TutoringModel", b =>
                {
                    b.Navigation("Meetings");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Tutoring.Models.Db.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("CreatedMeetings");

                    b.Navigation("CreatedTutorials");

                    b.Navigation("CreatedTutorings");

                    b.Navigation("ParticipateMeetings");

                    b.Navigation("ParticipateTutorings");
                });
#pragma warning restore 612, 618
        }
    }
}
