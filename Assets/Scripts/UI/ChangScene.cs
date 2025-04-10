using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScene : MonoBehaviour
{
    public void effect()
    {
        AudioManager.instance.PlayFX("Button");
    }
    public void Menu()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
