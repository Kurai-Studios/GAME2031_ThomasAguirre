using System.Collections.Generic;

public class CMDHistory
{
    private List<ICommand> commandList = new();
    private int index = -1;

    public void ExecuteCommand(ICommand command)
    {
        if (index <  commandList.Count - 1)
        {
            commandList.RemoveRange(index + 1, commandList.Count - index - 1);
        }

        // Thomas Aguirre

        //101507894

        command.Execute();
        commandList.Add(command);
        index ++;
    }

    public void Undo()
    {
        if (index < 0) return;

        commandList[index].Undo();
        index --;
    }

    public void Redo()
    {
        if (index + 1 >= commandList.Count) return;

        index ++;
        commandList[index].Execute();
    }
}
