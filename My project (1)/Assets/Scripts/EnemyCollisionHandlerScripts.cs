using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandlerScripts : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
            Debug.Log("Ignoring collision with: " + collision.gameObject.name);
        }
    }
}
