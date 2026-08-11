using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace QueryGeneratorUsage;
public class InstrumentContext : DbContext
{
    public DbSet<Instrument> Instruments { get; set; }
    public DbSet<Bourse> Bourses { get; set; }

    public string DbPath { get; }

    public InstrumentContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, $"Instruments_{Guid.NewGuid()}.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
        options.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var count = 1_000;
        var instruments = new List<Instrument>();
        var bourses = new List<Bourse>();

        foreach (var index in Enumerable.Range(1, count))
        {

            bourses.Add(new Bourse()
            {
                Id = index,
                MarketName = $"MarketName{index}"
            });

            var instrument = new Instrument()
            {
                InstrumentId = $"InstrumentId{index}",
                Name = $"Instrument{index}",
                HiddenPrice = index
            };

            if (index <= 22)
            {
                instrument.NewInstrumentId = "AmirAli";
                instrument.NewInstrumentName = "AmirAbbas";
                instrument.NewInstrumentText = "Abbas";
                instrument.Isin = $"Isin{index}";
                instrument.BourseId = index;
            }
            instruments.Add(instrument);
        }


        modelBuilder.Entity<Bourse>(
            config =>
            {
                config.HasKey(bourse => bourse.Id);
                config.HasData(bourses);
            }
        );

        modelBuilder.Entity<Instrument>(
            config =>
            {
                config.HasKey(instrument => instrument.InstrumentId);
                config.HasOne(x => x.Bourse)
                        .WithOne()
                        .HasForeignKey<Instrument>(x => x.BourseId);
                config.HasData(instruments);
            }
        );

    }
}