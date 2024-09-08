//Objectives: 
//•  The game will pick a random number between 0 and 9 (inclusive) to represent the oatmeal raisin 
//cookie. 
//•  The game will allow players to take turns picking numbers between 0 and 9. 
//•  If a player repeats a number  that has been already used, the program should make them  select 
//another.   Hint:  If you use a  List<int>  to store previously chosen numbers, you can use its 
//Contains method to see if a number has been used before.   
//•  If the number matches the one the game picked initially, an exception should be thrown, terminating 
//the program. Run the program at least once like this to see it crash. 
//•  Put in a try/catch block to handle the exception and display the results. 
//•  Answer this question: Did you make a custom exception type or use an existing one, and why did
//you choose what you did? 
//•  Answer this question: You could write this program without exceptions, but the requirements
//demanded an exception for learning purposes. If you didn’t have that requirement, would you have
//used an exception? Why or why not?
internal class Program
{
    private static void Main(string[] args)
    {
        Random random = new Random();
        int secretNum = random.Next(0, 9);
        List<int> list = new List<int>();
        int playerNum = 1;
        int chosenNum;
        while (list.Count != 10) {
            Console.WriteLine($"Player {playerNum} pick:");
            while (int.TryParse(Console.ReadLine(), out chosenNum) == false) {                
                Console.WriteLine($"Player {playerNum} pick:");
            }
            if (list.Contains(chosenNum))
            {
                Console.WriteLine($"This number was already picked, try one more time");
                continue;
            }
            try
            {
                if (chosenNum == secretNum)
                {                 
                    throw new Exception("Right answer");
                }
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }

            if (playerNum == 1) 
                playerNum = 2;             
            else 
                playerNum = 1; 
            list.Add(chosenNum);
        }        
    }
}