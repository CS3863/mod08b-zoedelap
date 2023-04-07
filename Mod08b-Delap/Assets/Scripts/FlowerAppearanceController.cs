using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAppearanceController : MonoBehaviour
{
    GameObject stem;
    GameObject flower;

    Renderer flowerRenderer;

    void Start() {
        stem = transform.GetChild(0).gameObject;
        flower = stem.transform.GetChild(0).gameObject;

        flowerRenderer = flower.GetComponent<Renderer>();
    }

    public static Color calculateColor(float xhdo, float xch4, float xco2) {
        // scale variables down. Adjusted the max values on some of them
        // so that they err closer to 1 rather than 0 to avoid ugly grey colors
        float red = (xhdo - 664)/(2600 - 664);
        float green = (xch4 - 1.7793f)/(1.9016f - 1.7793f);
        float blue = (xco2 - 389)/(415 - 389);

        return new Color(red, green, blue, 0.0f);
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
