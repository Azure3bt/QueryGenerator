using QueryableDtos;
using QueryGenerator;

var instrumentFilter = new InstrumentFilterDto();
instrumentFilter.FromHiddenPrice = 1;
instrumentFilter.ToHiddenPrice = 2;
instrumentFilter.NewInstrumentFilter = "Test";

var queryFilter = new QueryFilter<InstrumentFilterDto>().Init("basicinfo.v2", "instrument")
    .AddFilter(
        new QueryFilterColumn<InstrumentFilterDto>(
            "Isin",
            System.Data.SqlDbType.NVarChar,
            QueryOperator.Like
        ).GetValue(instrument => instrument.Isin)
    )
    .AddFilter(
        new QueryFilterColumn<InstrumentFilterDto>(
            "NewInstrumentId,NewInstrumentName,NewInstrumentText",
            "NewInstrumentFilter",
            System.Data.SqlDbType.NVarChar,
            QueryOperator.Like
        )
        .GetValue(instrument => instrument.NewInstrumentFilter)
    )
    .AddFilter(
        new QueryFilterColumn<InstrumentFilterDto>(
            "HiddenPrice",
            "FromHiddenPrice",
            System.Data.SqlDbType.BigInt,
            QueryOperator.GreaterThanOrEqual
        )
        .GetValue(instrument => instrument.FromHiddenPrice)
    )
    .AddFilter(
        new QueryFilterColumn<InstrumentFilterDto>(
            "HiddenPrice",
            "ToHiddenPrice",
            System.Data.SqlDbType.BigInt,
            QueryOperator.LessThanOrEqual
        )
        .GetValue(instrument => instrument.ToHiddenPrice)
    );


var queryResult = queryFilter.GenerateQuery(instrumentFilter);
Console.WriteLine(queryResult.Query);
Console.ReadLine();