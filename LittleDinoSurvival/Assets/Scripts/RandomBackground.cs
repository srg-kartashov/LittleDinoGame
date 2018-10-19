using UnityEngine;

public class RandomBackground : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Background/background" + Random.Range(1, 6));
    }


}
