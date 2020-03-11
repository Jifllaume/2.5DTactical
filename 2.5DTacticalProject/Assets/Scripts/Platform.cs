using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Renderer))]
public class Platform : MonoBehaviour, IRaycastableObject
{
    Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = GetComponent<Renderer>().material.GetColor("_Color");
    }

    public void onRaycastHit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.black);
    }

    public void onRaycastExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", originalColor);
    }

    
}
