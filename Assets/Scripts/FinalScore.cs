using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    private Text text;
    private int finalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Game Over \n Score : " + finalScore;
    }

    public void SetFinalScore(int score)
    {
        finalScore = score;
    }
}
