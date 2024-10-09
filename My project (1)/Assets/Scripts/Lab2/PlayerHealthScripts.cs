using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthScripts : MonoBehaviour
{
    [SerializeField]
    int maxHealth;
    public int currentHealth;
    public HealthBarScripts healthBar;
    public UnityEvent onDeath;
    public GameObject endGamePanel;
    public GameObject restartGame;

    // Start is called before the first frame update
    public void onEnable(){
        onDeath.AddListener(Deadth);
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.updateBar(currentHealth, maxHealth);
        endGamePanel.SetActive(false);
    }

    public void takeDamage(int damage){
        currentHealth -= damage;
        healthBar.updateBar(currentHealth, maxHealth);
        if (currentHealth <= 0){
            onDeath.Invoke();
            healthBar.valueText.text = "";
        }
    }

    public void Deadth(){
        Destroy(gameObject);
        endGamePanel.SetActive(true);
        Time.timeScale = 0f;
        restartGame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.D)){
            takeDamage(30);
        }*/
    }
}
