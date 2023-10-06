using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    void Start()
    {
        // assign text compnent to handle
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
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
            _gameOverText.gameObject.SetActive(true);
        }
    }

    
}
