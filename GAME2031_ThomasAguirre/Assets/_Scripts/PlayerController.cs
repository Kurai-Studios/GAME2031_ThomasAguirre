using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;

    [Header("Move Settings")]
    [SerializeField] private float moveForce;
    [SerializeField] private float maxSpeed;

    private float input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        if (input != 0)
        {
            playerSprite.flipX = input < 0;
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.linearVelocityX) <= maxSpeed)
        {
            rb.AddForceX(input * moveForce);
        }
        else
        {
            if (Mathf.Sign(input) != Mathf.Sign(rb.linearVelocityX))
            {
                rb.AddForceX(input * moveForce);
            }
        }
    }
}
