using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 목표: 위로 계속 이동하고 싶다.

    // 필요 속성
    [Header("이동속도")] public float Speed;

    private void Update()
    {
        // 방향을 구한다.
        Vector2 direction = Vector2.up;

        // 공식에 따라 이동한다.
        // 새로운 위치는 = 현재 위치 + 방향 * 속력 * 시간
        Vector2 position = transform.position;
        Vector2 newPosition = position + direction * Speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
