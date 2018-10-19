using UnityEngine;

public class ClickScript : MonoBehaviour {

    public bool ClickedIs;
    public void OnClick()
    {
        ClickedIs = true;
    }

    public void OnStopClick()
    {
        ClickedIs = false;
    }
}
