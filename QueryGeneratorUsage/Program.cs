using QueryableDtos;
using QueryGenerator;
using QueryGeneratorUsage;

var instrumentFilter = new InstrumentFilterDto();
//instrumentFilter.FromHiddenPrice = 10;
instrumentFilter.ToHiddenPrice = 20;
//instrumentFilter.NewInstrumentFilter = "Amir";

var queryFilter = new QueryFilter<InstrumentFilterDto, Instrument>().Init("basicinfo.v2", "instrument")
    .AddFilter(
        new QueryFilterColumn<InstrumentFilterDto, Instrument>(
            new Func<Instrument, object>[]
            {
                instrument => instrument.Isin
            },
            QueryOperator.Like
        ).GetValue(instrument => instrument.Isin)
    )
    .AddFilter(
        new QueryFilterColumn<InstrumentFilterDto, Instrument>(
            new Func<Instrument, object>[]
            {
                instrument => instrument.NewInstrumentId,
                instrument => instrument.NewInstrumentName,
                instrument => instrument.NewInstrumentText
            },

            QueryOperator.Like
        )
        .GetValue(instrument => instrument.NewInstrumentFilter)
    )
    .AddFilter(
        new QueryFilterColumn<InstrumentFilterDto, Instrument>(
            new Func<Instrument, object>[]
            {
                instrument => instrument.HiddenPrice ?? 0
            },
            QueryOperator.GreaterThanOrEqual
        )
        .GetValue(instrument => instrument.FromHiddenPrice)
    )
    .AddFilter(
        new QueryFilterColumn<InstrumentFilterDto, Instrument>(
            new Func<Instrument, object>[]
            {
                instrument => instrument.HiddenPrice ?? 0
            },
            QueryOperator.LessThanOrEqual
        )
        .GetValue(instrument => instrument.ToHiddenPrice)
    );




var instruments = GenerateInstruments.Generate();
var queryResult = queryFilter.GenerateQuery(instrumentFilter);

foreach(var instrument in instruments.Where(queryResult.Query))
{
    Console.WriteLine(instrument.Name);
}

Console.WriteLine("Done!");