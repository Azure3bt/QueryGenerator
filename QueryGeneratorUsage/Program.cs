using QueryableDtos;
using QueryGenerator;
using QueryGenerator.ColumnMapping;
using QueryGeneratorUsage;

var instrumentFilter = new InstrumentFilterDto();
instrumentFilter.FromHiddenPrice = 10;
instrumentFilter.ToHiddenPrice = 20;
instrumentFilter.NewInstrumentFilter = "Amir";
instrumentFilter.MarketName = "MarketName1";

var queryFilter = new QueryFilter<InstrumentFilterDto, Instrument>().Init("basicinfo.v2", "instrument")
    .AddFilter(
        new QueryFilterColumn<InstrumentFilterDto, Instrument>(
            [
                new StringColumn<Instrument>()
                {
                    ValueGetter = instrument => instrument.Isin,
                    QueryOperator = QueryOperator.Like,
                }
            ]
        ).GetValue(instrument => instrument.Isin)
    )
    //.AddFilter(
    //    new QueryFilterColumn<InstrumentFilterDto, Instrument>(
    //        [
    //            new StringColumn<Instrument>()
    //            {
    //                ValueGetter = instrument => instrument.NewInstrumentId
    //            },
    //            new StringColumn<Instrument>()
    //            {
    //                ValueGetter = instrument => instrument.NewInstrumentName
    //            },
    //            new StringColumn<Instrument>()
    //            {
    //                ValueGetter = instrument => instrument.NewInstrumentText
    //            }
    //        ],

    //        QueryOperator.Like
    //    )
    //    .GetValue(instrument => instrument.NewInstrumentFilter)
    //)
    .AddFilter(
        new QueryFilterColumn<InstrumentFilterDto, Instrument>(
            [
                new LongColumn<Instrument>()
                {
                    ValueGetter = instrument => instrument.HiddenPrice ?? 0,
                    QueryOperator = QueryOperator.GreaterThanOrEqual
                }
            ]
        )
        .GetValue(instrument => instrument.FromHiddenPrice)
    )
    //.AddFilter(
    //    new QueryFilterColumn<InstrumentFilterDto, Instrument>(
    //        [
    //            new StringColumn<Instrument>()
    //            {
    //                ValueGetter = instrument => instrument.Bourse.MarketName
    //            }
    //        ],
    //        QueryOperator.GreaterThanOrEqual
    //    )
    //    .GetValue(instrument => instrument.MarketName)
    //)
    .AddFilter(
        new QueryFilterColumn<InstrumentFilterDto, Instrument>(
            [
                new LongColumn<Instrument>()
                {
                    ValueGetter = instrument => instrument.HiddenPrice ?? 0,
                    QueryOperator =  QueryOperator.LessThanOrEqual
                }
            ]
        )
        .GetValue(instrument => instrument.ToHiddenPrice)
    )
    .Build(instrumentFilter);

var instruments = GenerateInstruments.Generate();

foreach(var instrument in instruments.Where(queryFilter.Query))
{
    Console.WriteLine(instrument.Name);
}

Console.WriteLine("Done!");