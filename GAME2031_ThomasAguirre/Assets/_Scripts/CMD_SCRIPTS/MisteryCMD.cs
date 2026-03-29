using UnityEngine;

public class MisteryCMD : ICommand
{
    private readonly cmd_player player;

    public MisteryCMD(cmd_player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.Mistery();
    }

    public void Undo()
    {
        Debug.Log("What are you expecting to happen? you died... you cant undo that");
    }
}
