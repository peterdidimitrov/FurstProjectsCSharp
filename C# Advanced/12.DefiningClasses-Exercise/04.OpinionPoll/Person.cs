namespace DefiningClasses;

public class Person
{
    //Fields
    private string name;
    private int age;

    //Constructors
    public Person()
    {
        Name = "No name";
        Age = 1;
    }

    public Person(int age)
        : this()
    {
        Age = age;
    }

    public Person(string name, int age)
        : this(age)
    {
        Name = name;
    }

    //Properties
    public string Name { get; set; }

    public int Age { get; set; }
}