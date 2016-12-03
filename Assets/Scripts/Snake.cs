using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{

    public static Snake _instance;
    public GameObject snakeLastBody;
    public List<SnakeBodyInfo> bodyInfos = new List<SnakeBodyInfo>();

    private int score = 0;

    void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
	void Start ()
	{
	    SnakeBodyInfo[] bodys = transform.GetComponentsInChildren<SnakeBodyInfo>();
	    for (int i = 0; i < bodys.Length; i++)
	    {
	        bodyInfos.Add(bodys[i]);
	        bodyInfos[i].bodyIndex = i;
	    }
	}

    public void SnakeBodyBeginMove()
    {
        for (int i = 0; i < bodyInfos.Count; i++)
        {
            bodyInfos[i].IsTimeToMove();
        }
    }

    // Update is called once per frame
	void Update () {
	
	}

    public void Longer()
    {
        GameObject go = Instantiate(snakeLastBody);
        go.transform.SetParent(gameObject.transform,false);
        go.GetComponent<SnakeBodyInfo>().bodyIndex = bodyInfos.Count;
        bodyInfos.Add(go.GetComponent<SnakeBodyInfo>());
        go.transform.localPosition = bodyInfos[bodyInfos.Count - 2].LastPosition;
        go.transform.rotation = bodyInfos[bodyInfos.Count - 2].LastRotation;
        go.transform.localScale = Vector3.one;

        score += 10;
    }

    void OnGUI()
    {
        GUILayout.Label("分数:" + score);
    }
}
