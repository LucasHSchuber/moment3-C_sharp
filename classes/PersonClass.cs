namespace Person1 // Replace this with your project's namespace
{

    public class Person
    {
        public readonly string HomePlanet = "Earth";

        // Properties
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; } // Add this property
        

        // Constructor
        public Person(string name, int age, DateTime dateOfBirth)
        {
            Name = name;
            Age = age;
            DateOfBirth = dateOfBirth;

        }

        public int New_a => DateTime.Today.Year - DateOfBirth.Year;

        // Method
        public void SayHello()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age}, {New_a} years old, from {HomePlanet}.");
        }
        public string SayHelloTo(string name = "Lucas")
        {
            return $"{Name} says 'Hello, {name}!'";
        }
    }
}
