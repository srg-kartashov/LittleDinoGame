using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ClickScript[] Control;
    public AudioClip Heart;
    public Sprite[] Health;
    public Image UIHealth;




    private Interface _interface;
    private SpawnFireballs _spawnFireballs;
    private Animator _animator;
    private AudioSource _audio;
    private int _lives = 3;
    private bool _faceRight = true;
    private float _maxCameraX, _minCameraX;
    private float _rotation = 1;
    private readonly float speed = 3.0f;


    //private SpriteRenderer _sprite;
    //public AudioClip step;
    ////public static int score;
    //private Rigidbody2D _rigidbody;

    private void Start()
    {
      
        Control[0] = GameObject.Find("Left").GetComponent<ClickScript>();
        Control[1] = GameObject.Find("Right").GetComponent<ClickScript>();
        UIHealth = GameObject.Find("HealthBar").GetComponent<Image>();
        _audio = GetComponent<AudioSource>();
        _minCameraX = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x + 0.3f;
        _maxCameraX = -_minCameraX;
        _spawnFireballs = GameObject.Find("GameManager").GetComponent<SpawnFireballs>();
        _interface = GameObject.Find("Interface").GetComponent<Interface>();
    
    }

    private CharState State
    {
        //get { return (CharState)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }
    }
    private void Awake()
    {
        //_rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        //_sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (_lives > 0)
        {
            State = CharState.Idle;
            //if (Input.GetButton("Horizontal")) Run();
            if (Control[0].ClickedIs || Control[1].ClickedIs) Run();

        }
    }


    //IEnumerator Steps()
    //{
    //    audio.PlayOneShot(step);
    //    yield return new WaitForSeconds(1);
    //}

    private void Run()
    {
        State = CharState.Run;

        if (Control[0].ClickedIs)
        {
            _rotation = -1;
        }
        if (Control[1].ClickedIs)
        {
            _rotation = 1;
        }
        Vector3 direction = transform.right * _rotation;

        Vector3 v = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        if (v.x <= _maxCameraX && v.x >= _minCameraX)
            transform.position = v;

        //поворот
        if (_rotation > 0 && !_faceRight)
        {
            Flip();
        }
        else if (_rotation < 0 && _faceRight)
        {
            Flip();
        }

    }
    //поворот
    void Flip()
    {
        _faceRight = !_faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            _audio.PlayOneShot(Heart);
            if (_lives > 0)
                _lives -= 1;
            UIHealth.sprite = Health[_lives];

            //Death
            if (_lives <= 0)
            {
                State = CharState.Die;
                SaveLoadManager.Instance.IsAlive = false;
                _spawnFireballs.StopAllCoroutines();
                _spawnFireballs.enabled = false;
                Control[0].gameObject.SetActive(false);
                Control[1].gameObject.SetActive(false);
                _audio.mute = true;
                SaveLoadManager.Instance.SaveScore();
                
                _interface.ShowGOWindow();
                

            }

        }
    }

    //public void Continue()
    //{
    //    State = CharState.Idle;
    //    SaveLoadManager.Instance.IsAlive = true;
        
    //    _spawnFireballs.enabled = true;
    //    _spawnFireballs.Start();
    //    Control[0].gameObject.SetActive(true);
    //    Control[1].gameObject.SetActive(true);
    //    _audio.mute = false;
    //    _lives = 3;
    //    UIHealth.sprite = Health[_lives];
    //    //_interface.ShowGOWindow();
    //}

}

public enum CharState
{
    Idle,
    Run,
    Die
}