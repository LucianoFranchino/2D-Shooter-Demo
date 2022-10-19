using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText;
    public float scoreNuber;
    public float scoreSuma;


    // Start is called before the first frame update
    void Start()
    {
        scoreNuber = 0f;
        scoreSuma = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + (int)scoreNuber;
        scoreNuber += scoreSuma * Time.deltaTime;
    }
}
