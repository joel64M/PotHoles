using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public  class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    public TextMeshProUGUI scoreTxt;

    int score = 0;

    private void Awake()
    {
        instance = this;
    }
    public  void IncrementScore()
    {
        score++;
        scoreTxt.text ="Potholes filled : " + score.ToString();
    }
}
