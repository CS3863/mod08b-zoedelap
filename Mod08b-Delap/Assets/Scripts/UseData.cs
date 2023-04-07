using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UseData : MonoBehaviour
{
    /**
    * Tutorial link
    * https://github.com/tikonen/blog/tree/master/csvreader
    * */

    List<Dictionary<string, object>> data; 

    private float startDelay = 0.5f;
    private float timeInterval = 0.05f;

    private int rowCount = 0;
    private int rowMax;

    private object tempObj;

    public FlowerAppearanceController[] flowerScripts;
    public SunAppearanceController sunScript;

    void Awake() {
        data = CSVReader.Read("data-trimmed");

        rowMax = data.Count;
        
        for (var i = 0; i < data.Count; i++)
        {
            print("data row " + i);
        }
    }

    void Start() {
        InvokeRepeating("modifyObjs", startDelay, timeInterval);
    }

    void modifyObjs() {
        if (rowCount < rowMax) {
            changeColorFlowers();
            changeScaleFlowers();
            changeSunPosition();

            rowCount++;
        }
    }

    void changeColorFlowers() {
        // read values used to control color
        tempObj = data[rowCount]["xhdo"];
        float xhdo = System.Convert.ToSingle(tempObj);
        tempObj = data[rowCount]["xch4"];
        float xch4 = System.Convert.ToSingle(tempObj);
        tempObj = data[rowCount]["xco2"];
        float xco2 = System.Convert.ToSingle(tempObj);

        Color flowerColor = calculateColor(xhdo, xch4, xco2);
        // have each script instance change its objects color
        foreach (FlowerAppearanceController script in flowerScripts) {
            script.setColor(flowerColor);
        }
    }

    void changeScaleFlowers() {
        tempObj = data[rowCount]["sia"];
        float scale = System.Convert.ToSingle(tempObj);

        // rescale scale to be between 0.5 and 1
        scale = (scale - 30.1f) / (1138.3f - 30.1f)*(1.0f-0.5f)+0.5f;

        // have each script instance change its objects scale
        foreach (FlowerAppearanceController script in flowerScripts) {
            script.setScale(scale);
        }
    }

    void changeSunPosition() {
        tempObj = data[rowCount]["azim"];
        float aziAngle = System.Convert.ToSingle(tempObj);
        
        aziAngle = (aziAngle - 73.81f) / (274.24f - 73.81f)*(45+45)-45;
        Debug.Log(aziAngle);

        sunScript.setAzizmuthAngle(aziAngle);
    }

    Color calculateColor(float xhdo, float xch4, float xco2) {
        // scale variables down. Adjusted the max values on some of them
        // so that they err closer to 1 rather than 0 to avoid ugly grey colors
        float red = (xhdo - 664)/(2600 - 664);
        float green = (xch4 - 1.7793f)/(1.9016f - 1.7793f);
        float blue = (xco2 - 389)/(415 - 389);

        return new Color(red, green, blue, 0.0f);
    }
}