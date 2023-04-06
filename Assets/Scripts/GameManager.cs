using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public Text hiScoreText;
    public Text labelText;
    public GameObject playButton;
    public GameObject muteButtons;
    public GameObject gameOver;
    public GameObject getReady;
    public AudioSource scoreSound;
    public AudioSource gameOverSound;
    public AudioSource playSound;
    public AudioSource bgMusic;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
        UpdateHiscore();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playSound.Play();
        playButton.SetActive(false);
        muteButtons.SetActive(false);
        hiScoreText.gameObject.SetActive(false);
        labelText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        bgMusic.UnPause();

        if (gameOver.activeSelf)
        {
            gameOver.SetActive(false);
        }
        else
        {
            getReady.SetActive(false);
        }       

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        hiScoreText.gameObject.SetActive(true);
        labelText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        bgMusic.Pause();
        gameOverSound.Play();
        Pause();
        UpdateHiscore();
    }
    public void IncreaseScore()
    {
        score ++;
        scoreSound.Play();
        scoreText.text = score.ToString();
    }

    private void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiScoreText.text = Mathf.FloorToInt(hiscore).ToString();
    }
}
