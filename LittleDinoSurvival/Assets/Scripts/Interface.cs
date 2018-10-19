using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Text ScoreText;
    public int ScoreValue;
    public GameObject WindowGameOver;
    private void Start()
    {
        ScoreValue = 0;
    }

    public void ClickRestartButton()
    {
        SceneManager.LoadScene("main");
    }

    public void ClickMenuButton()
    {
        SceneManager.LoadScene("menu");
    }

    public void ShowGOWindow()
    {
        WindowGameOver.SetActive(true);
    }
}
