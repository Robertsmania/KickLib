namespace KickLib.Client.Models.Events.Chatroom;

public class SenderIdentity
{
    public string Color { get; set; }

    public ICollection<Badge> Badges { get; set; }
}