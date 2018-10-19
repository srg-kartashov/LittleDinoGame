using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour {

    private static int _advCount = 0;

    void Start()
    {
        Advertisement.Initialize("2821133", false);
    }

    public void Show()
    {
        _advCount++;
        Debug.Log(_advCount);
        if (Advertisement.IsReady("video") && (_advCount % 4 == 0 || _advCount == 1))
        {
            Advertisement.Show("video");
        }
    }
}
