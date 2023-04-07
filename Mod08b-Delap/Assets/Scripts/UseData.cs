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

    private float startDelay = 1.0f;
    private float timeInterval = 0.25f;

    private int rowCount = 0;
    private int rowMax;

    private object tempObj;
    private float tempFloat;

    // private Renderer objRenderer;

    void Awake()
    {
        data = CSVReader.Read("data-trimmed");

        rowMax = data.Count;
        
        for (var i = 0; i < data.Count; i++)
        {
            print("data row " + i);
        }
    }

    void Start()
    {
        InvokeRepeating("modifyObjs", startDelay, timeInterval);
    }

    void modifyObjs() {
        if (rowCount < rowMax) {
            
        }
    }
}