using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int _score = 0;
    private int _lives = 3;
    private bool _isGameOver = false;

    [SerializeField] 
    private TextMeshProUGUI _scoreText;
    [SerializeField] 
    private GameObject _livesHolder;
    [SerializeField] 
    private GameObject _gameOverPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void IncreaseScore()
    {
        if (!_isGameOver)
        {
            _score += 1;
            _scoreText.text = _score.ToString();
        }
    }

    public void DecreaseLives()
    {
        if (_lives > 0)
        {
            _lives -= 1;
            _livesHolder.transform.GetChild(_lives).GetComponent<Image>().enabled = false;
        }

        if (_lives <= 0)
        {
            _isGameOver = true;
            GameOver();
        }
    }

    public void GameOver()
    {
        CandySpawner.Instance.StopAllCoroutines();
        FindObjectOfType<PlayerController>().CanMove = false;
        _gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}