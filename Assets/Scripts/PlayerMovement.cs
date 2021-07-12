using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody2D rb;
    private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.touchCount > 0)
        {
            AllowYMovement();
            rb.velocity = Vector2.up * speed;
        }
    }

    private void AllowYMovement()
    {
        if (rb.constraints == RigidbodyConstraints2D.FreezePosition)
        {
            gameManager.Play();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
