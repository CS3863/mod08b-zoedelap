using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAppearanceController : MonoBehaviour
{
    // GameObject sun; 

    void Start() {
        // sun = transform.GetChild(0).gameObject;
    }

    public void setAngle(float zenAngle, float aziAngle) {
        gameObject.transform.localEulerAngles = new Vector3(zenAngle, aziAngle, 0.0f);
    }
}
