using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _player;

    private Vector3 _tempPos;

    [SerializeField] public float minX, maxX;
    public float minY;
    [SerializeField] public float maxY;

    // Start is called before the first frame update
    private void Start()
    {
        while (!GameObject.FindWithTag("Player"))
        {
            return;
        }

        _player = GameObject.FindWithTag("Player").transform;
    }

    /// <summary>
    /// camera movement based on the player's position.
    /// </summary>
    private void LateUpdate()
    {
        if (!_player)
        {
            _player = GameObject.FindWithTag("Player").transform;
            return;
        }

        _tempPos = transform.position;
        var position = _player.position;
        _tempPos.x = position.x;
        _tempPos.y = position.y;
        if (_tempPos.x < minX)
        {
            _tempPos.x = minX;
        }

        if (_tempPos.x > maxX)
        {
            _tempPos.x = maxX;
        }

        if (_tempPos.y < minY)
        {
            _tempPos.y = minY;
        }

        if (_tempPos.y > maxY)
        {
            _tempPos.y = maxY;
        }

        transform.position = _tempPos;
    }
}