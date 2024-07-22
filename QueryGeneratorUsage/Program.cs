using QueryableDtos;

var instrumentFilter = new InstrumentFilterDto();
instrumentFilter.FromHiddenPrice = 1;
instrumentFilter.ToHiddenPrice = 2;
instrumentFilter.NewInstrumentFilter = "Test";
var queryGenerator = QueryGenerator.SqlQueryGenerator.GenerateQuery(instrumentFilter);

Console.WriteLine(queryGenerator.Query);