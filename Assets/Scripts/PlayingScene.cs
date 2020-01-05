using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingScene : MonoBehaviour
{
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int points)
    {
        score += points;
    }

    public int GetScore()
    {
        return score;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("score", score);
    }
}
