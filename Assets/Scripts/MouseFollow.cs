using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public TrailRenderer Trail;

    void Update()
    {
        Trail.enabled = Input.GetMouseButton(0);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }
}