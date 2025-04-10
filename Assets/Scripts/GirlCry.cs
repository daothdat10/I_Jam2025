using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlCry : MonoBehaviour
{
    public PlayerMovement player;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.enabled == false && animator.GetBool("isFall") == false)
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isHold", false);
            animator.SetBool("isFall", false);
            animator.SetBool("isCry", true);
        }
    }
}
