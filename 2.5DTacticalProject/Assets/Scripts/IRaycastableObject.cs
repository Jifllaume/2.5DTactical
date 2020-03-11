using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRaycastableObject
{
    void onRaycastHit();

    void onRaycastExit();
}
