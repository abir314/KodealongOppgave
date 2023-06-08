namespace KodealongOppgave;

public class House
{
    public Room CurrentRoom { get; private set; }

    public House()
    {
        var roomA = new Room('A', "Red");
        var roomB = new Room('B', "Green");
        var roomC = new Room('C', "White");
        var roomD = new Room('D', "Blue");
        var roomE = new Room('E', "Silver");
        var roomF = new Room('F', false);

        CurrentRoom = roomA;

        new Door(roomA, roomD, "Green");
        new Door(roomA, roomB, "Red");
        new Door(roomB, roomC, "Silver");
        new Door(roomB, roomE, "Blue");
        new Door(roomE, roomF, "White");
    }

    public void Move(char newRoom, string chosenKey)
    {
        var room = CurrentRoom.FindDoorTo(newRoom, chosenKey);
        if (room != null)
        {
            CurrentRoom = room;
        }
    }
}