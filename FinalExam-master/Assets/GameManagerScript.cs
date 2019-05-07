using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    static public string playerName;
    static public int totalScore;
    static public bool giantMode;
    static public float speed;

    public InputField input;
    public Text currentStats;
    public Slider speedSlider;

    private void Start()
    {
        currentGameStats();
    }

    public void loadIntroScene()
    {
        SceneManager.LoadScene(0);
    }

    public void loadHighScoresScene()
    {
        SceneManager.LoadScene(1);
    }

    public void loadGameScene()
    {
        SceneManager.LoadScene(2);
    }

    public void loadExitScene()
    {
        totalScore = ScoreKeeper.newScore * LivesTracker.lives;
        //ScoreManagerScript.WriteScore();
        //Thread.Sleep(1000);
        SceneManager.LoadScene(3);
    }

    public void UpdatePlayerName()
    {
        playerName = input.text;
    }

    public void currentGameStats()
    {
        string text;
        text = "Player Name: " + playerName + "\nLives Left: " + LivesTracker.lives.ToString() + "\nPoints Earned: " + ScoreKeeper.newScore.ToString() + "\nTotal Score: " + totalScore.ToString();
        currentStats.text = text;
    }

    public void Toggled()
    {
        if(giantMode == true)
        {
            giantMode = false;
        }
        else
        {
            giantMode = true;
        }
    }
    public void UpdateSpeed()
    {
        speed = speedSlider.value;
    }
}
