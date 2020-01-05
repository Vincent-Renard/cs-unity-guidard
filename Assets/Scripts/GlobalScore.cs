using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScore : MonoBehaviour
{
    private int score;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score : " + score;
    }

    public void AddScore(int points)
    {
        score += points;
    }
}
