using UnityEngine;
using System.Collections;

public class SnakeBodyInfo : MonoBehaviour
{
    private Vector3 _lastPosition;
    public Vector3 LastPosition
    {
        get { return _lastPosition; }
    }

    private Quaternion _lastRotation;
    public Quaternion LastRotation
    {
        get { return _lastRotation; }
    }

    public int bodyIndex;

    SnakeBodyInfo info;

    // Use this for initialization
    void Start()
    {
        //SnakeMove._instance.bodyInfos.Add(this);
        //bodyIndex = SnakeMove._instance.bodyInfos.Count;
        //SnakeMove._instance.isTimeToMove += IsTimeToMove;

        if (bodyIndex == 0)
        {
            _lastPosition = transform.position;
            _lastRotation = transform.rotation;
            return;
        }
        info = Snake._instance.bodyInfos[bodyIndex - 1];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SnakeHeadChange()
    {
        _lastPosition = transform.position;
        _lastRotation = transform.rotation;
    }

    public void IsTimeToMove()
    {
        //Debug.Log(bodyIndex);
        if (bodyIndex == 0)
        {
            return;
        }
        _lastPosition = transform.position;
        _lastRotation = transform.rotation;
        MoveSnakeBody();
    }

    void MoveSnakeBody()
    {
        transform.position = info.LastPosition;
        transform.rotation = info.LastRotation;
    }

    void OnDestroy()
    {
        Snake._instance.bodyInfos.Remove(this);
    }
}
