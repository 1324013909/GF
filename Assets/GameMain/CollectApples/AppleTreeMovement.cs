using UnityEngine;

public class AppleTreeMovement : MonoBehaviour
{
    public float speed = 2.0f; // 移动速度
    public float moveRange = 5.0f; // 移动范围

    private float startPosition;

    void Start()
    {
        startPosition = transform.position.x;
    }

    void Update()
    {
        float newX = startPosition + Mathf.PingPong(Time.time * speed, moveRange) - (moveRange / 2);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
