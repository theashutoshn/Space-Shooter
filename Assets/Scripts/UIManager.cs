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
    void Start()
    {
        // assign text compnent to handle
        _scoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }
}
