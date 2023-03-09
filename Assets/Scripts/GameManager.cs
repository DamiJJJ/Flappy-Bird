using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    public void GameOver()
    {
        Debug.Log("Game over");
    }
    public void IncreaseScore()
    {
        score ++;
    }
}
