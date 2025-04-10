using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveRoad : MonoBehaviour
{
    public Material road;
    public float Timer;

    private float timeRun = Mathf.Infinity;
    public float randX;
    public float randomX;
    public float randY;
    public float randomY;

    private void Awake()
    {
        timeRun = Timer;
        randX = 0;
        randY = 0;
    }
    private void Update()
    {
        timeRun -= Time.deltaTime;
        if (timeRun <= 0)
        {
            timeRun = Timer;
            randX = Random.Range(-0.01f, 0.01f);
            randY = Random.Range(-0.005f, 0.005f);

        }
        randomX = Mathf.Lerp(randomX, randX, 0.1f * Time.deltaTime);
        randomY = Mathf.Lerp(randomY, randY, 0.1f * Time.deltaTime);
        road.SetFloat("_Curve_X", randomX);
        road.SetFloat("_Curve_Y", randomY);

    }
}
