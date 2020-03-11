using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public Camera cam;
    public LayerMask layer;
    private IRaycastableObject lastPlatformHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, float.PositiveInfinity, layer);

        if (hit.transform != null)
        {
            IRaycastableObject obj = hit.transform.gameObject.GetComponent<IRaycastableObject>();
            if(lastPlatformHit != null)
            {
                lastPlatformHit.onRaycastExit();
            }
            lastPlatformHit = obj;
            obj.onRaycastHit();
            Debug.Log(hit.transform.gameObject.name);
        }
        else
        {
            if (lastPlatformHit != null)
            {
                lastPlatformHit.onRaycastExit();
                lastPlatformHit = null;
            }
        }
    }
}
