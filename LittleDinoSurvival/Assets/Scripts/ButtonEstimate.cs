using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEstimate : MonoBehaviour {

    public void ClickButtonEstimate()
    {
        Application.OpenURL("market://details?id=" + Application.identifier);
    }
}
