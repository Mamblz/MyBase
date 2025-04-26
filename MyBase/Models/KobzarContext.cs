using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyBase.Models;

public partial class KobzarContext : DbContext
{
    public KobzarContext()
    {
    }

    public KobzarContext(DbContextOptions<KobzarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<DevicesType> DevicesTypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Orderservice> Orderservices { get; set; }

    public virtual DbSet<Repairorder> Repairorders { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=edu.pg.ngknn.local;Port=5432;Database=Kobzar;Username=23P;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("brands_pkey");

            entity.ToTable("brands", "33P_API_Kobzar");

            entity.HasIndex(e => e.BrandName, "brands_brand_name_key").IsUnique();

            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .HasColumnName("brand_name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("customers_pkey");

            entity.ToTable("customers", "33P_API_Kobzar");

            entity.HasIndex(e => e.Email, "customers_email_key").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.DeviceId).HasName("devices_pkey");

            entity.ToTable("devices", "33P_API_Kobzar");

            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.DeviceType).HasColumnName("device_type");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");

            entity.HasOne(d => d.Brand).WithMany(p => p.Devices)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("devices_brand_id_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.Devices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("devices_customer_id_fkey");

            entity.HasOne(d => d.DeviceTypeNavigation).WithMany(p => p.Devices)
                .HasForeignKey(d => d.DeviceType)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("devices_device_type_fkey");
        });

        modelBuilder.Entity<DevicesType>(entity =>
        {
            entity.HasKey(e => e.DevicesTypeId).HasName("devices_type_pkey");

            entity.ToTable("devices_type", "33P_API_Kobzar");

            entity.Property(e => e.DevicesTypeId).HasColumnName("devices_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("employees_pkey");

            entity.ToTable("employees", "33P_API_Kobzar");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<Orderservice>(entity =>
        {
            entity.HasKey(e => e.OrderServiceId).HasName("orderservices_pkey");

            entity.ToTable("orderservices", "33P_API_Kobzar");

            entity.Property(e => e.OrderServiceId).HasColumnName("order_service_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.Service).WithMany(p => p.Orderservices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orderservices_service_id_fkey");
        });

        modelBuilder.Entity<Repairorder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("repairorders_pkey");

            entity.ToTable("repairorders", "33P_API_Kobzar");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Device).WithMany(p => p.Repairorders)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("repairorders_device_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.Repairorders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("repairorders_employee_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Repairorders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("repairorders_status_id_fkey");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("services_pkey");

            entity.ToTable("services", "33P_API_Kobzar");

            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(100)
                .HasColumnName("service_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("statuses_pkey");

            entity.ToTable("statuses", "33P_API_Kobzar");

            entity.HasIndex(e => e.StatusName, "statuses_status_name_key").IsUnique();

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .HasColumnName("status_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
