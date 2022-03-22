using UnityEngine;

public class Stomper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        Destroy(other.gameObject);
        transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 22), ForceMode2D.Impulse);
    }
}