using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
public class SpawnBox : MonoBehaviour
{
    private bool OnClickBox = false;
    private Renderer Render;
    public GameObject objectToSpawn;   // Prefab
    public Transform spawnPoint;       // จุดที่จะเกิด
    void Start()
    {
        Render = GetComponent<Renderer>();

    }
    async Task OnMouseDown()  // เมื่อคลิก object นี้
    {
        if (objectToSpawn != null && spawnPoint != null)
        {
            StartCoroutine(ClickIt());
        }
    }

private IEnumerator ClickIt()
{
    OnClickBox = true;
    Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    Render.material.color = Color.green;

    yield return new WaitForSeconds(0.1f); // ✅ รอตรงนี้ 1 วินาที

    OnClickBox = false;
    Render.material.color = Color.white;
}
    private void OnMouseEnter()
    {
        if (!OnClickBox)
        {
            Render.material.color = Color.yellow;
        }

    }
    private void OnMouseExit()
    {
        if (!OnClickBox)
        {
            Render.material.color = Color.white;
        }
    }
}