using UnityEngine;
using UnityEngine.Serialization;

public class EnemyAI : MonoBehaviour
{
    [HideInInspector] public bool mustPatrol;

    [FormerlySerializedAs("WalkSpeed")] public float walkSpeed;

    private bool _mustFlip;

    public Transform groundCheckPos;
    public Rigidbody2D rb;

    public Collider2D bodyCollider;

    public LayerMask groundLayer;

    public LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            _mustFlip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    /// <summary>
    /// Check for edges and flip enemy
    /// </summary>
    private void Patrol()
    {
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
        if (_mustFlip || bodyCollider.IsTouchingLayers(wallLayer))
        {
            Flip();
        }
    }

    /// <summary>
    /// Flip enemy on y axis
    /// </summary>
    private void Flip()
    {
        mustPatrol = false;
        var transform1 = transform;
        var localScale = transform1.localScale;
        localScale = new Vector2(localScale.x * -1, localScale.y);
        transform1.localScale = localScale;
        walkSpeed *= -1;
        mustPatrol = true;
    }
}