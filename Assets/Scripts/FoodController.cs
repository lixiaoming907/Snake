using UnityEngine;
using System.Collections;

public class FoodController : MonoBehaviour
{

    public static FoodController _instance;

    public GameObject foodPrefab;

    private Vector3 foodPos;
    private Vector4 clampVector = new Vector4(-10, 10, 4, -4);

    void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start()
    {
        CreateFood();
    }

    public void CreateFood()
    {
        int x = (int)Random.Range(clampVector.x, clampVector.y);
        int z = (int)Random.Range(clampVector.z, clampVector.w);
        foodPos = new Vector3(x, 0, z);
        if (!CheckFoodPos(foodPos))
        {
            CreateFood();
        }
        else
        {
            Instantiate(foodPrefab, foodPos, Quaternion.identity);
        }

    }

    private bool CheckFoodPos(Vector3 pos)
    {
        for (int i = 0; i < Snake._instance.bodyInfos.Count; i++)
        {
            if (Snake._instance.bodyInfos[i].transform.position == pos)
                return false;
        }
        return true;
    }
}
