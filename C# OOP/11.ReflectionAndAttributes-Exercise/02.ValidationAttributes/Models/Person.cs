using ValidationAttributes.Utilities.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int AgeMinValue = 12;
        private const int AgeMaxValue = 90;

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }
        [MyRange(AgeMinValue, AgeMaxValue)]
        public int Age { get; private set; }
    }
}
