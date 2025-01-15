using UnityEngine;

public class DragItems : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnMouseDrag()
    {
        anim.SetBool("Picked", true);
        Vector2 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new(cursor.x, cursor.y, 0f);
    }
    private void OnMouseUp() 
    {
        anim.SetBool("Picked", false);
    }
}
