﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        int score = PlayerPrefs.GetInt("score");
        FindObjectOfType<FinalScore>().SetFinalScore(score);
    }
}