using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBM.Models
{
    public partial class DBMContext : IdentityDbContext
    {
        public DBMContext()
        {
        }

        public DBMContext(DbContextOptions<DBMContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Announcement> Announcement { get; set; }
        public virtual DbSet<AssignmentSubmission> AssignmentSubmission { get; set; }
        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<CourseContent> CourseContent { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<GroupsAssignedPermissions> GroupsAssignedPermissions { get; set; }
        public virtual DbSet<Institute> Institute { get; set; }
        public virtual DbSet<Lectures> Lectures { get; set; }
        public virtual DbSet<LoginHistory> LoginHistory { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<PermissionLookup> PermissionLookup { get; set; }
        public virtual DbSet<UserAssignedGroups> UserAssignedGroups { get; set; }
        public virtual DbSet<UserGroups> UserGroups { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=HARIS;Database=DBM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Announcement)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Announcem__Cours__2C3393D0");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AnnouncementCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Announcem__Creat__2A4B4B5E");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.AnnouncementUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Announcem__Updat__2B3F6F97");
            });

            modelBuilder.Entity<AssignmentSubmission>(entity =>
            {
                entity.Property(e => e.AssignmentFilePath)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SubmissionDate).HasColumnType("datetime");

                entity.Property(e => e.SubmissionTime).HasColumnType("datetime");

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.AssignmentSubmission)
                    .HasForeignKey(d => d.AssignmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Assig__3D5E1FD2");
            });

            modelBuilder.Entity<Assignments>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubmissionDate).HasColumnType("datetime");

                entity.Property(e => e.SubmissionTime).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Cours__3A81B327");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AssignmentsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Creat__38996AB5");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.AssignmentsUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Assignmen__Updat__398D8EEE");
            });

            modelBuilder.Entity<CourseContent>(entity =>
            {
                entity.Property(e => e.AddedOn).HasColumnType("datetime");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.AddedByNavigation)
                    .WithMany(p => p.CourseContentAddedByNavigation)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseCon__Added__2F10007B");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseContent)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseCon__Cours__30F848ED");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.CourseContentUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseCon__Updat__300424B4");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.Property(e => e.CourseCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CoursesCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__Created__239E4DCF");

                entity.HasOne(d => d.Institute)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.InstituteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__Institu__21B6055D");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.CoursesTeacher)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__Teacher__22AA2996");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.CoursesUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__Updated__24927208");
            });

            modelBuilder.Entity<GroupsAssignedPermissions>(entity =>
            {
                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.GroupsAssignedPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupsAss__Permi__182C9B23");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.GroupsAssignedPermissions)
                    .HasForeignKey(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupsAss__UserG__173876EA");
            });

            modelBuilder.Entity<Institute>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lectures>(entity =>
            {
                entity.Property(e => e.LectureFilePath)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Lectures__Course__276EDEB3");
            });

            modelBuilder.Entity<LoginHistory>(entity =>
            {
                entity.Property(e => e.StatusChangedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notes__CourseId__35BCFE0A");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.NotesCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notes__CreatedBy__33D4B598");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.NotesUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notes__UpdatedBy__34C8D9D1");
            });

            modelBuilder.Entity<UserAssignedGroups>(entity =>
            {
                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.UserAssignedGroups)
                    .HasForeignKey(d => d.UserGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserAssig__UserG__1ED998B2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAssignedGroups)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserAssig__UserI__1DE57479");
            });

            modelBuilder.Entity<UserGroups>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Institute)
                    .WithMany(p => p.UserGroups)
                    .HasForeignKey(d => d.InstituteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserGroup__Insti__1273C1CD");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Cnic)
                    .IsRequired()
                    .HasColumnName("CNIC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Institute)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.InstituteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__Institute__1B0907CE");
            });
        }
    }
}
