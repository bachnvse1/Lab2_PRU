using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newEnemyMovementScripts : MonoBehaviour
{
    // Update is called once per frame
    public float speed = 5f;
    public float minX = 0.67f;
    public float maxX = 9.13f;

    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 position = transform.position;

        // Di chuyển theo trục X
        position.x += direction * speed * Time.deltaTime;

        // Đổi hướng và lật khi chạm vào giới hạn
        if (position.x >= maxX || position.x <= minX)
        {
            direction *= -1;

            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        transform.position = position;
    }
}
