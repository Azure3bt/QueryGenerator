using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueryGeneratorUsage
{
    public class Bourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MarketName { get; set; } = default!;
        public string? InstrumentId { get; set; }
        public virtual Instrument? Instrument{ get; set; }
    }

    public class Instrument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string InstrumentId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public int? BourseId { get; set; }
        public virtual Bourse? Bourse { get; set; }
        public string? Isin { get; set; } = default!;
        public long? HiddenPrice { get; set; }
        public DateTime? HiddenPriceFrom { get; set; }
        public DateTime? HiddenPriceTo { get; set; }
        public string? NewInstrumentId { get; set; }
        public string? NewInstrumentName { get; set; }
        public string? NewInstrumentText { get; set; }
    }
}
