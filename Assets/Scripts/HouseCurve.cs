using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCurve : MonoBehaviour
{
    public Material road;
    public Material houseLeft;
    public Material houseRight;
    public Material box;
    public Material wall;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        houseLeft.SetFloat("_Curve_X", -road.GetFloat("_Curve_X"));
        houseLeft.SetFloat("_Curve_Y", road.GetFloat("_Curve_Y"));

        houseRight.SetFloat("_Curve_X", road.GetFloat("_Curve_X"));
        houseRight.SetFloat("_Curve_Y", road.GetFloat("_Curve_Y"));

        box.SetFloat("_Curve_X", -road.GetFloat("_Curve_X"));
        box.SetFloat("_Curve_Y", -road.GetFloat("_Curve_Y"));

        wall.SetFloat("_Curve_X", -road.GetFloat("_Curve_X"));
        wall.SetFloat("_Curve_Y", -road.GetFloat("_Curve_Y"));
    }
}
