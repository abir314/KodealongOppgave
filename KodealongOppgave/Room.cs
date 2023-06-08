namespace KodealongOppgave;

public class Room
{
    public char Name;
    public bool HasKey = true;
    public string KeyColor = String.Empty;
    private List<Door> doors;

    public Room(char name, string keyColor)
    {
        Name = name;
        KeyColor = keyColor;
        doors = new List<Door>();
    }

    public Room(char name, bool hasKey)
    {
        Name = name;
        HasKey = hasKey;
        doors = new List<Door>();
    }

    public void AddDoor(Door DoorToAdd)
    {
        doors.Add(DoorToAdd);
    }

    public Room FindDoorTo(char DestinationRoom, string chosenKey)
    {
        foreach (var door in doors)
        {
            if (door.Room1 == this && door.Room2.Name == DestinationRoom && door.DoorColor == chosenKey) return door.Room2;
            if (door.Room2 == this && door.Room1.Name == DestinationRoom && door.DoorColor == chosenKey) return door.Room1;
        }
        return null;
    }
}