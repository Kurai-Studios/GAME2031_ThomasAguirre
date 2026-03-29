public class MoveRightCMD : ICommand
{
    private readonly cmd_player player;

    public MoveRightCMD(cmd_player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.MoveRight();
    }

    public void Undo()
    {
        player.MoveLeft();
    }
}
