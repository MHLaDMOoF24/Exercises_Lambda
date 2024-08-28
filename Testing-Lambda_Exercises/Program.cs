using System.Linq;

namespace Testing_Lambda_Exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            program.BasicFiltering();
            program.TransformingData();
            program.LambdaSorting();
            program.LambdaCalculations();
            program.CustomObjectFiltering();
            program.ActionAndFunc();
            program.GroupingData();
            program.ComplexObjectTransformation();
            program.CombiningConditions();
            program.CreateCustomSort();
            program.NestedLambdaExpressions();
        }

        // Exercise 1
        // Use Where on a List<int>
        public void BasicFiltering()
        {
            Console.WriteLine("\nExercise 1\nFilter even numbers");
            List<int> list = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            List<int> even = list.Where(num => num % 2 == 0).ToList();
            foreach (int num in even)
                Console.WriteLine(num);
        }

        // Exercise 2
        // Use Select
        public void TransformingData()
        {
            Console.WriteLine("\nExercise 2\nConvert names to uppercase");
            List<string> list = ["Anni", "Berta", "Charlie", "Duke", "Elsa", "Fiona", "Gertrud"];

            List<string> upper = list.Select(name => name.ToUpper()).ToList();
            foreach (string name in upper)
                Console.WriteLine(name);
        }

        // Exercise 3
        // Use OrderBy
        public void LambdaSorting()
        {
            Console.WriteLine("\nExercise 3\nSort strings by length");
            List<string> list = ["random", "foo", "bar", "in", "your", "face"];

            List<string> sorted = list.OrderBy(list => list.Length).ToList();
            foreach (string name in sorted)
                Console.WriteLine(name);
        }

        // Exercise 4
        // Use Where and Sum together
        public void LambdaCalculations()
        {
            Console.WriteLine("\nExercise 4\nSum numbers greater than 5");
            List<int> list = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            int sum = list.Where(num => num > 5).Sum();
            Console.WriteLine(sum);
        }

        // Exercise 5
        // Use Where on a custom object
        public void CustomObjectFiltering()
        {
            Console.WriteLine("\nExercise 5\nFilter a people older than 30");
            List<Person> people =
                [
                    new Person("Anni", 29),
                    new Person("Berta", 64),
                    new Person("Charlie", 5),
                    new Person("Duke", 37),
                    new Person("Elsa", 23),
                    new Person("Fiona", 33),
                    new Person("Gertrud", 12)
                ];

            List<Person> ancients = people.Where(person => person.Age > 30).ToList();
            foreach(Person person in ancients)
                Console.WriteLine($"{person.Name}, {person.Age}");
        }

        // Exercise 6
        // Use Action<string> and Func<int, int, int> with lambda
        public void ActionAndFunc()
        {
            Console.WriteLine("\nExercise 6\nUse Action and Func delegates in a lambda expression");
            Action<string> fashion = style => Console.WriteLine($"Cool {style}!");
            fashion("shirt");

            Func<int, int, int> sum = (x, y) => x + y;
            Console.WriteLine(sum(1, 2));
        }

        // Exercise 7
        // Use GroupBy
        public void GroupingData()
        {
            Console.WriteLine("\nExercise 7\nGroup fruits by their first letter");
            List<string> fruits = ["Pear", "Apple", "Banana", "Grape", "Peach", "Tomato"];

            // Explicit type is confusing, just use var in general...
            // Grouping by first letter
            IEnumerable<IGrouping<char, string>> groupedFruits = fruits.GroupBy(x => x[0]);

            foreach (IGrouping<char, string> group in groupedFruits)
            {
                Console.WriteLine($"Fruits starting with {group.Key}");
                foreach (string fruit in group)
                    Console.WriteLine($" - {fruit}");
            }
        }

        // Exercise 8
        // Use Where and Select
        public void ComplexObjectTransformation()
        {
            Console.WriteLine("\nExercise 8\nFind students with marks greater than 70");
            List<Student> students =
                [
                    new Student("Anni", 96, 'A'),
                    new Student("Berta", 64, 'F'),
                    new Student("Charlie", 5, 'E'),
                    new Student("Duke", 100, 'A'),
                    new Student("Elsa", 84, 'C'),
                    new Student("Fiona", 91, 'B'),
                    new Student("Gertrud", 72, 'D')
                ];

            // var holds over a lot of information here! 
            // Essentially, could be an entire class called StudentSummary, comprising of Name and Grade variables
            var passingStudents = students
                .Where(student => student.Marks > 70)
                .Select(student => new { student.Name, student.Grade });
            foreach (var student in passingStudents) 
                Console.WriteLine($"{student.Name}, {student.Grade}");
        }

        // Exercise 9
        // Use Where to check multiple conditions
        public void CombiningConditions()
        {
            Console.WriteLine("\nExercise 9\nFind numbers greater than 10, that are divisible by 3");
            List<int> upTo20 = new List<int>();
            for (int i = 0; i < 20; i++)
                upTo20.Add(i + 1);

            List<int> filteredUpTo20 = upTo20
                .Where(num => (num % 3 == 0) && (num > 10))
                .ToList();
            foreach (int i in filteredUpTo20)
                Console.WriteLine(i);
        }

        // Exercise 10
        // Use OderBy and ThenBy
        public void CreateCustomSort()
        {
            Console.WriteLine("\nExercise 10\nSort people by name, then age");
            // This is something called a tuple, a sort of mini variable-only class
            List<(string, int)> people = new List<(string, int)>
            {
                ("Anni", 29),
                ("Berta", 64),
                ("Charlie", 5),
                ("Duke", 37),
                ("Elsa", 23),
                ("Fiona", 33),
                ("Gertrud", 12),
                ("Duke", 16),
                ("Duke", 92)
            };

            List<(string, int)> sortedPeople = people
                .OrderBy(p => p.Item1)
                .ThenBy(p => p.Item2)
                .ToList();
            foreach ((string, int) person in sortedPeople)
                Console.WriteLine($"{person.Item1}, {person.Item2}");
        }

        // Exercise BONUS
        // Combine Where with a nested Any to find children older than 18
        public void NestedLambdaExpressions()
        {
            Console.WriteLine("\nExercise BONUS\nFind people with children above the age of 18");
            List<Person2> people =
                [
                    new Person2("Anni", 29, new List<Person2>{
                        new Person2("Lilly", 3, new List<Person2>())
                    }),
                    new Person2("Berta", 64, new List<Person2>{ 
                        new Person2("Jimothy", 26, new List<Person2>{
                            new Person2("Bertram", 3, new List<Person2>())
                        })
                    }),
                    new Person2("Charlie", 5, new List<Person2>()),
                    new Person2("Duke", 37, new List<Person2>{ 
                        new Person2("Duke jr", 19, new List<Person2>
                            { 
                            new Person2("Duke jr jr", 0, new List<Person2>())
                            }),
                        new Person2("Dukette", 17, new List<Person2>())
                    }),
                    new Person2("Elsa", 23, new List<Person2>()),
                    new Person2("Fiona", 33, new List<Person2>()),
                    new Person2("Gertrud", 12, new List<Person2>())
                ];

            List<Person2> adultPeople = people
                .Where(person => person.Children
                    .Any(child => child.Age > 18))
                .ToList();

            foreach (Person2 person in adultPeople)
            {
                Console.WriteLine("Person: ");
                Console.WriteLine($"{person.Name}, {person.Age}");
                //if (person.Children.Any())
                //{
                //    Console.WriteLine("  Children: ");
                //    foreach (Person2 child in person.Children)
                //    {
                //        Console.WriteLine($"  {child.Name}, {child.Age}");
                //        if (child.Children.Any())
                //        {
                //            Console.WriteLine("    Grandchildren: ");
                //            foreach (Person2 grandchild in child.Children)
                //                Console.WriteLine($"    {grandchild.Name}, {grandchild.Age}");
                //        }
                //    }
                //}
            }
        }


    }

    // Exercise 5 basis
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    // Exercise 8 basis
    public class Student
    {
        public string Name { get; set; }
        public int Marks { get; set; }
        public char Grade { get; set; }

        public Student(string name, int marks, char grade)
        {
            Name = name;
            Marks = marks;
            Grade = grade;
        }
    }

    // Exercise BONUS basis
    public class Person2
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Person2> Children { get; set; }

        public Person2(string name, int age, List<Person2> children)
        {
            Name = name;
            Age = age;
            Children = children;
        }
    }
}
