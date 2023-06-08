namespace KodealongOppgave;

public class Door
{
    private string _name;
    private bool closedOrOpen = false;
    public string DoorColor;
    public Room Room1;
    public Room Room2;

    public Door(Room room1, Room room2, string doorColor)
    {
        Room1 = room1;
        Room2 = room2;
        DoorColor = doorColor;
        room1.AddDoor(this);
        room2.AddDoor(this);
    }
}