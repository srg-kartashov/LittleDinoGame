using System.Collections;
using UnityEngine;

public class SpawnFireballs : MonoBehaviour
{
    public GameObject Fireball;
    
    [SerializeField] private float _speedSpawn = 1f;
    private float _maxX, _minX;

    public void Start()
    {
        _minX = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x + 0.3f;
        _maxX = -_minX;
        StartCoroutine(Spawn());
    }

 

IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(Fireball, new Vector2(Random.Range(_minX, _maxX), 6f), Quaternion.identity);
            yield return new WaitForSeconds(_speedSpawn);
            if (_speedSpawn > 0.7)
                _speedSpawn -= 0.01f;
        }
        // ReSharper disable once IteratorNeverReturns
    }

}
