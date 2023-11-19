namespace ServicePDV.Utils.Mappers
{
    public static class DaysMapper
    {
        public static string TranslateDateToSk(DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Monday => "Pondelok",
                DayOfWeek.Tuesday => "Utorok",
                DayOfWeek.Wednesday => "Streda",
                DayOfWeek.Thursday => "Štvrtok",
                DayOfWeek.Friday => "Piatok",
                DayOfWeek.Saturday => "Sobota",
                DayOfWeek.Sunday => "Nedeľa",
                _ => throw new ArgumentException("Invalid day of the week"),
            };
        }
    }
}
