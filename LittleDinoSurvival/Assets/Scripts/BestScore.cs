using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{

    public Text Best;
	void Start () {
	    if (PlayerPrefs.HasKey("BestScore"))
	    {
	        Best.text = "BEST: " + PlayerPrefs.GetInt("BestScore").ToString();
	    }
	}
}
