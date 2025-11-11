using System;
using UnityEngine;

public enum EItemType 
{
    MoveSpeedUp,
    HealthUp,
    AttackSpeedUp,
}

public class Item : MonoBehaviour
{
    [Header("아이템 타입")]
    public EItemType Type;
    public float Value;

    public float WaitTime = 2f;
    public float MoveSpeed = 5f;

    private Player _player;

    private void Awake()
    {
        _player = FindAnyObjectByType<Player>();
    }
    
    private void Update()
    {
        WaitTime -= Time.deltaTime;
        if (WaitTime > 0) return;
        
        // 1. 플레이어를 찾는다.
        if (_player == null) return;

        // 2. 방향을 구한다.
        Vector2 direction = _player.transform.position - transform.position;
            
        // 3. 이동한다.
        transform.Translate(direction * MoveSpeed * Time.deltaTime);
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == false) return;
        
        Apply();

        Destroy(gameObject);
    }

    private void Apply()
    {
        // 아이템 타입에 따라서 다르게 적용
        switch (Type)
        {
            case EItemType.MoveSpeedUp:
            {
                _player.MoveSpeedUp(Value);
                break;
            }

            case EItemType.AttackSpeedUp:
            {
                _player.AttackSpeedUp(Value);
                break;
            }

            case EItemType.HealthUp:
            {
                _player.Heal(Value);
                break;
            }
        }
  
    }
}
