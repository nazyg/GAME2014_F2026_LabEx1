using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// keeps track of lives and score and shows them on the screen
public class GameManager : MonoBehaviour
{
    // so the enemy can find the game manager easily
    public static GameManager Instance { get; private set; }

    [SerializeField] private int startLives = 3;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text scoreText;

    private int lives;
    private int score;

    void Awake()
    {
        Instance = this;
        lives = startLives;
        score = 0;
        UpdateUI();
    }

    // called when a meteor hits the player
    public void LoseLife()
    {
        lives--;
        UpdateUI();

        // no lives left -> game over, go to the End scene
        if (lives <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    // called when a bullet hits a meteor
    public void AddPoints(int amount)
    {
        score += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
    }
}
