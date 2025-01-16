using System;
using UnityEngine;

public class DragItems : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    public static event Action OnDragStart;
    public static event Action OnDragEnd;   

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDrag()
    {
        anim.SetBool("Picked", true);
        Vector2 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new(cursor.x, cursor.y, 0f);
        rb.gravityScale = 0;

        OnDragStart?.Invoke();
    }
    private void OnMouseUp() 
    {
        OnDragEnd?.Invoke();

        anim.SetBool("Picked", false);
        rb.gravityScale = 0.5f;
    }
}
