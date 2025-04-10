using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    private float timeRun = Mathf.Infinity;

    public float timer;
    public GameObject barEnergy;
    public PlayerMovement player;
    public Player2Movement player2;
    public GameObject heart;
// Start is called before the first frame update

    void Start()
    {
        timeRun = timer;
    }

// Update is called once per frame
    void Update()
    {
        if(!player.isTouch)
        {
            timeRun -= Time.deltaTime;
            if (timeRun < 0)
            {
                timeRun = timer;
                //Giam nang luong
                barEnergy.GetComponent<Image>().fillAmount -= 0.1f;

            }
        }
        else
        {
            timeRun -= Time.deltaTime;
            if (timeRun < 0)
            {
                timeRun = timer;
                //Giam nang luong
                barEnergy.GetComponent<Image>().fillAmount += 0.1f;

            }
        }
        if (barEnergy.GetComponent<Image>().fillAmount <= 0.3f)
        {
            heart.GetComponent<Animator>().SetTrigger("isLow");
        }
        if (barEnergy.GetComponent<Image>().fillAmount <= 0) 
        {
            player.enabled = false;
            player.speed = 0;
            player2.enabled = false;
        }

        if (player.speed == 0)
        {
           timeRun = timer;
        }
    }
}
