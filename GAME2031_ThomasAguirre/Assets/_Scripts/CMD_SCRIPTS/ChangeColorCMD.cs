using UnityEngine;

public class ChangeColorCMD : ICommand
{
    private readonly cmd_player player;
    private readonly Color newColor;
    private Color oldColor;

    public ChangeColorCMD(cmd_player player, Color newColor)
    {
        this.player = player;
        this.newColor = newColor;
    }
    public void Execute()
    {
        oldColor = player.CurrentColor;
        player.ChangeColor(newColor);
    }

    public void Undo()
    {
        player.ChangeColor(oldColor);
    }
}
