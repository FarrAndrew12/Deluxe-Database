using DatabaseDeluxe.Models;
using DatabaseDeluxe;







public class Program
{
    int studentnumber;
    int convertednumber;
    public static void Main()
    {

        bool runAgain = true;
        while (runAgain == true)

        {

            StudentCrud SC = new StudentCrud();
            StudentId newStudent = new StudentId() { StudentName = "Jim", HomeTown = "Houstalantavegas", FavFood = "Tears" };

            //SC.CreateStudent(newStudent);

            SC.DeleteStudent(2);
            SC.DeleteStudent(1);


            List<string> names = new List<string> { "John", "Jack", "Jill", "Jane", "Joe" };
            List<string> homeTowns = new List<string> { "San Andreas", "Vice City", "Liberty City", "Los Santos", "Chinatown" };
            List<string> favFood = new List<string> { "Alfredo", "Pizza", "Popcorn", "Sphagetti", "Chicken Shwarma" };
            List<string> favColor = new List<string> { "Blue", "Purple", "Red", "Black", "White" };
            int input = 0;

            string AddOrCont = GetUserInput("Hi! Would you like to learn about a current student, or tell us about a brand new student").ToLower().Trim();

            if (AddOrCont == "current" || AddOrCont == "current student")
            {
                Console.WriteLine("Awesome");
            }
            else if (AddOrCont == "new student" || AddOrCont == "new")
            {

                names.Add(GetUserInput("First, What is the new students first name?"));
                Console.WriteLine();
                Console.WriteLine($"The new students name is {names[5]}");
                
                homeTowns.Add(GetUserInput("Where is the student from?"));
                Console.WriteLine();
                Console.WriteLine($"{names[5]}'s hometownn is {homeTowns[5]}");
                Console.WriteLine();
                favFood.Add(GetUserInput("What is their favorite food?"));
                Console.WriteLine();
                Console.WriteLine($"{names[5]}'s favorite food is {favFood[5]}");
                Console.WriteLine();
                favColor.Add(GetUserInput("What is their favorite color?"));
                Console.WriteLine();
                Console.WriteLine($"{names[5]}'s favorite color is {favColor[5]}");
            }
            else
            {
                Console.WriteLine("That is not a valid input, please try again");
                continue;
            }
            string response = GetUserInput("Welcome! Which student would you like to learn about? Enter a number between 1 and 5:");


            try
            {
                input = int.Parse(response);
                Console.WriteLine($"Student number {input}'s name is {names[input - 1]}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("That was not a valid entry, plus input a whole number between 1 and 5");
                Console.WriteLine("Let us try that again");
                Console.WriteLine();
                continue;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("The input was out of range, please input a whole number between 1 and 5");
                Console.WriteLine("Let's try that again");
                Console.WriteLine();
                continue;
            }



            string topic = GetUserInput($"What would you like to learn about {names[input - 1]}? hometown, favorite food, or favorite color?").ToLower().Trim();
            string[] acceptInputs = { "hometown", "ht", "town", "favorite food", "food", "ff", "color", "c", "fc" };
            while (!acceptInputs.Contains(topic))
            {
                Console.WriteLine("I'm sorry I didn't follow that lets try again");
                topic = GetUserInput($"What would you like to learn about {names[input - 1]}? hometown, favorite food, or favorite color ").ToLower().Trim();
            }
            try
            {
                if (topic == "hometown" || topic == "ht" || topic == "town")
                {
                    Console.WriteLine($"{names[input - 1]}'s home town is {homeTowns[input - 1]}");
                }
                else if (topic == "favorite food" || topic == "food" || topic == "ff")
                {
                    Console.WriteLine($"{names[input - 1]}'s favorite food is {favFood[input - 1]}");

                }
                else if (topic == "color" || topic == "c" || topic == "fc")
                {
                    Console.WriteLine($"{names[input - 1]}'s favorite color is {favColor[input - 1]}");
                }
                else
                {

                    throw new Exception("Please input hometown or favorite food, let's try that again");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            runAgain = RunAgain();
        }

    }
    private static string GetUserInput(string Prompt)
    {
        string result;
        do
        {
            Console.WriteLine(Prompt);
            result = Console.ReadLine();
            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("Empty input, please try again");
            }
        } while (string.IsNullOrEmpty(result));
        return result;
    }
    public static bool RunAgain()
    {
        string input = GetUserInput("Would you like to try selecting a student again? Y/N");

        if (input == "y")
        {
            return true;
        }
        else if (input == "n")
        {
            Console.WriteLine("GoodBye");
            return false;
        }
        else
        {
            Console.WriteLine("I didn't understand that lets try again");
            return RunAgain();
        }
    }

}