using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveScripts : MonoBehaviour
{
    [SerializeField]
    private int direction = 1;
    public float speed = 2f; //
    public float minX = 0.67f;
    public float maxX = 9.13f;
    
    // Start is called before the first frame update
    void Start()
    {
        /*Camera cam = Camera.main;
        float screenHalfWidthInWorldUnits = cam.aspect * cam.orthographicSize;

        minX = -screenHalfWidthInWorldUnits; 
        maxX = screenHalfWidthInWorldUnits; */
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        position.x += direction * speed * Time.deltaTime;

        if(position.x >= maxX || position.x <= minX)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
            direction *= -1;
        }
        transform.position = position;
    }

        
}
