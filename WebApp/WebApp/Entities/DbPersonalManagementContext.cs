using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Entities;

public partial class DbPersonalManagementContext : DbContext
{
    public DbPersonalManagementContext()
    {
    }

    public DbPersonalManagementContext(DbContextOptions<DbPersonalManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Absence> Absences { get; set; }

    public virtual DbSet<Calendar> Calendars { get; set; }

    public virtual DbSet<CalendarType> CalendarTypes { get; set; }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventStatus> EventStatuses { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialStatus> MaterialStatuses { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<TrainingClass> TrainingClasses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkingCalendar> WorkingCalendars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-PITEGC9\\SQLEXPRESS; Database=dbPersonalManagement; TrustServerCertificate=true; Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Absence>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Reason).HasMaxLength(50);
            entity.Property(e => e.ReplacementId).HasColumnName("ReplacementID");

            entity.HasOne(d => d.Employee).WithMany(p => p.AbsenceEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Absences_Employees");

            entity.HasOne(d => d.Replacement).WithMany(p => p.AbsenceReplacements)
                .HasForeignKey(d => d.ReplacementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Absences_Employees1");
        });

        modelBuilder.Entity<Calendar>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CalendarTypeId).HasColumnName("CalendarTypeID");
            entity.Property(e => e.DivisionId).HasColumnName("DivisionID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.HasOne(d => d.CalendarType).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.CalendarTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendars_CalendarTypes");

            entity.HasOne(d => d.Division).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_Calendars_Divisions");

            entity.HasOne(d => d.Employee).WithMany(p => p.Calendars)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendars_Employees");
        });

        modelBuilder.Entity<CalendarType>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CalendarTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Area).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.Text).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Comments)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Employees");

            entity.HasOne(d => d.Document).WithMany(p => p.Comments)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Documents");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DirectorId).HasColumnName("DirectorID");

            entity.HasOne(d => d.Director).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.DirectorId)
                .HasConstraintName("FK_Divisions_Employees");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Titile).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssistantId).HasColumnName("AssistantID");
            entity.Property(e => e.Cabinet).HasMaxLength(50);
            entity.Property(e => e.DirectorId).HasColumnName("DirectorID");
            entity.Property(e => e.DivisionId).HasColumnName("DivisionID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.MobilePhone).HasMaxLength(20);
            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.WorkPhone).HasMaxLength(20);

            entity.HasOne(d => d.Assistant).WithMany(p => p.InverseAssistant)
                .HasForeignKey(d => d.AssistantId)
                .HasConstraintName("FK_Employees_Employees1");

            entity.HasOne(d => d.Director).WithMany(p => p.InverseDirector)
                .HasForeignKey(d => d.DirectorId)
                .HasConstraintName("FK_Employees_Employees");

            entity.HasOne(d => d.Division).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_Employees_Divisions");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_Employees_Positions");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EventName).HasMaxLength(50);
            entity.Property(e => e.EventStatusId).HasColumnName("EventStatusID");
            entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
            entity.Property(e => e.ResponsiblePerson).HasMaxLength(50);

            entity.HasOne(d => d.EventStatus).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_EventStatuses");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_EventTypes");
        });

        modelBuilder.Entity<EventStatus>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EventStatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EventTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Area).HasMaxLength(50);
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.MaterialName).HasMaxLength(50);
            entity.Property(e => e.MaterialStatusId).HasColumnName("MaterialStatusID");
            entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

            entity.HasOne(d => d.Author).WithMany(p => p.Materials)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_Employees");

            entity.HasOne(d => d.MaterialStatus).WithMany(p => p.Materials)
                .HasForeignKey(d => d.MaterialStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_MaterialStatuses");

            entity.HasOne(d => d.MaterialType).WithMany(p => p.Materials)
                .HasForeignKey(d => d.MaterialTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Materials_MaterialTypes");
        });

        modelBuilder.Entity<MaterialStatus>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MaterialStatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MaterialTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<TrainingClass>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

            entity.HasOne(d => d.Event).WithMany(p => p.TrainingClasses)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrainingClasses_Events");

            entity.HasOne(d => d.Material).WithMany(p => p.TrainingClasses)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_TrainingClasses_Materials");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<WorkingCalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("WorkingCalendar_pk");

            entity.ToTable("WorkingCalendar", tb => tb.HasComment("Список дней исключений в производственном календаре"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("Идентификатор строки");
            entity.Property(e => e.ExceptionDate).HasComment("День-исключение");
            entity.Property(e => e.IsWorkingDay).HasComment("0 - будний день, но законодательно принят выходным");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
