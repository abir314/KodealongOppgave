namespace KodealongOppgave;

public class Doors
{
    public bool doorToLeft;
    public string doorToLeftcolor;
    public bool doorToLeftOpen;
    public bool doorToTop;
    public string doorToTopcolor;
    public bool doorToTopOpen;
    public bool doorToRight;
    public string doorToRightcolor;
    public bool doorToRightOpen;
    public bool doorToBottom;
    public string doorToBottomcolor;
    public bool doorToBottomOpen;

    public Doors(bool doorToLeft, string doorToLeftcolor, bool doorToLeftOpen, bool doorToTop, string doorToTopcolor, bool doorToTopOpen, bool doorToRight, string doorToRightcolor, bool doorToRightOpen, bool doorToBottom, string doorToBottomcolor, bool doorToBottomOpen)
    {
        this.doorToLeft = doorToLeft;
        this.doorToLeftcolor = doorToLeftcolor;
        this.doorToLeftOpen = doorToLeftOpen;
        this.doorToTop = doorToTop;
        this.doorToTopcolor = doorToTopcolor;
        this.doorToTopOpen = doorToTopOpen;
        this.doorToRight = doorToRight;
        this.doorToRightcolor = doorToRightcolor;
        this.doorToRightOpen = doorToRightOpen;
        this.doorToBottom = doorToBottom;
        this.doorToBottomcolor = doorToBottomcolor;
        this.doorToBottomOpen = doorToBottomOpen;
    }
}