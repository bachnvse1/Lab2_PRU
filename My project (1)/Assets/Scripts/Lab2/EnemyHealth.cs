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
    public int currentHealth;

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
        valueText.text = "HP Enemy_" + enemy + ": " + currentHealth.ToString() + " / " + maxHealth.ToString();
        if (currentHealth <= 0)
        {
            valueText.text = "HP Enemy_" + enemy + ": " + 0 + " / " + maxHealth.ToString();
        }
    }
}
