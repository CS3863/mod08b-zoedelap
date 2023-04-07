using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAppearanceController : MonoBehaviour
{
    // GameObject sun; 

    void Start() {
        // sun = transform.GetChild(0).gameObject;
    }

    public void setAzizmuthAngle(float angle) {
        gameObject.transform.localEulerAngles = new Vector3(0.0f, angle, 0.0f);
    }
}
