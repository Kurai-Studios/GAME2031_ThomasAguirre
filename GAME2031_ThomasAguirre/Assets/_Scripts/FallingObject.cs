using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            if (CompareTag("Points"))
                playerController.IncrementScore(1);
            else if (CompareTag("Danger"))
                playerController.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
