using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int enemy;
    [SerializeField]
    int maxHealth = 50; // Máu tối đa của quái
    [SerializeField]
    public int damage = 5;      // Sát thương của quái
    [SerializeField]
    public double rate = 0.8;   // Tỷ lệ tấn công hoặc thuộc tính liên quan của quái
    [SerializeField]
    public int score = 5;       // Điểm số khi tiêu diệt quái
    [SerializeField]
    public TextMeshProUGUI valueText;
    int currentHealth;
    ScoreManagerScripts ScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // Gán máu hiện tại bằng máu tối đa
        valueText.text = "HP Enemy_" + enemy + ": " + currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    // Gọi hàm này khi quái bị tấn công
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Kiểm tra nếu máu <= 0 thì quái chết
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Hàm xử lý khi quái chết
    void Die()
    {
        // Xử lý việc cộng điểm
        AddScore(score); // Gọi hàm để cộng điểm

        // Xoá hoặc vô hiệu hóa quái
        Destroy(gameObject);

        // Optional: Log for debugging
        Debug.Log(gameObject.name + " was destroyed and gave " + score + " points.");
    }

    // Hàm cộng điểm, có thể thay đổi tùy vào hệ thống điểm số của bạn
    void AddScore(int points)
    {
        // Ở đây bạn có thể gọi tới hệ thống điểm số toàn cục, ví dụ:
        ScoreManager.AddPoints(points); // Giả sử bạn có một ScoreManager để quản lý điểm
    }
}
