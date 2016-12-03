using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        Snake._instance.Longer();
        FoodController._instance.CreateFood();
        Destroy(gameObject);
    }
}
