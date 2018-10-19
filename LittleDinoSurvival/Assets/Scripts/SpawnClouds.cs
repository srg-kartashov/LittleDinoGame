using System.Collections;
using UnityEngine;

public class SpawnClouds : MonoBehaviour {

    public GameObject []  Clouds;
    public void Start()
    {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(Clouds[Random.Range(0,Clouds.Length)], new Vector2(-5.5f, Random.Range(0f, 2f)), Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
    }
}
