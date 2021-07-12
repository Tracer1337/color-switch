using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerColor))]
public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerColor playerColor;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerColor = GetComponent<PlayerColor>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DetectColorCollision(other);
        DetectSwitchCollision(other);
        DetectVoidCollision(other);
    }

    private void DetectColorCollision(Collider2D other)
    {
        var hasHitColor = playerColor.colors.Select(color => color.tag).Contains(other.tag);
        if (!hasHitColor)
            return;
        if (!other.CompareTag(playerColor.activeColor.tag))
        {
            gameManager.End();
        }
    }

    private void DetectSwitchCollision(Collider2D other)
    {
        if (!other.CompareTag("Switch"))
            return;
        gameManager.NextIteration();
        Destroy(other.gameObject);
    }

    private void DetectVoidCollision(Collider2D other)
    {
        if (!other.CompareTag("Void"))
            return;
        gameManager.End();
    }
}
