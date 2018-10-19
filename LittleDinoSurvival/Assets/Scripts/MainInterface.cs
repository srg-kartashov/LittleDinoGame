using UnityEngine;
using UnityEngine.SceneManagement;

public class MainInterface : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        PlayerPrefs.SetString("Music", "true");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void AudioButton()
    {
        _audioSource.enabled = !_audioSource.enabled;
        PlayerPrefs.SetString("Music", _audioSource.enabled.ToString());
        Debug.Log(PlayerPrefs.GetString("Music"));
    }
    public void StartButton()
    {
        SceneManager.LoadScene("main");

    }



}
