using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // need this line for UGui to work

public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int _Score = 1000;

    private Text txtCom; //txtCom is a reference to this GO's text component

    void Awake()
    {
        _UI_TEXT = GetComponent<Text>();

        //if the PlayerPrefs HighScore alread exist, read it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }

        //asssign the high score to HighScore
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    static public int SCORE
    {
        get { return _Score; }
        private set
        {
            _Score = value;
            PlayerPrefs.SetInt("HighScore", value);
            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= SCORE) return; // if scoreToTry is too low return
        SCORE = scoreToTry;
    }

    // the following code allows you to easily reset the PlayerPrefs HighScore
    [Tooltip("Check this bos to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos(){
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000.");
        }
    }
}
