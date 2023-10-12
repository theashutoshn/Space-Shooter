using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    // handle to Text
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private Image _livesImg;

    [SerializeField]
    private Sprite[] _livesSprite;

    [SerializeField]
    private TextMeshProUGUI _gameOverText;

    private float _flickerRate = 0.2f;

    [SerializeField]
    private TextMeshProUGUI _restartText;

    private GameManager _gameManager;

    

    


    void Start()
    {
        // assign text compnent to handle
        _scoreText.text = "Score: " + 0;
        
        _gameOverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        

        if(_gameManager == null)
        {
            Debug.LogError("Game Manager is NULL.");
        }
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

       

    

    public void UpdateLives(int currentLives)
    {
        // access the display image spirte
        // give it a new one based on the currentLives INdex
        _livesImg.sprite = _livesSprite[currentLives];

        if (currentLives == 0)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
        _gameManager.GameOver();
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.enabled = !_gameOverText.enabled;
            yield return new WaitForSeconds(_flickerRate);
        }
        
    }

   
    
}
