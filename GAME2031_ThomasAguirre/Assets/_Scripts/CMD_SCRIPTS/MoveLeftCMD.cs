public class MoveLeftCMD : ICommand
{
    private readonly cmd_player player;

    public MoveLeftCMD(cmd_player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.MoveLeft();
    }

    public void Undo()
    {
        player.MoveRight();
    }
}
