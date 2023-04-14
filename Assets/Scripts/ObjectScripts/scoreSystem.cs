 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreSystem : MonoBehaviour
{
    public int scoreValue;
    public Text score;
    void Start()
    {
        scoreValue = 0;
        score.text = "Score: " + (scoreValue);
        score = GetComponent<Text>();
    }
    void Update()
    {
        score.text = "Score: "+(scoreValue);
    }
    public void asteroid1Score()
    {
        scoreValue += 10;
    }
}
