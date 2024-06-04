using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab; // 苹果预制件
    public float spawnInterval = 2.0f; // 掉落间隔

    void Start()
    {
        InvokeRepeating("DropApple", 2.0f, spawnInterval);
    }

    void DropApple()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity);
    }
}
