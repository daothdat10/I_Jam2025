using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject scorePlayer;
    public PlayerMovement player;
    public Player2Movement player2;
    public GameObject panelPause;
    public GameObject buttonPause;
    private float saveSpeed1;
    private float saveSpeed2;
    
    private void Start()
    {
        AudioManager.instance.PlayMBG("PlayGame");
        AudioManager.instance.StopMBG("MenuGame");
        saveSpeed1 = player.speed;
        saveSpeed2 = player2.speed;
        panelPause.SetActive(false);
    }

    private void Update()
    {
        
        if (player.enabled == false)
        {
            scorePlayer.GetComponent<Animator>().SetBool("isOut", true);
            gameOver.GetComponent<Animator>().SetBool("isOver", true);
            buttonPause.SetActive(false);
        }
    }
    public void Menu()
    {
        
        AudioManager.instance.PlayFX("Button");
        AudioManager.instance.StopMBG("PlayGame");
        AudioManager.instance.PlayMBG("MenuGame");
       
        SceneManager.LoadScene("StartScene");
        player.speed = saveSpeed1;
        player2.speed = saveSpeed2;
        Time.timeScale = 1;
       
    }

    public void PauseGame()
    {
        AudioManager.instance.PlayFX("Button");
        panelPause.SetActive(true);
        buttonPause.SetActive(false);
        player.speed = 0;
        player2.speed = 0;
        Time.timeScale = 0;
    }

    public void ContineuGame()
    {
        AudioManager.instance.PlayFX("Button");
        panelPause.SetActive(false);
        buttonPause.SetActive(true);
        player.speed = saveSpeed1;
        player2.speed = saveSpeed2;
        Time.timeScale = 1;
        
    }

    public void RestartGame()
    {
        AudioManager.instance.PlayFX("Button");
        player.speed = saveSpeed1;
        player2.speed = saveSpeed2;
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayScene");
    }
}
