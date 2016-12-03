using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeMove : MonoBehaviour
{

    public static SnakeMove _instance;

    //public GameObject snakeBody;
    public float moveSpeed = 0.2f;
    public float moveInterval = 1f;
    //public List<SnakeBodyInfo> bodyInfos = new List<SnakeBodyInfo>(); 
    //public SnakeBodyInfo[] bodyInfos;

    private float timeCount = 0;
    private Vector3 moveDic;

    public bool canMove = true;

    //public delegate void IsTimeToMove();
    //public IsTimeToMove isTimeToMove;

    public enum Dirction
    {
        forward = 0,
        back = 1,
        left = 2,
        right = 3
    }

    public Dirction dic = Dirction.forward;

    //Use this for initialization

    void Awake()
    {
        _instance = this;

        moveDic = new Vector3(0, 0, moveSpeed);
    }

    void Start()
    {

    }

    //Update is called once per frame

    void Update()
    {
        ReciveInput();

        if (timeCount >= moveInterval)
        {
            timeCount = 0;
            MoveSnake();
        }
        else
        {
            timeCount += Time.deltaTime;
        }
    }

    private void MoveSnake()
    {
        Snake._instance.bodyInfos[0].SnakeHeadChange();
        transform.position += moveDic;
        
        Snake._instance.SnakeBodyBeginMove();

        canMove = true;
    }

    void ReciveInput()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.A) && dic != Dirction.right && dic != Dirction.left)
            {
                transform.rotation = Quaternion.Euler(0, 270, 0);
                moveDic.x = -moveSpeed;
                moveDic.z = 0;
                dic = Dirction.left;
                ChangeCanMove();
            }
            if (Input.GetKeyDown(KeyCode.D) && dic != Dirction.left && dic != Dirction.right)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                moveDic.x = moveSpeed;
                moveDic.z = 0;
                dic = Dirction.right;
                ChangeCanMove();
            }
            if (Input.GetKeyDown(KeyCode.W) && dic != Dirction.back && dic != Dirction.forward)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                moveDic.x = 0;
                moveDic.z = moveSpeed;
                dic = Dirction.forward;
                ChangeCanMove();
            }
            if (Input.GetKeyDown(KeyCode.S) && dic != Dirction.forward && dic != Dirction.back)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                moveDic.x = 0;
                moveDic.z = -moveSpeed;
                dic = Dirction.back;
                ChangeCanMove();
            }
        }
    }

    void ChangeCanMove()
    {
        canMove = !canMove;
    }
}
