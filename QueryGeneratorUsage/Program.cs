using QueryableDtos;
using QueryGenerator;

var instrumentFilter = new InstrumentFilterDto();
instrumentFilter.FromHiddenPrice = 1;
instrumentFilter.ToHiddenPrice = 2;
instrumentFilter.NewInstrumentFilter = "Test";
var queryFilter = new QueryFilter<InstrumentFilterDto>().Init("basicinfo.v2", "instrument")
    .AddFilter(new QueryFilterColumn("Isin", System.Data.SqlDbType.NVarChar, QueryOperator.Like).GetValue<InstrumentFilterDto>(instrument => instrument.Isin));
    

Console.WriteLine(queryFilter.GenerateQuery(instrumentFilter).Query);