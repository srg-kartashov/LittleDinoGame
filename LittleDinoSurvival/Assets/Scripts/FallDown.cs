using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class FallDown : MonoBehaviour
{

    [SerializeField]
    private float _fallSpeed;

    private Animator _animator;
    private CircleCollider2D _circleCollider2;
    public AudioClip ExplosionClip;
    private AudioSource _audioSource;
   



    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _circleCollider2 = GetComponent<CircleCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _fallSpeed = Random.Range(4f, 6f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, _fallSpeed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion()
    {
        SaveLoadManager.Instance.IncreaseScore();
        _circleCollider2.enabled = false;
        _audioSource.pitch = Random.Range(0.7f, 1f);
        _audioSource.PlayOneShot(ExplosionClip);
        _fallSpeed = 0;
        _animator.SetInteger("State", 1);
        yield return new WaitForSeconds(0.9f);
        Destroy(gameObject);
    }
}
