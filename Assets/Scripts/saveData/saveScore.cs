using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class saveScore : MonoBehaviour
{
    // Hiển thị điểm hiện tại
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreValue;

    private float score;

// Hiển thị điểm cao nhất
    [SerializeField]private TextMeshProUGUI highScoreTxt;
    private float highScore;

// Đối tượng GameData để lưu trữ dữ liệu
    private GameData gameData;

    public PlayerMovement player;
    
    public TextMeshProUGUI scorePause;
    public TextMeshProUGUI highScorePause;

    private void Awake()
    {
        // Tải dữ liệu từ SystemSave
        gameData = SystemSave.Load();

        // Nếu đã có điểm cao nhất từ trước
        if (gameData != null)
        {
            highScore = gameData.HighScore;
        }
        else
        {
            // Nếu chưa có dữ liệu, khởi tạo điểm cao nhất là 0
            highScore = 0;
            gameData = new GameData();
        }
    }

    void FixedUpdate()
    {
    
        highScoreTxt.text = ((int)highScore).ToString();
        highScorePause.text = ((int)highScore).ToString();

    
        scoreText.text = ((int)score).ToString();
        scoreValue.text = ((int)score).ToString();
        scorePause.text = ((int)score).ToString();



        if (player.enabled == true)
        {
            score += 1 * Time.deltaTime;
        }
        else
        {
        
            Die();
            scoreText.gameObject.SetActive(false);
        }
    }


    public void Die()
    {
    
        if (score > highScore)
        {
            highScore = score;
            gameData.HighScore = highScore;

            // Lưu dữ liệu mới vào SystemSave
            SystemSave.Save(gameData);
        }
    }
}
