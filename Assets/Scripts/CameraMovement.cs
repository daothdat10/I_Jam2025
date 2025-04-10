using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public PlayerMovement player;
    public CurveRoad road;
    //public float multiple;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        Camera.main.transform.position += new Vector3(0, 0, player.speed);
       
    }
}
