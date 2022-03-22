using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;

    [SerializeField] private float jumpForce = 11f;

    private float _movementX;

    private Rigidbody2D _myBody;

    private bool _isGrounded;


    private GameObject[] _players;

    private Animator _anim;

    private bool _isFlpped = false;

    private Vector3 _spawnPoint;

    private Vector3 _voidPoint;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _anim = GetComponent<Animator>();
        _spawnPoint = GameObject.FindWithTag("startPos").transform.position;
        _voidPoint = GameObject.FindWithTag("voidPoint").transform.position;
    }

    private void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        PlayerMoveKeyboard();
        PlayerJump();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            _anim.SetBool("isRunning", true);
        }
        else
        {
            _anim.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !_isFlpped)
        {
            Flip();
        }

        if (Input.GetKey(KeyCode.RightArrow) && _isFlpped)
        {
            Flip();
        }

        if (transform.position.y <= _voidPoint.y)
        {
            Respawn();
        }
    }

    /// <summary>
    /// Check for move keyboards
    /// </summary>
    private void PlayerMoveKeyboard()
    {
        _movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(_movementX, 0f, 0f) * (moveForce * Time.deltaTime);
    }

    /// <summary>
    /// Player jump on Jump keyboard trigger
    /// </summary>
    private void PlayerJump()
    {
        if (Input.GetButton("Jump") && _isGrounded)
        {
            _isGrounded = false;
            _myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            _anim.SetBool("Jump", true);
        }
        else
        {
            _anim.SetBool("Jump", false);
        }
    }

    /// <summary>
    /// Detect collision with other objects
    /// </summary>
    /// <param name="collision">object</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Respawn();
        }
    }

    /// <summary>
    /// Remove players if more exist
    /// </summary>
    /// <param name="level"></param>
    private void OnLevelWasLoaded(int level)
    {
        FindStartPos();

        _players = GameObject.FindGameObjectsWithTag("Player");

        if (_players.Length > 1)
        {
            Destroy(_players[1]);
        }
    }

    /// <summary>
    /// Flip player
    /// </summary>
    private void Flip()
    {
        var transform1 = transform;
        var localScale = transform1.localScale;
        localScale = new Vector2(localScale.x * -1, localScale.y);
        transform1.localScale = localScale;
        _isFlpped = !_isFlpped;
    }

    /// <summary>
    /// Set player to start pos
    /// </summary>
    private void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("startPos").transform.position;
    }

    /// <summary>
    /// Respawn player
    /// </summary>
    private void Respawn()
    {
        transform.position = _spawnPoint;
    }
}