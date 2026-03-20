using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            playerController.IncrementScore(1);
        }

        Destroy(gameObject);
    }
}
