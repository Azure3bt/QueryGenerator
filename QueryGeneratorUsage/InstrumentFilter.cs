using Diba.Infra.Core.Market.Enums;
using QueryGenerator;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueryableDtos;

[Table("Instrument", Schema = "basicInfo.v2")]
internal class InstrumentFilterDto
{
    [Query("InstrumentId", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? InstrumentId { get; set; }

    [Query("Code", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? Code { get; set; }

    [Query("Name", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? Name { get; set; }

    [Query("Text", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? Text { get; set; }

    [Query("Isin", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? Isin { get; set; }

    [Query("InsCode", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? InsCode { get; set; }

    [Query("BoardCode", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? BoardCode { get; set; }

    [Query("BoardName", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? BoardName { get; set; }

    [Query("SectorName", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? SectorName { get; set; }

    [Query("SectorCode", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? SectorCode { get; set; }

    [Query("SubSectorName", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? SubSectorName { get; set; }

    [Query("SubSectorCode", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? SubSectorCode { get; set; }

    [Query("AskMaxQuantity", "FromAskMaxQuantity", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public long? FromAskMaxQuantity { get; set; }

    [Query("AskMaxQuantity", "ToAskMaxQuantity", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public long? ToAskMaxQuantity { get; set; }

    [Query("BidMaxQuantity", "FromBidMaxQuantity", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public long? FromBidMaxQuantity { get; set; }

    [Query("BidMaxQuantity", "ToBidMaxQuantity", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public long? ToBidMaxQuantity { get; set; }

    [Query("MinQuantity", "FromMinQuantity", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public long? FromMinQuantity { get; set; }

    [Query("MinQuantity", "ToMinQuantity", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public long? ToMinQuantity { get; set; }

    [Query("MaxQuantity", "FromMaxQuantity", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public long? FromMaxQuantity { get; set; }

    [Query("MaxQuantity", "ToMaxQuantity", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public long? ToMaxQuantity { get; set; }

    [Query("Tick", "FromTick", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public long? FromTick { get; set; }

    [Query("Tick", "ToTick", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public long? ToTick { get; set; }

    [Query("Lot", "FromSize", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public long? FromSize { get; set; }

    [Query("Lot", "ToSize", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public long? ToSize { get; set; }

    [Query("Segment", System.Data.SqlDbType.Int, Operator.Equal)]
    public MarketSegment? Segment { get; set; }

    [Query("BaseVolume", "FromBaseVolume", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public long? FromBaseVolume { get; set; }

    [Query("BidMaxQuantity", "ToBaseVolume", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public long? ToBaseVolume { get; set; }

    [Query("ParValue", "FromParValue", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public long? FromParValue { get; set; }

    [Query("ParValue", "ToParValue", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public long? ToParValue { get; set; }

    [Query("ProductCode", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? ProductCode { get; set; }

    [Query("ProductTitle", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? ProductTitle { get; set; }

    [Query("ProductTypeCode1", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? ProductTypeCode1 { get; set; }

    [Query("ProductTypeCode2", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? ProductTypeCode2 { get; set; }

    [Query("Bourse", System.Data.SqlDbType.Int, Operator.Equal)]
    public Borse? Bourse { get; set; }

    public SettlementType? SettlementType { get; set; }

    [Query("GroupCode", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? GroupCode { get; set; }

    [Query("GroupName", System.Data.SqlDbType.NVarChar, Operator.Like)]
    public string? GroupName { get; set; }

    //[Query("GroupState", System.Data.SqlDbType.Int, Operator.Equal)]
    //public GroupState? GroupState { get; set; }

    [Query("State", System.Data.SqlDbType.Int, Operator.Equal)]
    public InstrumentState? State { get; set; }

    [Query("PriceMin", "FromPriceMin", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public long? FromPriceMin { get; set; }

    [Query("PriceMin", "ToPriceMin", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public long? ToPriceMin { get; set; }

    [Query("PriceMax", "FromPriceMax", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public long? FromPriceMax { get; set; }

    [Query("PriceMax", "ToPriceMax", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public long? ToPriceMax { get; set; }

    [Query("CreatedAt", "FromCreatedAt", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public DateTime? FromCreatedAt { get; set; }

    [Query("CreatedAt", "ToCreatedAt", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public DateTime? ToCreatedAt { get; set; }

    [Query("AskFeeRate", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public decimal? FromAskFeeRate { get; set; }

    [Query("AskFeeRate", "ToAskFeeRate", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public decimal? ToAskFeeRate { get; set; }

    [Query("BidFeeRate", "FromBidFeeRate", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public decimal? FromBidFeeRate { get; set; }

    [Query("BidFeeRate", "ToBidFeeRate", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public decimal? ToBidFeeRate { get; set; }

    [Query("Class", System.Data.SqlDbType.Int, Operator.Equal)]
    public ClassType? Class { get; set; }

    [Query("ClassChanel", System.Data.SqlDbType.Int, Operator.Equal)]
    public ClassChannel? Channel { get; set; }

    [Query("HiddenPrice", "FromHiddenPrice", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public long? FromHiddenPrice { get; set; }

    [Query("HiddenPrice", "ToHiddenPrice", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public long? ToHiddenPrice { get; set; }

    public HiddenPriceType? HiddenPriceType { get; set; }

    [Query("HiddenPriceFrom", System.Data.SqlDbType.DateTime2, Operator.Equal)]
    public DateTime? HiddenPriceFrom { get; set; }

    [Query("HiddenPriceTo", System.Data.SqlDbType.DateTime2, Operator.Equal)]
    public DateTime? HiddenPriceTo { get; set; }

    [Query("IsBidPermitted", System.Data.SqlDbType.Bit, Operator.Equal)]
    public bool? IsBidPermitted { get; set; }

    [Query("IsAskPermitted", System.Data.SqlDbType.Bit, Operator.Equal)]
    public bool? IsAskPermitted { get; set; }

    [Query("IsSearchable", System.Data.SqlDbType.Bit, Operator.Equal)]
    public bool? IsSearchable { get; set; }

    [Query("PutOptionParentInstrumentId,PutOptionParentInstrumentName,PutOptionParentInstrumentText", "PutOptionParentInstrumentFilter", System.Data.SqlDbType.NVarChar, Operator.Like, true)]
    public string? PutOptionParentInstrumentFilter { get; set; }

    [Query("PutOptionParentInstrument", System.Data.SqlDbType.BigInt, Operator.GreaterThanOrEqual)]
    public DateTime? FromPutOptionParentInstrument { get; set; }

    [Query("PutOptionParentInstrument", System.Data.SqlDbType.BigInt, Operator.LessThanOrEqual)]
    public DateTime? ToPutOptionParentInstrument { get; set; }

    [Query("IsSearchable", System.Data.SqlDbType.Bit, Operator.Equal)]
    public bool? IsActive { get; set; }

    [Query("NewInstrumentId,NewInstrumentName,NewInstrumentText", "NewInstrumentFilter", System.Data.SqlDbType.NVarChar, Operator.Like, true)]
    public string? NewInstrumentFilter { get; set; }
}
