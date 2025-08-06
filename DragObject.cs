using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DragObject : MonoBehaviour
{
    private Rigidbody rb;
    public bool isDragging = false;
    private Renderer Render;
    private Vector3 dragTargetWorld;
    private float speed = 30f;
    private bool isHovering = false;

    void Start()
    {
        Render = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    public void StartDragging()
    {
        isDragging = true;
    }

    public void StopDragging()
    {
        isDragging = false;
        rb.linearVelocity = Vector3.zero;

        // ถ้ายัง hover อยู่ให้กลับเป็นสีเหลือง ไม่ใช่ขาว
        Render.material.color = isHovering ? Color.yellow : Color.white;
    }

    public void UpdateDragging(Vector3 targetWorldPos)
    {
        dragTargetWorld = targetWorldPos;
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 direction = (dragTargetWorld - transform.position).normalized;
            rb.linearVelocity = direction * speed;
            Render.material.color = Color.red;
        }
    }

    private void OnMouseEnter()
    {
        isHovering = true;

        if (!isDragging)
        {
            Render.material.color = Color.yellow;
        }
    }

    private void OnMouseExit()
    {
        isHovering = false;

        if (!isDragging)
        {
            Render.material.color = Color.white;
        }
    }
}
