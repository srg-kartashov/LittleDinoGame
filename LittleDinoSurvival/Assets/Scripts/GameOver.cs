using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public Text Score;
    public Text BestScore;
    public GameObject New;
    private void Start()
    {
        Score.text = SaveLoadManager.Instance.Score.ToString();
        BestScore.text = SaveLoadManager.Instance.BestScore.ToString();
        if (SaveLoadManager.Instance.NewBest)
        {
            New.SetActive(true);
        }
    }

}
