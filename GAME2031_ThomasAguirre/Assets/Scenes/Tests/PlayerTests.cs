using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerTests
{
    private const string SceneName = "GameScene";

    [UnityTest]
    public IEnumerator Player_IsSetUpCorrectly()
    {
        // Load the Scene
        SceneManager.LoadScene(SceneName);

        yield return null;

        // Find the player
        GameObject player = GameObject.FindWithTag("Player");
        Assert.IsNotNull(player, "Player not found!");

        // PLayer has Rb
        Rigidbody2D rb2D = player.GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb2D, "Missing Rigidbody2D");

        // Player has Collider
        Collider2D collider2D = player.GetComponent<Collider2D>();
        Assert.IsNotNull(collider2D, "Missing Collider");

        // is non Kinematic
        Assert.AreEqual(RigidbodyType2D.Dynamic, rb2D.bodyType, "Rigidbody2D should be dynamic");
        Assert.AreEqual(0.0f, rb2D.gravityScale, "Gravity should be 0");
    }
}
