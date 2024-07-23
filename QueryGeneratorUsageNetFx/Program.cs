using QueryableDtos;
using QueryGenerator;
using System;

namespace QueryGeneratorUsageNetFx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var instrumentFilter = new InstrumentFilterDto();
            instrumentFilter.FromHiddenPrice = 1;
            instrumentFilter.ToHiddenPrice = 2;
            instrumentFilter.NewInstrumentFilter = "Test";

            var queryFilter = new QueryFilter<InstrumentFilterDto>().Init("basicinfo.v2", "instrument")
                .AddFilter(
                    new QueryFilterColumn(
                        "Isin",
                        System.Data.SqlDbType.NVarChar,
                        QueryOperator.Like
                    ).GetValue<InstrumentFilterDto>(instrument => instrument.Isin)
                )
                .AddFilter(
                    new QueryFilterColumn(
                        "NewInstrumentId,NewInstrumentName,NewInstrumentText",
                        "NewInstrumentFilter",
                        System.Data.SqlDbType.NVarChar,
                        QueryOperator.Like
                    )
                    .GetValue<InstrumentFilterDto>(instrument => instrument.NewInstrumentFilter)
                )
                .AddFilter(
                    new QueryFilterColumn(
                        "HiddenPrice",
                        "FromHiddenPrice",
                        System.Data.SqlDbType.BigInt,
                        QueryOperator.GreaterThanOrEqual
                    )
                    .GetValue<InstrumentFilterDto>(instrument => instrument.FromHiddenPrice)
                )
                .AddFilter(
                    new QueryFilterColumn(
                        "HiddenPrice",
                        "ToHiddenPrice",
                        System.Data.SqlDbType.BigInt,
                        QueryOperator.LessThanOrEqual
                    )
                    .GetValue<InstrumentFilterDto>(instrument => instrument.ToHiddenPrice)
                );


            var queryResult = queryFilter.GenerateQuery(instrumentFilter);
            Console.WriteLine(queryResult.Query);
            Console.ReadLine();
        }
    }
}
