using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScripts : MonoBehaviour
{
    public GameObject restartGame;
    public GameObject continueGame;
    // Start is called before the first frame update
    void Start()
    {
        restartGame.SetActive(false);
        continueGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R");
            restartGame.SetActive(true);
            continueGame.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        restartGame.SetActive(false);
        continueGame.SetActive(false);
    }
}
