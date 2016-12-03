using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CheckSelf : MonoBehaviour
{

    private bool gameOver = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ZhangAi")
        {
            //死亡
            Debug.Log("GameOver");
            gameOver = true;
            Time.timeScale = 0;
        }
    }

    void OnGUI()
    {
        if (gameOver)
        {
            GUI.Label(new Rect(400, 100, 200, 100), "GameOver");

            if (GUI.Button(new Rect(400, 300, 100, 100), "Repeat"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
            }
        }

    }
}
