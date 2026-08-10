namespace QueryGeneratorUsage
{
    public static class GenerateInstruments
    {

        public static IQueryable<Instrument> Generate(int count = 100)
        {
            var result = new List<Instrument>();
            foreach (var index in Enumerable.Range(0, count))
            {

                var instrument = new Instrument()
                {
                    Name = $"Instrument{index}",
                    HiddenPrice = index,
                    Bourse = new Bourse()
                };

                if(index <= 22)
                {
                    instrument.NewInstrumentId = "AmirAli";
                    instrument.NewInstrumentName = "AmirAbbas";
                    instrument.NewInstrumentText = "Abbas";
                    instrument.Bourse = new Bourse()
                    {
                        Id = index,
                        MarketName = $"MarketName{index}"
                    };
                }


                result.Add(instrument);
            }

            return result.AsQueryable();
        }
    }
}
