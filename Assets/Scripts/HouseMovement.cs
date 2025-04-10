using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseMovement : MonoBehaviour
{
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
        if (Camera.main.transform.position.z > transform.position.z + 21)
        {
            transform.position += new Vector3(0, 0, 84);
        }
    }
}
