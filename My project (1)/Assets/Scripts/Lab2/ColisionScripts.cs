using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionScripts : MonoBehaviour
{
    PlayerHealthScripts playerS;
    ScoreManagerScripts scoreManagerScripts;  // This is the class-level scoreManagerScripts
    // Start is called at the beginning
    void Start()
    {
        scoreManagerScripts = FindObjectOfType<ScoreManagerScripts>(); // Find the existing ScoreManagerScripts object
        if (scoreManagerScripts == null)
        {
            Debug.LogError("Không tìm thấy ScoreManagerScripts!");
        }

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerS = player.GetComponent<PlayerHealthScripts>();
            if (playerS == null)
            {
                Debug.LogError("Không tìm thấy PlayerHealthScripts trên đối tượng Player!");
            }
        }
    }

    private GameObject enemy;
    private bool canAttack = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RightEnemy")
        {
            enemy = collision.gameObject.transform.parent.gameObject;

            if (enemy.CompareTag("Enemy") || enemy.CompareTag("Enemy_2"))
            {
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                    canAttack = true;
                else
                    Debug.LogError("Không tìm thấy EnemyHealth");
            }
        }

        if (collision.gameObject.CompareTag("LeftEnemy"))
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
                playerS.takeDamage(enemyHealth.damage);
        }
    }

    private void Update()
    {
        if (canAttack && Input.GetKeyDown(KeyCode.K))
        {
            if (enemy != null)
            {
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    Debug.Log("Tấn công enemy với 20 damage");
                    enemyHealth.TakeDamage(20);

                    if (enemyHealth.currentHealth <= 0)
                    {
                        enemy.SetActive(false);
                        Debug.Log("Enemy đã bị hạ gục");
                        scoreManagerScripts.AddPoints(enemyHealth.score);
                    }
                }
            }
        }
    }
}
