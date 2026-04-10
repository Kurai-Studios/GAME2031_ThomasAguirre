using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections;

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

    [Header("Health")]
    [SerializeField] private int maxLives = 3;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private float invulnerabilityDuration = 1f;
    private int currentLives;
    private bool isInvulnerable = false;

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
        currentLives = maxLives;
        UpdateDisplay();
    }

    void Update()
    {
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

    public void TakeDamage(int damage)
    {
        if (isInvulnerable) return;

        currentLives -= damage;
        UpdateDisplay();

        if (currentLives <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(InvulnerabilityFrames());
        }
    }

    private void UpdateDisplay()
    {
        if (livesText != null)
        {
            livesText.text = $"Lives: {currentLives}";
        }
        else
        {
            Debug.Log($"Lives: {currentLives}");
        }
    }

    private IEnumerator InvulnerabilityFrames()
    {
        isInvulnerable = true;

        float blink = 0;

        while (blink < invulnerabilityDuration)
        {
            if (playerSprite != null)
                playerSprite.enabled = !playerSprite.enabled;

            yield return null;
            blink += Time.deltaTime;
        }

        if (playerSprite != null)
            playerSprite.enabled = true;

        isInvulnerable = false;
    }

    private void Die()
    {
        //Debug.Log("You couldn't escape the seal and will remain trapped");
        this.enabled = false;
    }

    public int GetCurrentLives() => currentLives;
}
