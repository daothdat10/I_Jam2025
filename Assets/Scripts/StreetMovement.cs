using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetMovement : MonoBehaviour
{ 
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Camera.main.transform.position.z > transform.position.z + 20)
        {
            transform.position += new Vector3(0, 0, 180);
        }
    }
}
