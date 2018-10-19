using UnityEngine;

public class RandomEnviroment : MonoBehaviour
{

  
	void Start ()
	{
	    int n = Random.Range(1, 4);
        Instantiate(Resources.Load("Environment/Environment" + n),gameObject.transform);
	}
}
