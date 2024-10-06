using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthScripts : MonoBehaviour
{
    [SerializeField]
    int maxHealth;

    int currentHealth;
    public HealthBarScripts healthBar;

    public UnityEvent onDeath;

    // Start is called before the first frame update
    public void onEnable(){
        onDeath.AddListener(Deadth);
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.updateBar(currentHealth, maxHealth);
    }

    public void takeDamage(int damage){
        currentHealth -= damage;
        healthBar.updateBar(currentHealth, maxHealth);
        if(currentHealth <= 0){
            onDeath.Invoke();
        }
    }

    public void Deadth(){
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)){
            takeDamage(30);
        }
    }
}
