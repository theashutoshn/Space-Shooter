using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
   

    // Start is called before the first frame update

    [SerializeField]
    private bool _isGameOver;

    [SerializeField]
    private GameObject _pauseMenuPanel;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            
            SceneManager.LoadScene(1);
        }

        // if ESC key is  pressed the quit the application

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        PauseMenu();

    }

    public void GameOver()
    {
        _isGameOver = true;
        
    }

    public void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _pauseMenuPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _pauseMenuPanel.SetActive(false);
    }

   
}
