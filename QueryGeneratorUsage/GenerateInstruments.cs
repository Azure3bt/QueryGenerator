namespace QueryGeneratorUsage
{
    public static class GenerateInstruments
    {

        public static IQueryable<Instrument> Generate(int count = 100)
        {
            var result = new List<Instrument>();
            foreach (var index in Enumerable.Range(0, count))
            {
                result.Add(new Instrument()
                {
                    Name = $"Instrument{index}",
                    NewInstrumentId = "AmirAli",
                    NewInstrumentName = "AmirAbbas",
                    NewInstrumentText = "Abbas",
                    HiddenPrice = count % 5
                });
            }

            return result.AsQueryable();
        }
    }
}
