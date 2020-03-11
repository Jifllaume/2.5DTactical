using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IRaycastableObject
{
    public void onRaycastExit()
    {
        GetComponent<SpriteOutline>().UpdateOutline(false);
    }

    public void onRaycastHit()
    {
        GetComponent<SpriteOutline>().UpdateOutline(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
