using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 목표: 위로 계속 이동하고 싶다.

    // 필요 속성
    [Header("이동")] 
    public float StartSpeed   = 1f;
    public float EndSpeed     = 7f;
    public float Acceleration = 1.2f;
    private float _speed;

    private void Start()
    {
        _speed = StartSpeed;
    }

    private void Update()
    {
        _speed += Time.deltaTime; // 1초당 +1과 같다.
        
        
        // 방향을 구한다.
        Vector2 direction = Vector2.up;

        // 공식에 따라 이동한다.
        // 새로운 위치는 = 현재 위치 + 방향 * 속력 * 시간
        Vector2 position = transform.position;
        Vector2 newPosition = position + direction * _speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
