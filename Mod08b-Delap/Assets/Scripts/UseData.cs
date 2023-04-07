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

        // call static method to calculate color based on data
        Color flowerColor = 
            FlowerAppearanceController.calculateColor(xhdo, xch4, xco2);
        // have each script instance change its objects color
        foreach (FlowerAppearanceController script in flowerScripts) {
            script.setColor(flowerColor);
        }
    }

    void changeScaleFlowers() {
        tempObj = data[rowCount]["sia"];
        float scale = System.Convert.ToSingle(tempObj);

        scale = scale / 1050;

        // have each script instance change its objects scale
        foreach (FlowerAppearanceController script in flowerScripts) {
            script.setScale(scale);
        }
    }
}