using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveOnMouse : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public UnityEvent MouseDownEvent;
    public UnityEvent MouseUpEvent;

    private Rigidbody2D rb;
    private Vector2 savedPos;
    private Vector3 distanceMouseObj;
    private bool isDragging;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 destination = Input.mousePosition;
        destination.z = Mathf.Abs(Camera.main.gameObject.transform.position.z);
        distanceMouseObj = transform.position - (Camera.main.ScreenToWorldPoint(destination));
        StartControl();
    }

    private void Update()
    {
        if (isDragging)
        {
            savedPos = GetNewPos();
            rb.MovePosition(savedPos);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopControl();
    }

    public bool IsDragging()
    {
        return isDragging;
    }

    public void StartControl()
    {
        isDragging = true;
        MouseDownEvent.Invoke();
    }

    public void StopControl()
    {
        isDragging = false;
        MouseUpEvent.Invoke();
    }

    private void OnDisable()
    {
        isDragging = false;
    }

    private Vector2 GetNewPos()
    {
        Vector3 destination = Input.mousePosition;
        destination.z = Mathf.Abs(Camera.main.gameObject.transform.position.z);
        return Camera.main.ScreenToWorldPoint(destination) + distanceMouseObj;
    }
}
