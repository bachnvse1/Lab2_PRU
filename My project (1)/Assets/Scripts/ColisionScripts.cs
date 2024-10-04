using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LeftEnemy")
            Destroy(GameObject.FindWithTag("Player"));
        if (collision.gameObject.tag == "RightEnemy" || collision.gameObject.tag == "TopEnemy")
        {
            // Get the parent object of the collision (the enemy object)
            GameObject enemy = collision.gameObject.transform.parent.gameObject;

            // Set the enemy object (the parent) inactive
            enemy.SetActive(false);

            // Optional: Log the name of the enemy being deactivated for debugging
            Debug.Log("Enemy " + enemy.name + " was deactivated.");
        }
            
    }
}


