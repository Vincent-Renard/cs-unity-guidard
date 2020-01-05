using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalScore : MonoBehaviour
{
    private Text text;
    private PlayingScene settings;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        settings = FindObjectOfType<PlayingScene>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score : " + settings.GetScore();
    }
}
