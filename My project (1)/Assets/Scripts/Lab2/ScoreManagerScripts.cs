using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManagerScripts : MonoBehaviour
{
    public static ScoreManagerScripts instance;

    private int score;
    public TextMeshProUGUI scoreText; // Kết nối với UI để hiển thị điểm số

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreUI(); // Cập nhật UI
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
