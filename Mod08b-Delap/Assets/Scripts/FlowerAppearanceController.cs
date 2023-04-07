using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAppearanceController : MonoBehaviour
{
    GameObject flower;

    Renderer flowerRenderer;

    void Start() {
        flower = transform.GetChild(0).GetChild(0).gameObject;

        flowerRenderer = flower.GetComponent<Renderer>();
    }
    
    public void setColor(Color color) {
        flowerRenderer.material.SetColor("_Color", color);
    }

    public void setScale(float scaleVal) {
        // I scale the parent gameobject (the one this script is attached to)
        // because it's scale starts at 1 so it's easy to update without
        // accounting for a starting size
        gameObject.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
    }
}
