using KodealongOppgave;

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            var house = new House();

            Console.Clear();
            Console.WriteLine("Du starter i rom A og målet er å finne rom F. Tryk enter for å starte...");
            Console.ReadLine();

            var keysPickedUp = new List<string>();
            string chosenKey = String.Empty;

            while (house.CurrentRoom.Name != 'F')
            {
                Console.Clear();
                Console.WriteLine($"Du er i rom {house.CurrentRoom.Name}");
                Console.WriteLine($"Chosen key - {(string.IsNullOrEmpty(chosenKey) ? "none" : chosenKey)}");
                Console.WriteLine();
                Console.WriteLine("Choose one of the following and press enter....");

                ShowMenu(house);

                int userChoice = Convert.ToInt32(Console.ReadLine());

                if (house.CurrentRoom.HasKey)
                {
                    if (userChoice == 1)
                    {
                        house.CurrentRoom.HasKey = false;
                        keysPickedUp.Add(house.CurrentRoom.KeyColor);
                        Console.Clear();
                        Console.WriteLine($"Du har plukket opp en {house.CurrentRoom.KeyColor} key");
                        Console.WriteLine("Trykk enter for å gå tilbake til hovedmeny..");
                        Console.ReadLine();
                    }

                    if (userChoice == 2)
                    {
                        chosenKey = ChooseKey(keysPickedUp, chosenKey);
                    }

                    if (userChoice == 3)
                    {
                        GotoRoom(chosenKey, house);
                    }
                }
                else
                {
                    if (userChoice == 1)
                    {
                        chosenKey = ChooseKey(keysPickedUp, chosenKey);
                    }

                    if (userChoice == 2)
                    {
                        GotoRoom(chosenKey, house);
                    }
                }


            }

            Console.WriteLine("Du fant rom F, trykk enter for å start igjen...");
            Console.ReadLine();
        }
    }

    private static void GotoRoom(string chosenKey, House house)
    {
        if (!string.IsNullOrEmpty(chosenKey))
        {
            Console.Write("Hvor vil du gå? ");
            var roomStr = Console.ReadLine();
            var newRoom = roomStr[0];
            house.Move(newRoom, chosenKey);
        }
        else
        {
            Console.WriteLine("Chose a key first. Press enter to go back to main menu...");
            Console.ReadLine();
        }
    }

    private static string ChooseKey(List<string> keysPickedUp, string chosenKey)
    {

        if (keysPickedUp.Count > 0)
        {
            Console.WriteLine("Choose a key ");
            for (var i = 0; i < keysPickedUp.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {keysPickedUp[i]}");
            }

            var userChosenKeyIndex = Convert.ToInt32(Console.ReadLine());

            for (var i = 0; i < keysPickedUp.Count; i++)
            {
                if (i + 1 == userChosenKeyIndex)
                {
                    chosenKey = keysPickedUp[i];
                    Console.WriteLine($"You have chosen the {chosenKey} key, press enter to go back to main menu.");
                    Console.ReadLine();
                }
            }
        }
        else
        {
            Console.WriteLine("You have not picked up any keys yet. Press enter to go back to main menu.");
            Console.ReadLine();
        }

        return chosenKey;
    }

    private static void ShowMenu(House house)
    {
        int menuCount = 0;
        if (house.CurrentRoom.HasKey)
        {
            menuCount++;
            Console.WriteLine($"{menuCount} - pick up the {house.CurrentRoom.KeyColor} key.");
        }

        menuCount++;
        Console.WriteLine($"{menuCount} - choose a key to open door");
        menuCount++;
        Console.WriteLine($"{menuCount} - go to a room");
    }
}