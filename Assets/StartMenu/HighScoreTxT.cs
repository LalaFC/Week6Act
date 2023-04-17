using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreTxT : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI Score;
    public GameObject Ship;
    public GameObject ScoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("PlayerScore");

        if (score != 0)
        {
            Ship.SetActive(false);
            ScoreBoard.SetActive(true);
        }
        Score.text = PlayerPrefs.GetInt("PlayerScore").ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

}
