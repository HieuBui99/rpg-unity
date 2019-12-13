using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static bool isPaused = false;


    public Transform playerPrefab;
    public Transform respawnPoint;
    public float respawnDelay = 2f;

    public GameObject pauseMenu;
    public GameObject victoryScreen;
    void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        }
    }

    void Update()
    {
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

    public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnDelay);
        Instantiate(playerPrefab, respawnPoint.position, respawnPoint.rotation);
    }
    public void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        StartCoroutine(gm.RespawnPlayer());
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
        Debug.Log("Restarting");
    }

    public void LoadVictoryScreen()
    {
        victoryScreen.SetActive(true);
    }
}
