using UnityEngine;

public class CMDInputHandler : MonoBehaviour
{
    [SerializeField] private cmd_player player;

    private CMDHistory history;

    private void Awake()
    {
        history = new CMDHistory();
    }

    private void Update()
    {
        if (player == null) return;

        if (Input.GetKeyDown(KeyCode.A))
            history.ExecuteCommand(new MoveLeftCMD(player));

        if (Input.GetKeyDown(KeyCode.D))
            history.ExecuteCommand(new MoveRightCMD(player));

        if (Input.GetKeyDown(KeyCode.C))
            history.ExecuteCommand(new ChangeColorCMD(player, Color.purple));

        if (Input.GetKeyDown(KeyCode.Z))
            history.Undo();

        if (Input.GetKeyDown(KeyCode.Y))
            history.Redo();

        if (Input.GetKeyDown(KeyCode.M))
            history.ExecuteCommand(new MisteryCMD(player));
    }
}
