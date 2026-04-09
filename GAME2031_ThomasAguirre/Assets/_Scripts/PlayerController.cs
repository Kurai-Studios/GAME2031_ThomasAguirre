using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;

    [Header("Move Settings")]
    [SerializeField] private float moveForce;
    [SerializeField] private float maxSpeed;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    private int score;

    private LE9Input inputActions;

    private float input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new LE9Input();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();

        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<float>();
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;

        inputActions.Player.Disable();
    }

    private void Start()
    {
        SetScore(0);
    }

    void Update()
    {
        //input = Input.GetAxisRaw("Horizontal");

        if (input < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f));
        }
        else if (input > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0f));
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

    public void IncrementScore(int incrementor)
    {
        SetScore(score + incrementor);
    }
    public void SetScore(int score)
    {
        this.score = score;
        scoreText.text = $"Score: {score}";
    }

    public int GetScore() => score;
}
