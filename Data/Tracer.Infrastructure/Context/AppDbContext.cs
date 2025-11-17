
using Microsoft.EntityFrameworkCore;
using Tracer.Domain.Entities;

namespace Tracer.Infrastructure.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cable> Cables { get; set; }

    public virtual DbSet<Code> Codes { get; set; }

    public virtual DbSet<Connectioncategory> Connectioncategories { get; set; }

    public virtual DbSet<Connectionport> Connectionports { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Devicestype> Devicestypes { get; set; }

    public virtual DbSet<DslforDevice> DslforDevices { get; set; }

    public virtual DbSet<Dslport> Dslports { get; set; }

    public virtual DbSet<FiberforDevice> FiberforDevices { get; set; }

    public virtual DbSet<Fiberport> Fiberports { get; set; }

    public virtual DbSet<LanforDevice> LanforDevices { get; set; }

    public virtual DbSet<Lanport> Lanports { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<UsbforDevice> UsbforDevices { get; set; }

    public virtual DbSet<Usbport> Usbports { get; set; }

    public virtual DbSet<Visual> Visuals { get; set; }

    public virtual DbSet<WanforDevice> WanforDevices { get; set; }

    public virtual DbSet<Wanport> Wanports { get; set; }

    public virtual DbSet<Connectiondatum> Connectiondata { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cable_pkey");

            entity.ToTable("cable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Color).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Icon).HasMaxLength(200);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.Cables)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("fk_connectioncategory");

            entity.HasOne(d => d.CodeNavigation).WithMany(p => p.Cables)
                .HasPrincipalKey(p => p.Code1)
                .HasForeignKey(d => d.Code)
                .HasConstraintName("cable_code_fkey");
        });

        modelBuilder.Entity<Code>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("codes_pkey");

            entity.ToTable("codes");

            entity.HasIndex(e => e.Code1, "codes_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code1).HasColumnName("code");
            entity.Property(e => e.Used).HasColumnName("used");
        });

        modelBuilder.Entity<Connectioncategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("connectioncategory_pkey");

            entity.ToTable("connectioncategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(200)
                .HasColumnName("color");
            entity.Property(e => e.Icon)
                .HasMaxLength(200)
                .HasColumnName("icon");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Connectiondatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("connectiondata_pkey");

            entity.ToTable("connectiondata");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("isdelete");
            entity.Property(e => e.Savedata)
                .HasColumnName("savedata");
            entity.Property(e => e.Updatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatetime");
        });

        modelBuilder.Entity<Connectionport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("connectionport_pkey");

            entity.ToTable("connectionport");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cable).HasColumnName("cable");
            entity.Property(e => e.Conectedport).HasColumnName("conectedport");
            entity.Property(e => e.Firstport).HasColumnName("firstport");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("modem_pkey");

            entity.ToTable("Device");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('modem_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .HasColumnName("brand");
            entity.Property(e => e.Color).HasMaxLength(500);
            entity.Property(e => e.Createtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createtime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Icon).HasMaxLength(200);
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("isdelete");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.Updatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatetime");

            entity.HasOne(d => d.DeviceTypeNavigation).WithMany(p => p.Devices)
                .HasForeignKey(d => d.DeviceType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_devicetype");
        });

        modelBuilder.Entity<Devicestype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("devicestype_pkey");

            entity.ToTable("devicestype");

            entity.HasIndex(e => e.Code, "devicestype_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Icon).HasMaxLength(150);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DslforDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dslformodem_pkey");

            entity.ToTable("dslforDevice");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('dslformodem_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Dslid).HasColumnName("dslid");

            entity.HasOne(d => d.Device).WithMany(p => p.DslforDevices)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dslformodem_modemid_fkey");

            entity.HasOne(d => d.Dsl).WithMany(p => p.DslforDevices)
                .HasForeignKey(d => d.Dslid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dslformodem_dslid_fkey");
        });

        modelBuilder.Entity<Dslport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dslport_pkey");

            entity.ToTable("dslport");

            entity.HasIndex(e => e.Code, "dslport_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Createtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createtime");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("isdelete");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.Updatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatetime");

            entity.HasOne(d => d.CodeNavigation).WithOne(p => p.Dslport)
                .HasPrincipalKey<Code>(p => p.Code1)
                .HasForeignKey<Dslport>(d => d.Code)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usbport_code_fkey");
        });

        modelBuilder.Entity<FiberforDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fiberformodem_pkey");

            entity.ToTable("fiberforDevice");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('fiberformodem_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Sfid).HasColumnName("sfid");

            entity.HasOne(d => d.Device).WithMany(p => p.FiberforDevices)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fiberformodem_modemid_fkey");

            entity.HasOne(d => d.Sf).WithMany(p => p.FiberforDevices)
                .HasForeignKey(d => d.Sfid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fiberformodem_sfid_fkey");
        });

        modelBuilder.Entity<Fiberport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sfport_pkey");

            entity.ToTable("fiberport");

            entity.HasIndex(e => e.Code, "sfport_code_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('sfport_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Createtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createtime");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("isdelete");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.Updatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatetime");

            entity.HasOne(d => d.CodeNavigation).WithOne(p => p.Fiberport)
                .HasPrincipalKey<Code>(p => p.Code1)
                .HasForeignKey<Fiberport>(d => d.Code)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usbport_code_fkey");
        });

        modelBuilder.Entity<LanforDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lanformodem_pkey");

            entity.ToTable("lanforDevice");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('lanformodem_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Lanid).HasColumnName("lanid");

            entity.HasOne(d => d.Device).WithMany(p => p.LanforDevices)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("lanformodem_modemid_fkey");

            entity.HasOne(d => d.Lan).WithMany(p => p.LanforDevices)
                .HasForeignKey(d => d.Lanid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("lanformodem_lanid_fkey");
        });

        modelBuilder.Entity<Lanport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lanport_pkey");

            entity.ToTable("lanport");

            entity.HasIndex(e => e.Code, "lanport_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Createtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createtime");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("isdelete");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.Updatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatetime");

            entity.HasOne(d => d.CodeNavigation).WithOne(p => p.Lanport)
                .HasPrincipalKey<Code>(p => p.Code1)
                .HasForeignKey<Lanport>(d => d.Code)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usbport_code_fkey");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("properties_pkey");

            entity.ToTable("properties");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bandwidth).HasColumnName("bandwidth");
            entity.Property(e => e.Cableid).HasColumnName("cableid");
            entity.Property(e => e.Duplex)
                .HasMaxLength(200)
                .HasColumnName("duplex");
            entity.Property(e => e.Latency).HasColumnName("latency");
            entity.Property(e => e.Maxdistance).HasColumnName("maxdistance");

            entity.HasOne(d => d.Cable).WithMany(p => p.Properties)
                .HasForeignKey(d => d.Cableid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("properties_cableid_fkey");
        });

        modelBuilder.Entity<UsbforDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usbformodem_pkey");

            entity.ToTable("usbforDevice");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('usbformodem_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Usbid).HasColumnName("usbid");

            entity.HasOne(d => d.Device).WithMany(p => p.UsbforDevices)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usbformodem_modemid_fkey");

            entity.HasOne(d => d.Usb).WithMany(p => p.UsbforDevices)
                .HasForeignKey(d => d.Usbid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usbformodem_usbid_fkey");
        });

        modelBuilder.Entity<Usbport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usbport_pkey");

            entity.ToTable("usbport");

            entity.HasIndex(e => e.Code, "usbport_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Createtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createtime");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("isdelete");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.Updatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatetime");

            entity.HasOne(d => d.CodeNavigation).WithOne(p => p.Usbport)
                .HasPrincipalKey<Code>(p => p.Code1)
                .HasForeignKey<Usbport>(d => d.Code)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usbport_code_fkey");
        });

        modelBuilder.Entity<Visual>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visual_pkey");

            entity.ToTable("visual");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cableid).HasColumnName("cableid");
            entity.Property(e => e.Linestyle)
                .HasMaxLength(200)
                .HasDefaultValueSql("true")
                .HasColumnName("linestyle");
            entity.Property(e => e.Showarrow).HasColumnName("showarrow");
            entity.Property(e => e.Strokedasharray)
                .HasMaxLength(200)
                .HasColumnName("strokedasharray");
            entity.Property(e => e.Strokewidth)
                .HasMaxLength(200)
                .HasColumnName("strokewidth");

            entity.HasOne(d => d.Cable).WithMany(p => p.Visuals)
                .HasForeignKey(d => d.Cableid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visual_cableid_fkey");
        });

        modelBuilder.Entity<WanforDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wanformodem_pkey");

            entity.ToTable("wanforDevice");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('wanformodem_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Wanid).HasColumnName("wanid");

            entity.HasOne(d => d.Device).WithMany(p => p.WanforDevices)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wanformodem_modemid_fkey");

            entity.HasOne(d => d.Wan).WithMany(p => p.WanforDevices)
                .HasForeignKey(d => d.Wanid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("wanformodem_wanid_fkey");
        });

        modelBuilder.Entity<Wanport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("wanport_pkey");

            entity.ToTable("wanport");

            entity.HasIndex(e => e.Code, "wanport_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Createtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createtime");
            entity.Property(e => e.Isdelete)
                .HasDefaultValue(false)
                .HasColumnName("isdelete");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.Updatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatetime");

            entity.HasOne(d => d.CodeNavigation).WithOne(p => p.Wanport)
                .HasPrincipalKey<Code>(p => p.Code1)
                .HasForeignKey<Wanport>(d => d.Code)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usbport_code_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
