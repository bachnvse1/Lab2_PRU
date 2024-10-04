using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScripts : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float forceX = 1;
    [SerializeField]
    float forceY = 1;
    bool isColliding = false;
    Rigidbody2D rigid;
    private float screenLimitX;
    private float screenLimitY;
    GameObject prefab;
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        screenLimitX = Camera.main.orthographicSize * Camera.main.aspect;
        screenLimitY = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        // Kiểm tra nếu nhân vật chạm vào biên độ màn hình và điều chỉnh vị trí
        if (position.x > screenLimitX)
        {
            position.x = screenLimitX;
            rigid.velocity = new Vector2(0, rigid.velocity.y); // Dừng chuyển động theo chiều ngang
        }
        else if (position.x < -screenLimitX)
        {
            position.x = -screenLimitX;
            rigid.velocity = new Vector2(0, rigid.velocity.y); // Dừng chuyển động theo chiều ngang
        }

        if (position.y > screenLimitY)
        {
            position.y = screenLimitY;
            rigid.velocity = new Vector2(rigid.velocity.x, 0); // Dừng chuyển động theo chiều dọc
        }
        else if (position.y < -screenLimitY)
        {
            position.y = -screenLimitY;
            rigid.velocity = new Vector2(rigid.velocity.x, 0); // Dừng chuyển động theo chiều dọc
        }

        // Cập nhật vị trí của nhân vật
        transform.position = position;

        // Thêm lực di chuyển nếu không chạm vào biên độ
        if (position.x >= -screenLimitX && position.x <= screenLimitX)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rigid.AddForce(Vector2.right * forceX);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                rigid.AddForce(Vector2.left * forceX);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (position.y >= -screenLimitY && position.y <= screenLimitY)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rigid.AddForce(Vector2.up * forceX);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

   /* void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bat dau va cham");

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Ket thuc va cham");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Dang va cham");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger vao: " + collision.gameObject.name);
    }*/
}
