using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StartCodingNowWebManager.FF
{
    public partial class QL_SCN : DbContext
    {
        public QL_SCN()
        {
        }

        public QL_SCN(DbContextOptions<QL_SCN> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
       
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<ClassStudent> ClassStudent { get; set; }
        public virtual DbSet<Course> Course { get; set; }
       
      
        
        public virtual DbSet<Phanbo> Phanbo { get; set; }
      
        public virtual DbSet<RigistrationCourse> RigistrationCourse { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<TeachingClass> TeachingClass { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LE_THANH_DAT\\SQLEXPRESS01;Initial Catalog=QLweb1;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Idteacher)
                    .HasName("ACCOUNT_pk");

                entity.ToTable("ACCOUNT");

                entity.Property(e => e.Idteacher)
                    .HasColumnName("IDTeacher")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdteacherNavigation)
                    .WithOne(p => p.Account)
                    .HasForeignKey<Account>(d => d.Idteacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNT_TEACHER");
            });

           

          

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Idclass)
                    .HasName("CLASS_pk");

                entity.ToTable("CLASS");

                entity.Property(e => e.Idclass).HasColumnName("IDClass");

                entity.Property(e => e.FinishDay).HasColumnType("date");

                entity.Property(e => e.Idcourse)
                    .IsRequired()
                    .HasColumnName("IDCourse")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NameClass).HasMaxLength(100);

                entity.Property(e => e.StartDay).HasColumnType("date");

                entity.HasOne(d => d.IdcourseNavigation)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.Idcourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLASS_COURSE");
            });

            modelBuilder.Entity<ClassStudent>(entity =>
            {
                entity.HasKey(e => new { e.Idclass, e.Idstudent, e.Session })
                    .HasName("PK_CLASS_STUDENT_1");

                entity.ToTable("CLASS_STUDENT");

                entity.Property(e => e.Idclass).HasColumnName("IDClass");

                entity.Property(e => e.Idstudent).HasColumnName("IDStudent");

                entity.Property(e => e.Day).HasColumnType("date");

                entity.HasOne(d => d.IdclassNavigation)
                    .WithMany(p => p.ClassStudent)
                    .HasForeignKey(d => d.Idclass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLASS_STUDENT_CLASS");

                entity.HasOne(d => d.IdstudentNavigation)
                    .WithMany(p => p.ClassStudent)
                    .HasForeignKey(d => d.Idstudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLASS_STUDENT_STUDENT");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Idcourse)
                    .HasName("COURSE_pk");

                entity.ToTable("COURSE");

                entity.Property(e => e.Idcourse)
                    .HasColumnName("IDCourse")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Fee).HasColumnType("money");

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

          

          

            

            modelBuilder.Entity<Phanbo>(entity =>
            {
                entity.HasKey(e => new { e.Idclass, e.Idteacher });

                entity.ToTable("PHANBO");

                entity.Property(e => e.Idclass).HasColumnName("IDClass");

                entity.Property(e => e.Idteacher).HasColumnName("IDTeacher");

                entity.HasOne(d => d.IdclassNavigation)
                    .WithMany(p => p.Phanbo)
                    .HasForeignKey(d => d.Idclass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHANBO_CLASS");
            });

          

            modelBuilder.Entity<RigistrationCourse>(entity =>
            {
                entity.HasKey(e => e.Idregist)
                    .HasName("REGISTRATION_COURSE_pk");

                entity.ToTable("RIGISTRATION_COURSE");

                entity.Property(e => e.Idregist).HasColumnName("IDRegist");

                entity.Property(e => e.Address).HasColumnName("ADDRESS");

                entity.Property(e => e.Birthday)
                    .HasColumnName("BIRTHDAY")
                    .HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Idcourse)
                    .HasColumnName("IDCourse")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NameParent).HasMaxLength(100);

                entity.Property(e => e.NameStudent).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.State).HasMaxLength(200);

                entity.HasOne(d => d.IdcourseNavigation)
                    .WithMany(p => p.RigistrationCourse)
                    .HasForeignKey(d => d.Idcourse)
                    .HasConstraintName("FK_RIGISTRATION_COURSE_COURSE");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Idstudent)
                    .HasName("STUDENT_pk");

                entity.ToTable("STUDENT");

                entity.Property(e => e.Idstudent).HasColumnName("IDStudent");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(200);

                entity.Property(e => e.Born).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.NameParent).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Sex).HasMaxLength(10);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Idteacher)
                    .HasName("TEACHER_pk");

                entity.ToTable("TEACHER");

                entity.Property(e => e.Idteacher).HasColumnName("IDTeacher");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Knowledge).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Sex).HasMaxLength(10);
            });

            modelBuilder.Entity<TeachingClass>(entity =>
            {
                entity.ToTable("TEACHING_CLASS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Day).HasColumnType("date");

                entity.Property(e => e.Idclass).HasColumnName("IDClass");

                entity.Property(e => e.Idteacher).HasColumnName("IDTeacher");

                entity.Property(e => e.Session).HasColumnName("session");

                entity.HasOne(d => d.IdclassNavigation)
                    .WithMany(p => p.TeachingClass)
                    .HasForeignKey(d => d.Idclass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEACHING_CLASS_CLASS");

                entity.HasOne(d => d.IdteacherNavigation)
                    .WithMany(p => p.TeachingClass)
                    .HasForeignKey(d => d.Idteacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEACHING_CLASS_TEACHER");
            });
        }
    }
}
