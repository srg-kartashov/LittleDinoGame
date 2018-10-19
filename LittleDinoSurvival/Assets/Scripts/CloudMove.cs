using UnityEngine;

public class CloudMove : MonoBehaviour
{


    public float Speed;

    void Update()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
        if (gameObject.transform.position.x > 6f)
            Destroy(gameObject);
    }

    void OnMouseDown()
    {
        Speed *= 1.5f;

    }

   
}

