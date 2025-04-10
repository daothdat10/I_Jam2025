using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPlayer : MonoBehaviour
{
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 0.1f, player.transform.position.z);
        if (!player.isGround) 
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.5f, 1.5f, 0), player.jumpForce * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(4f, 4f, 0), player.jumpForce * Time.deltaTime);

        }
    }
}
