using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 _lastMouseWorldPosition;
    private bool _isDragging = true;

    private void OnEnable()
    {
        DragItems.OnDragStart += DisableDragging;
        DragItems.OnDragEnd += EnableDragging;   
    }

    private void OnDisable()
    {
        DragItems.OnDragStart -= DisableDragging; 
        DragItems.OnDragEnd -= EnableDragging;
    }

    private void DisableDragging()
    {
        _isDragging = false; // Отключаем возможность двигать камеру
    }

    private void EnableDragging()
    {
        _isDragging = true; // Включаем возможность двигать камеру
    }

    void Update()
    {
        if (!_isDragging) return;

       

        if (Input.GetMouseButtonDown(0))
        {
            _lastMouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 currentMouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 difference = _lastMouseWorldPosition - currentMouseWorldPosition;
            Vector3 newPosition = transform.position + new Vector3(difference.x, 0, 0);

            newPosition.x = Mathf.Clamp(newPosition.x, -4.2f, 3.9f);

            transform.position = newPosition;
        }
            


        
    }
}
