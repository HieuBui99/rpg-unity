using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public bool isPaused = false;


    public Transform playerPrefab;
    public Transform respawnPoint;
    public float respawnDelay = 2f;

    [SerializeField]
    Player player;
    float playerMaxHealth;
    float playerCurrentHealth;
    public Image healthBar;

    public GameObject pauseMenu;
    public GameObject victoryScreen;
    public GameObject gameOverScreen;

    public Text coinText;
    int coin;

    int remainingLives = 3;
    public Text livesText;

    int nextLevel;
    void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        playerMaxHealth = Player.maxHealth;
        playerCurrentHealth = player.currentHealth;
        coin = GoldManager.GetGold();
        coinText.text = coin.ToString();
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void Update()
    {
        try
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                return;
            }
            UpdateHealthBar();
            livesText.text = "Lives: " + remainingLives.ToString(); 
            if (player.GetComponentInParent<Transform>().position.y < -5)
            {
                StartCoroutine(player.TakeDamage(999999));
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
        catch { };
       
    }

    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnDelay);
        Instantiate(playerPrefab, respawnPoint.position, respawnPoint.rotation);
    }
    public void KillPlayer(Player player)
    {
        remainingLives--;
        Destroy(player.gameObject);
        if (remainingLives <=0)
        {
            GameOver();
        }
        else StartCoroutine(gm.RespawnPlayer());

    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartLevel()
    {
        if (isPaused) ResumeGame();     
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadVictoryScreen()
    {
        victoryScreen.SetActive(true);
        GoldManager.SaveGold(coin);
        PlayerPrefs.SetInt("Current Level", nextLevel);
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
    void UpdateHealthBar()
    {
        try
        {
            if (player != null)
            {
                playerCurrentHealth = Mathf.Clamp(player.currentHealth, 0, playerMaxHealth);
                healthBar.fillAmount = playerCurrentHealth / playerMaxHealth;
            }
            else
            {
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                playerMaxHealth = Player.maxHealth;
                playerCurrentHealth = player.currentHealth;
            }
        }
        catch { }


    }

    public void CollectCoin(int amount)
    {
        coin += amount;
        coinText.text = coin.ToString();
    }

}
