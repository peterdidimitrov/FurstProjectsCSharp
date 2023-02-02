namespace DefiningClasses
{
    public class DateModifier
    {
        
        public double GetDifference(string first, string second)
        {
            string[] input = first
                .Split().ToArray();
            int year = int.Parse(input[0]);
            int month = int.Parse(input[1]);
            int day = int.Parse(input[2]);

            string[] inputTwo = second
                .Split().ToArray();
            int yearTwo = int.Parse(inputTwo[0]);
            int monthTwo = int.Parse(inputTwo[1]);
            int dayTwo = int.Parse(inputTwo[2]);


            DateTime startDate = new DateTime(year, month, day);
            DateTime endDate = new DateTime(yearTwo, monthTwo, dayTwo);

            double difference = endDate.Subtract(startDate).TotalDays;
            return difference;
        }
    }
}
