using UnityEngine;

public class FloorLying : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.linearVelocity = new(0f, 0f);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = 0.3f;
    }
}
