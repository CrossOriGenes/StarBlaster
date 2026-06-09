using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score;

    void Start()
    {
        // Time.timeScale = 1f;
        if (scoreText != null)
        {
            score = PlayerPrefs.GetInt("score", 0);
            scoreText.text = "Your Score: "+score;
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUITTING GAME...");
    }

    public void LoadGameOverScene()
    {
        Time.timeScale = 1f;
        print("GAME OVER!!!");
        StartCoroutine(ShowGameOverScene());        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator ShowGameOverScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Game Over Scene");
    }
}
