using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionScripts : MonoBehaviour
{
    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.tag == "LeftEnemy")
        {
            Destroy(GameObject.FindWithTag("Player"));
            Debug.Log("Player was destroyed.");
        }

        if (collision.gameObject.tag == "RightEnemy" || collision.gameObject.tag == "TopEnemy")
        {
            // Kiểm tra nếu đối tượng có cha
            Transform parentTransform = collision.gameObject.transform.parent;
            if (parentTransform != null)
            {
                GameObject enemy = parentTransform.gameObject;
                enemy.SetActive(false);
                Debug.Log("Enemy " + enemy.name + " was deactivated.");
            }
            else
            {
                Debug.LogWarning("Collision object has no parent!");
            }
        }
    }*/
    PlayerHealthScripts playerS;

    // Start được gọi khi bắt đầu
    void Start()
    {
        // Tìm đối tượng người chơi bằng cách dùng tag "Player"
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu va chạm với vùng biên
        if (collision.gameObject.tag == "LeftEnemy" || collision.gameObject.tag == "RightEnemy" || collision.gameObject.tag == "TopEnemy")
        {
            // Lấy đối tượng cha của vùng biên (đối tượng enemy thực tế)
            GameObject enemy = collision.gameObject.transform.parent.gameObject;

            // Kiểm tra nếu enemy có tag là "enemy_1" hoặc "enemy_2"
            if (enemy.CompareTag("Enemy") || enemy.CompareTag("Enemy_2"))
            {
                // Lấy component EnemyHealth từ đối tượng enemy thực tế
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

                // Nếu va chạm với enemy_1 (hoặc enemy_2) và có script EnemyHealth
                if (enemyHealth != null)
                {
                    if (playerS != null)
                    {
                        // Gây sát thương cho người chơi dựa trên enemy
                        Debug.Log("Người chơi nhận sát thương: " + enemyHealth.damage);
                        playerS.takeDamage(enemyHealth.damage);
                    }

                    // Vô hiệu hóa đối tượng enemy
                    enemy.SetActive(false);
                    Debug.Log("Enemy " + enemy.name + " đã bị vô hiệu hóa.");
                }
                else
                {
                    Debug.LogError("Không tìm thấy EnemyHealth trên đối tượng va chạm!");
                }
            }
        }
    }

}


