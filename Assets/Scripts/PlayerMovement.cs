using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject hpVFX;
    
   
    
    public Player2Movement player2;
    public Transform[] points;
    public float speed;
    public float turnSpeed;
    public float jumpForce;
    public float gravity;
    public LayerMask layerGround;
    public bool isTouch;
    public int index;

    public bool isGround = true;
    
    private Rigidbody rb;
    private float posX;
    public Animator animator;
    public float Timer;
    private float runTime = Mathf.Infinity;
    

    // Start is called before the first frame update
    private void Awake()
    {
        hpVFX.SetActive(false);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        index = 1;
        runTime = Timer;

    }

    // Update is called once per frame
    void Update()
    {
        if (index==1 && player2.index==0)
        {
            
            animator.SetBool("isHold", true);
            isTouch = true;
            hpVFX.SetActive(true);
        }
        else
        {
            AudioManager.instance.PlayFX("VFX");
            isTouch = false;
            hpVFX.SetActive(false);
        }
        runTime -= Time.deltaTime;
        if (runTime < 0) 
        {
            runTime = Timer;
            speed += speed * 0.05f;
        }
        Jump();
        MoveHorizontal();
        Move();
     
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[index].position, turnSpeed * Time.deltaTime);
        transform.position += new Vector3(0, 0, speed);
    }

    private void MoveHorizontal()
    {
        if (Input.GetKey(KeyCode.A))
        {
            
            if (index > 0)
            {
                AudioManager.instance.PlayFX("Move");
                index--;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (index < 1)
            {
                AudioManager.instance.PlayFX("Move");
                index++;
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.W) && isGround)
        {
            AudioManager.instance.PlayFX("Jump");
            rb.velocity = new Vector3(0, jumpForce, 0);
            animator.SetBool("isJump", true);
            isGround = false;
        }
        if (rb.velocity.y <= 0)
        {
            animator.SetBool("isJump", false);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1f, layerGround))
            {
                if (hit.collider.gameObject != null)
                {
                    isGround = true;
                }
            }
        }
    }
    
  
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Enemy")
        {
            AudioManager.instance.PlayFX("Collider");
            speed = 0;
            player2.speed = 0;
            points[0].gameObject.SetActive(false);
            points[1].gameObject.SetActive(false);
            
            if (other.name == "Gai")
            {
                animator.SetBool("isSlide", true);
            }
            else
            {
                animator.SetBool("isFall", true);
            }
            this.enabled = false;
            player2.enabled = false;
        }
        
    }
    
}
