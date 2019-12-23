using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class MainMenuManager : MonoBehaviour
{
    public GameObject levelSelectButton;
    public GameObject title;
    public GameObject mainPanel;
    public GameObject newGamePrompt;
    int currentLevel;
    void Awake()
    {
        currentLevel = PlayerPrefs.GetInt("Current Level", LevelManager.levelBuildIndex);
        if  (currentLevel != LevelManager.levelBuildIndex)
        {
            levelSelectButton.SetActive(true);
        }
    }
    public void NewGame()
    {
        if (currentLevel == LevelManager.levelBuildIndex)
        {
            SceneManager.LoadScene("LevelSelect");
        }
        else
        {
            title.SetActive(false);
            mainPanel.SetActive(false);
            newGamePrompt.SetActive(true);
        }
    }
    public void ResetPlayerPref()
    {
        File.Delete(Application.persistentDataPath + "/shop.dat");
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("LevelSelect");
  
    }
    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT"); 
        Application.Quit();
    }
}
