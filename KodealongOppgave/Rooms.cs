namespace KodealongOppgave;

public class Rooms
{
    public string _roomName;
    public bool _hasKey;
    public string _keyColor;
    public int _positionInTheHouse;
    public Doors _roomDoors;

    public Rooms(string roomName, bool hasKey, string keyColor, int positionInTheHouse, Doors roomDoors)
    {
        _roomName = roomName;
        _hasKey = hasKey;
        _keyColor = keyColor;
        _positionInTheHouse = positionInTheHouse;
        _roomDoors = roomDoors;
    }
}