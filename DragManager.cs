using UnityEngine;

public class DragManager : MonoBehaviour
{
    private Camera mainCamera;
    private DragObject currentDrag;
    public LayerMask draggableLayer;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, draggableLayer))
            {
                currentDrag = hit.collider.GetComponent<DragObject>();
                if (currentDrag != null)
                {
                    currentDrag.StartDragging();
                }
            }
        }

        if (Input.GetMouseButton(0) && currentDrag != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 targetPoint = ray.GetPoint(5f); // ระยะประมาณกลาง ๆ
            currentDrag.UpdateDragging(targetPoint);
        }

        if (Input.GetMouseButtonUp(0) && currentDrag != null)
        {
            currentDrag.StopDragging();
            currentDrag = null;
        }
    }
}
