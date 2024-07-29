using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusTracking.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arrival> Arrivals { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Buslocation> Buslocations { get; set; } = null!;
        public virtual DbSet<Busroute> Busroutes { get; set; } = null!;
        public virtual DbSet<Child> Children { get; set; } = null!;
        public virtual DbSet<Contactu> Contactus { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Pagecontent> Pagecontents { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Stop> Stops { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<bus> Buses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=C##FinalProject;PASSWORD=Test321;DATA SOURCE=localhost:1521/xe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##FINALPROJECT")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Arrival>(entity =>
            {
                entity.ToTable("ARRIVAL");

                entity.Property(e => e.Arrivalid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ARRIVALID");

                entity.Property(e => e.Childid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHILDID");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Teacherid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TEACHERID");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Arrivals)
                    .HasForeignKey(d => d.Childid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CHILDID1");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Arrivals)
                    .HasForeignKey(d => d.Teacherid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TEACHERID1");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("ATTENDANCE");

                entity.Property(e => e.Attendanceid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ATTENDANCEID");

                entity.Property(e => e.Attendancedate)
                    .HasColumnType("TIMESTAMP(6) WITH TIME ZONE")
                    .HasColumnName("ATTENDANCEDATE")
                    .HasDefaultValueSql("SYSTIMESTAMP");

                entity.Property(e => e.Childid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHILDID");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Teacherid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TEACHERID");

                entity.HasOne(d => d.Child)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.Childid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CHILDID");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.Teacherid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("ATTENDANCE_FK1");
            });

            modelBuilder.Entity<Buslocation>(entity =>
            {
                entity.HasKey(e => e.Locationid)
                    .HasName("SYS_C008770");

                entity.ToTable("BUSLOCATION");

                entity.Property(e => e.Locationid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOCATIONID");

                entity.Property(e => e.Adate)
                    .HasColumnType("TIMESTAMP(6) WITH TIME ZONE")
                    .HasColumnName("ADATE")
                    .HasDefaultValueSql("SYSTIMESTAMP");

                entity.Property(e => e.BusId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUS_ID");

                entity.Property(e => e.Latitude)
                    .HasColumnType("FLOAT")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasColumnType("FLOAT")
                    .HasColumnName("LONGITUDE");

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.Buslocations)
                    .HasForeignKey(d => d.BusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BUS_ID");
            });

            modelBuilder.Entity<Busroute>(entity =>
            {
                entity.HasKey(e => e.Routeid)
                    .HasName("SYS_C008772");

                entity.ToTable("BUSROUTE");

                entity.Property(e => e.Routeid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROUTEID");

                entity.Property(e => e.BusesId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUSES_ID");

                entity.Property(e => e.LocationId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("LOCATION_ID");

                entity.Property(e => e.Sequence)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SEQUENCE");

                entity.HasOne(d => d.Buses)
                    .WithMany(p => p.Busroutes)
                    .HasForeignKey(d => d.BusesId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BUSES_ID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Busroutes)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_LOCATION_ID");
            });

            modelBuilder.Entity<Child>(entity =>
            {
                entity.ToTable("CHILDREN");

                entity.Property(e => e.Childid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CHILDID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Busid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUSID");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Parentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PARENTID");

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.Busid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_BUSID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.Parentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PARENTID");
            });

            modelBuilder.Entity<Contactu>(entity =>
            {
                entity.HasKey(e => e.Contactusid)
                    .HasName("SYS_C008764");

                entity.ToTable("CONTACTUS");

                entity.Property(e => e.Contactusid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACTUSID");

                entity.Property(e => e.Contactdate)
                    .HasColumnType("TIMESTAMP(6) WITH TIME ZONE")
                    .HasColumnName("CONTACTDATE")
                    .HasDefaultValueSql("SYSTIMESTAMP\n   ");

                entity.Property(e => e.Message)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Subject)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserEMAIL");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserNAME");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.Loginid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGINID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_USERID");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("NOTIFICATIONS");

                entity.Property(e => e.Notificationid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOTIFICATIONID");

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Notificationdate)
                    .HasColumnType("TIMESTAMP(6) WITH TIME ZONE")
                    .HasColumnName("NOTIFICATIONDATE")
                    .HasDefaultValueSql("SYSTIMESTAMP");

                entity.Property(e => e.ParentId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PARENT_ID");

                entity.Property(e => e.TeacherId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TEACHER_ID");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.NotificationParents)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PARENT_ID");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.NotificationTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TEACHER_ID");
            });

            modelBuilder.Entity<Pagecontent>(entity =>
            {
                entity.ToTable("PAGECONTENT");

                entity.Property(e => e.Pagecontentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAGECONTENTID");

                entity.Property(e => e.Contentkey)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTENTKEY");

                entity.Property(e => e.Contentvalue)
                    .HasColumnType("CLOB")
                    .HasColumnName("CONTENTVALUE");

                entity.Property(e => e.Pagename)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PAGENAME");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Stop>(entity =>
            {
                entity.ToTable("STOPS");

                entity.Property(e => e.Stopid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STOPID");

                entity.Property(e => e.Addeddate)
                    .HasColumnType("TIMESTAMP(6) WITH TIME ZONE")
                    .HasColumnName("ADDEDDATE")
                    .HasDefaultValueSql("SYSTIMESTAMP");

                entity.Property(e => e.Busid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUSID");

                entity.Property(e => e.Enddate)
                    .HasColumnType("TIMESTAMP(6) WITH TIME ZONE")
                    .HasColumnName("ENDDATE")
                    .HasDefaultValueSql("SYSTIMESTAMP");

                entity.Property(e => e.Latitude)
                    .HasColumnType("FLOAT")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Longitude)
                    .HasColumnType("FLOAT")
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.Stopname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STOPNAME");

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.Stops)
                    .HasForeignKey(d => d.Busid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_STOPS");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.Testimonialid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIALID");

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Publisher_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PUBLISHER_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Publisher_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PUBLISHER_ID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER_");

                entity.HasIndex(e => e.Username, "USER__UK1")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("TIMESTAMP(6) WITH TIME ZONE")
                    .HasDefaultValueSql("SYSTIMESTAMP  ");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Imagepath)
                    .HasColumnType("CLOB")
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Username)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ROLEID");
            });

            modelBuilder.Entity<bus>(entity =>
            {
                entity.ToTable("BUSES");

                entity.Property(e => e.Busid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BUSID");

                entity.Property(e => e.Busnumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BUSNUMBER");

                entity.Property(e => e.Childrennumber)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CHILDRENNUMBER");

                entity.Property(e => e.Driverid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DRIVERID");

                entity.Property(e => e.Teacherid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TEACHERID");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.busDrivers)
                    .HasForeignKey(d => d.Driverid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_DRIVERID");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.busTeachers)
                    .HasForeignKey(d => d.Teacherid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("BUSES_FK1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
