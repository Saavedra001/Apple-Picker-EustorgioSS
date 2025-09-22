using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    public Text uiText;
    public ScoreCounter scoreCounter;    // drag your ScoreCounter here (or it will find it)
    public int pointsPerRound = 500;     // change to taste
    public int maxRounds = 4;

    public static int CURRENT_ROUND = 1;

    void Start()
    {
        if (!uiText) uiText = GetComponent<Text>();
        if (!scoreCounter)
        {
            var go = GameObject.Find("ScoreCounter");
            if (go) scoreCounter = go.GetComponent<ScoreCounter>();
        }
        UpdateLabel(1);
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (!scoreCounter) return;

        int round = Mathf.Clamp(1 + (scoreCounter.score / pointsPerRound), 1, maxRounds);

        if (round != CURRENT_ROUND)
        {
            CURRENT_ROUND = round;
            UpdateLabel(round);

        }
        else
        {
            UpdateLabel(round);

        }

    }

    void UpdateLabel(int round)
    {
        if (uiText) uiText.text = "Round " + round;
    }
}
