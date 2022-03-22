using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private double _startpos, _length;
    private float _y;

    public new GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        var position = transform.position;
        _startpos = position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
        _y = position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var position = camera.transform.position;
        var temp = (position.x * 0.9);
        var dist = (position.x * 0.1);
        var transform1 = transform;
        transform1.position = new Vector3((float) (_startpos + dist), _y, transform1.position.z);
        if (temp > _startpos + _length) _startpos += _length;
        else if (temp < _startpos - _length) _startpos -= _length;
    }
}