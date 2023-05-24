namespace KodealongOppgave;

public class House
{
    private Rooms[] roomsList = new Rooms[6];
    public House()
    {
        
        while (true)
        {
            roomsList = new Rooms[]{
                new Rooms("A", true, "Red", 0, new Doors(false, null,false,false,null,false,true, "Red", false, true, "Green", false)),
                new Rooms("B", true, "Green", 1, new Doors(true, "Red",false,false,null,false,true, "Gray", false, true, "Blue", false)),
                new Rooms("C", true, "White",  2, new Doors(true, "Gray",false,false,null,false,false, null, false, false, null, false)),
                new Rooms("D", true, "Blue", 3, new Doors(false, null,false,true,"Green",false,false, null, false, false, null, false)),
                new Rooms("E", true, "Gray", 4, new Doors(false, null,false,true,"Blue",false,true, "White", false, false, null, false)),
                new Rooms("F", false, null, 5, new Doors(true, "White",false,false,null,false,false, null, false, false, null, false))
        
            };
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("You begin in Room A in a house and you have to find your way to Room F.");
            Console.WriteLine("Press enter to start the game....");
            Console.Read();
            
            var yourPosition = 0;
            var keysPickedUp = new List<string>();
            string chosenKey = null;
            
            while (yourPosition != 5)
            {
                Console.Clear();
                
                var roomYouAreInNow = roomsList[yourPosition];
                var keycolor = roomYouAreInNow._hasKey ? roomYouAreInNow._keyColor : "";
                string doorToLeftColor = roomYouAreInNow._roomDoors.doorToLeft ? roomYouAreInNow._roomDoors.doorToLeftcolor : null;
                string doorToTopColor = roomYouAreInNow._roomDoors.doorToTop ? roomYouAreInNow._roomDoors.doorToTopcolor : null;
                string doorToRightColor = roomYouAreInNow._roomDoors.doorToRight ? roomYouAreInNow._roomDoors.doorToRightcolor : null;
                string doorToBottomColor = roomYouAreInNow._roomDoors.doorToBottom ? roomYouAreInNow._roomDoors.doorToBottomcolor : null;
                var numberOfDoors = 0;
                numberOfDoors = NumberOfDoors(roomYouAreInNow, numberOfDoors);

                ShowCurrentState(roomYouAreInNow, roomsList, yourPosition, chosenKey, keycolor, numberOfDoors, doorToLeftColor, doorToTopColor, doorToRightColor, doorToBottomColor);

                ShowMainMenu(roomYouAreInNow);
                var userchoice = Convert.ToInt32(Console.ReadLine());
                if (roomYouAreInNow._hasKey)
                {
                    if (userchoice == 1)
                    {
                        Console.Clear();
                        roomYouAreInNow._hasKey = false;
                        keysPickedUp.Add(roomYouAreInNow._keyColor);
                        Console.WriteLine($"You picked up a {keycolor} key.");
                        Console.WriteLine("Press enter to go back to main menu.");
                        Console.ReadLine();
                    }

                    if (userchoice == 2)
                    {
                        chosenKey = ChooseKey(keysPickedUp, chosenKey);
                    }

                    if (userchoice == 3)
                    {
                        yourPosition = OpenDoor(chosenKey, roomYouAreInNow, yourPosition);
                    }

                    if (userchoice == 4)
                    {
                        yourPosition = 0;
                        break;
                    }
                }
                else
                {
                    if (userchoice == 1)
                    {
                        chosenKey = ChooseKey(keysPickedUp, chosenKey);
                    }

                    if (userchoice == 2)
                    {
                        yourPosition = OpenDoor(chosenKey, roomYouAreInNow, yourPosition);
                    }

                    if (userchoice == 3)
                    {
                        yourPosition = 0;
                        break;
                    }
                }

                if (yourPosition == 5)
                {
                    yourPosition = 0;
                    Console.WriteLine("Game over, you have reached Room F. Press enter to start again.");
                    Console.ReadLine();
                }
            }
        }
    }

    private int OpenDoor(string? chosenKey, Rooms roomYouAreInNow, int yourPosition)
    {
        Console.Clear();
        if (string.IsNullOrEmpty(chosenKey))
        {
            Console.WriteLine("You have not chosen a key yet, go back to main menu by pressing enter...");
            Console.ReadLine();
        }
        else
        {
            if (roomYouAreInNow._roomDoors.doorToLeft)
            {
                Console.WriteLine(
                    $"1 - Open {roomYouAreInNow._roomDoors.doorToLeftcolor} door to the left to go to room {roomsList[yourPosition - 1]._roomName}.");
            }

            if (roomYouAreInNow._roomDoors.doorToTop)
            {
                Console.WriteLine(
                    $"2 - Open {roomYouAreInNow._roomDoors.doorToTopcolor} door to the top to go to room {roomsList[yourPosition - 3]._roomName}.");
            }

            if (roomYouAreInNow._roomDoors.doorToRight)
            {
                Console.WriteLine(
                    $"3 - Open {roomYouAreInNow._roomDoors.doorToRightcolor} door to the right to go to room {roomsList[yourPosition + 1]._roomName}.");
            }

            if (roomYouAreInNow._roomDoors.doorToBottom)
            {
                Console.WriteLine(
                    $"4 - Open {roomYouAreInNow._roomDoors.doorToBottomcolor} door to the bottom to go to room {roomsList[yourPosition + 3]._roomName}.");
            }

            Console.WriteLine();
            Console.WriteLine($"(You have chosen the {chosenKey} key to use.)");
            Console.WriteLine();
            Console.WriteLine("Choose a door and press enter.");
            var userDoorChoice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (userDoorChoice == 1 && roomYouAreInNow._roomDoors.doorToLeft)
            {
                if (chosenKey == roomYouAreInNow._roomDoors.doorToLeftcolor)
                {
                    yourPosition = yourPosition - 1;
                    Console.WriteLine($"You have entered into Room {roomsList[yourPosition]._roomName}.");
                }
                else
                {
                    Console.WriteLine(
                        $"You tried to open {roomYouAreInNow._roomDoors.doorToLeftcolor} with a {chosenKey} key. Try with another key.");
                }
            }

            if (userDoorChoice == 2 && roomYouAreInNow._roomDoors.doorToTop)
            {
                if (chosenKey == roomYouAreInNow._roomDoors.doorToTopcolor)
                {
                    yourPosition = yourPosition - 3;
                    Console.WriteLine($"You have entered into Room {roomsList[yourPosition]._roomName}.");
                }
                else
                {
                    Console.WriteLine(
                        $"You tried to open {roomYouAreInNow._roomDoors.doorToTopcolor} with a {chosenKey} key. Try with another key.");
                }
            }

            if (userDoorChoice == 3 && roomYouAreInNow._roomDoors.doorToRight)
            {
                if (chosenKey == roomYouAreInNow._roomDoors.doorToRightcolor)
                {
                    yourPosition = yourPosition + 1;
                    Console.WriteLine($"You have entered into Room {roomsList[yourPosition]._roomName}.");
                }
                else
                {
                    Console.WriteLine(
                        $"You tried to open {roomYouAreInNow._roomDoors.doorToRightcolor} with a {chosenKey} key. Try with another key.");
                }
            }

            if (userDoorChoice == 4 && roomYouAreInNow._roomDoors.doorToBottom)
            {
                if (chosenKey == roomYouAreInNow._roomDoors.doorToBottomcolor)
                {
                    yourPosition = yourPosition + 3;
                    Console.WriteLine($"You have entered into Room {roomsList[yourPosition]._roomName}.");
                }
                else
                {
                    Console.WriteLine(
                        $"You tried to open {roomYouAreInNow._roomDoors.doorToBottomcolor} with a {chosenKey} key. Try with another key.");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to go back to main menu.");
            Console.ReadLine();
        }

        return yourPosition;
    }

    private static string ChooseKey(List<string> keysPickedUp, string chosenKey)
    {
        Console.Clear();
        if (keysPickedUp.Count > 0)
        {
            Console.WriteLine("Choose a key ");
            for (var i = 0; i < keysPickedUp.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {keysPickedUp[i]}");
            }

            var userChosenKey = Convert.ToInt32(Console.ReadLine());
            for (var i = 0; i < keysPickedUp.Count; i++)
            {
                if (i + 1 == userChosenKey)
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

    private static void ShowMainMenu(Rooms roomYouAreInNow)
    {
        int optionsMenuCount = 0;
        Console.WriteLine("Your options are -");
        if (roomYouAreInNow._hasKey)
        {
            optionsMenuCount++;
            Console.WriteLine($"{optionsMenuCount} - pick up the {roomYouAreInNow._keyColor} key");
        }

        optionsMenuCount++;
        Console.WriteLine($"{optionsMenuCount} - choose a key from your key collection");
        optionsMenuCount++;
        Console.WriteLine($"{optionsMenuCount} - show doors you can open");
        optionsMenuCount++;
        Console.WriteLine($"{optionsMenuCount} - Start from beginning");
    }

    private static void ShowCurrentState(Rooms roomYouAreInNow, Rooms[] roomsList, int yourCurrentPosition, string chosenKey, string keycolor, int numberOfDoors, string? doorToLeftColor,
        string? doorToTopColor, string? doorToRightColor, string? doorToBottomColor)
    {
        Console.WriteLine(
            $"Now you are in Room {roomYouAreInNow._roomName}. You see {(roomYouAreInNow._hasKey ? "a " + keycolor + " Key and" : "")} {(numberOfDoors > 1 ? numberOfDoors + " doors: " : numberOfDoors + " door: ")}");
        Console.WriteLine();
       if(roomYouAreInNow._roomDoors.doorToLeft) Console.WriteLine($"{"To the left "+ doorToLeftColor + " door to Room " + roomsList[yourCurrentPosition-1]._roomName}");
       if(roomYouAreInNow._roomDoors.doorToTop) Console.WriteLine($"{"To the top "+ doorToTopColor + " door to Room " + roomsList[yourCurrentPosition-3]._roomName}");
       if(roomYouAreInNow._roomDoors.doorToRight) Console.WriteLine($"{"To the right "+ doorToRightColor + " door to Room " + roomsList[yourCurrentPosition+1]._roomName}");
       if(roomYouAreInNow._roomDoors.doorToBottom) Console.WriteLine($"{"To the bottom "+ doorToBottomColor + " door to Room " + roomsList[yourCurrentPosition+3]._roomName}");
       Console.WriteLine();
       Console.WriteLine(string.IsNullOrEmpty(chosenKey)
           ? "Key chosen: none"
           : $"Key chosen: {chosenKey}");
       Console.WriteLine();
    }

    private static int NumberOfDoors(Rooms roomYouAreInNow, int numberOfDoors)
    {
        if (roomYouAreInNow._roomDoors.doorToLeft)
        {
            numberOfDoors++;
        }

        if (roomYouAreInNow._roomDoors.doorToTop)
        {
            numberOfDoors++;
        }

        if (roomYouAreInNow._roomDoors.doorToRight)
        {
            numberOfDoors++;
        }

        if (roomYouAreInNow._roomDoors.doorToBottom)
        {
            numberOfDoors++;
        }

        return numberOfDoors;
    }
}