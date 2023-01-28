using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject leftPaddle;
    public GameObject rightPadle;
    public int leftScore;
    public GameObject LeftScoreText; 
    public int rightScore;
    public GameObject RightScoreText; 

    // Start is called before the first frame update
    void Start()
    {
        leftScore = 0;
        rightScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpLeftScore()
    {
        leftScore++;
        LeftScoreText.GetComponent<TextMeshProUGUI>().text = leftScore.ToString();
    }

    public void UpRightScore()
    {
        rightScore++;
        RightScoreText.GetComponent<TextMeshProUGUI>().text = rightScore.ToString();
    }

    public void resetBall()
    {
        ball.transform.position = new Vector3(0,0,0);
        ball.GetComponent<Ball>().speed = 5;
    }

    public void resetPaddles()
    {
        leftPaddle.transform.position = new Vector3(-9,0,0);
        rightPadle.transform.position = new Vector3(9,0,0);
    }  

    public void resetGame()
    {
        resetBall();
        resetPaddles();
        leftScore = 0;
        LeftScoreText.GetComponent<TextMeshProUGUI>().text = leftScore.ToString();
        rightScore = 0;
        RightScoreText.GetComponent<TextMeshProUGUI>().text = rightScore.ToString();

    }  
}
