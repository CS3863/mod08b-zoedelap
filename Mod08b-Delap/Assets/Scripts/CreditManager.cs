using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{

    private Vector3 endPos = new Vector3(0, 25.0f, -15.0f);
    private float speed = 5.0f;
    public GameObject canvas;

    void Update()
    {
        Debug.Log(Time.realtimeSinceStartup);
        if (Time.realtimeSinceStartup > 4) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPos, step);
            if (transform.position == endPos) {
                canvas.SetActive(false); 
            }
        }
    }
}
