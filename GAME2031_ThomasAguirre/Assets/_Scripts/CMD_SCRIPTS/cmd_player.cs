using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]

public class cmd_player : MonoBehaviour
{
    [SerializeField] private float moveStep = 1.0f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public Color CurrentColor => spriteRenderer != null ? spriteRenderer.color : Color.white;

    private void Awake()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    public void MoveLeft()
    {
        transform.position += Vector3.left * moveStep;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f));
    }

    public void MoveRight() 
    {
        transform.position += Vector3.right * moveStep;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0f));
    }

    public void ChangeColor(Color color)
    {
        if (spriteRenderer == null) return;

        spriteRenderer.color = color;
    }

    public void Mistery()
    {
        spriteRenderer.enabled = false;
    }
}
