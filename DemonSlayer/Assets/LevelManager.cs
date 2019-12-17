using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject levelList;
    //public List<Button> levelButtons;
    Button[] levelButtons;

    public static int levelBuildIndex = 1;
    void Awake()
    {
        int currentLevel = PlayerPrefs.GetInt("Current Level", levelBuildIndex);
        levelButtons = levelList.GetComponentsInChildren<Button>();
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i+levelBuildIndex > currentLevel)
            {
                levelButtons[i].gameObject.SetActive(false);
            }
        }
    }
    public void LevelSelect(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
