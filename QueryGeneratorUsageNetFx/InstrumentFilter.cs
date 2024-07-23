using System;

namespace QueryableDtos
{
    internal class InstrumentFilterDto
    {
        public string InstrumentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Isin { get; set; }
        public string InsCode { get; set; }
        public string BoardCode { get; set; }
        public string BoardName { get; set; }
        public string SectorName { get; set; }
        public string SectorCode { get; set; }
        public string SubSectorName { get; set; }
        public string SubSectorCode { get; set; }
        public long? FromAskMaxQuantity { get; set; }
        public long? ToAskMaxQuantity { get; set; }
        public long? FromBidMaxQuantity { get; set; }
        public long? ToBidMaxQuantity { get; set; }
        public long? FromMinQuantity { get; set; }
        public long? ToMinQuantity { get; set; }
        public long? FromMaxQuantity { get; set; }
        public long? ToMaxQuantity { get; set; }
        public long? FromTick { get; set; }
        public long? ToTick { get; set; }
        public long? FromSize { get; set; }
        public long? ToSize { get; set; }
        //public MarketSegment? Segment { get; set; }
        public long? FromBaseVolume { get; set; }
        public long? ToBaseVolume { get; set; }
        public long? FromParValue { get; set; }
        public long? ToParValue { get; set; }
        public string ProductCode { get; set; }
        public string ProductTitle { get; set; }
        public string ProductTypeCode1 { get; set; }
        public string ProductTypeCode2 { get; set; }
        //public Borse? Bourse { get; set; }

        //public SettlementType? SettlementType { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        //public GroupState? GroupState { get; set; }
        //public InstrumentState? State { get; set; }
        public long? FromPriceMin { get; set; }
        public long? ToPriceMin { get; set; }
        public long? FromPriceMax { get; set; }
        public long? ToPriceMax { get; set; }
        public DateTime? FromCreatedAt { get; set; }
        public DateTime? ToCreatedAt { get; set; }
        public decimal? FromAskFeeRate { get; set; }
        public decimal? ToAskFeeRate { get; set; }
        public decimal? FromBidFeeRate { get; set; }
        public decimal? ToBidFeeRate { get; set; }
        //public ClassType? Class { get; set; }
        //public ClassChannel? Channel { get; set; }
        public long? FromHiddenPrice { get; set; }
        public long? ToHiddenPrice { get; set; }

        //public HiddenPriceType? HiddenPriceType { get; set; }
        public DateTime? HiddenPriceFrom { get; set; }
        public DateTime? HiddenPriceTo { get; set; }
        public bool? IsBidPermitted { get; set; }
        public bool? IsAskPermitted { get; set; }
        public bool? IsSearchable { get; set; }
        public string PutOptionParentInstrumentFilter { get; set; }
        public DateTime? FromPutOptionParentInstrument { get; set; }
        public DateTime? ToPutOptionParentInstrument { get; set; }
        public bool? IsActive { get; set; }
        public string NewInstrumentFilter { get; set; }
    }
}