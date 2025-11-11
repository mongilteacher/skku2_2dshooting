using System;
using UnityEngine;

// 플레이어는 플레이어 관련 스탯을 중앙관리하고, 컴포넌트도 관리한다.
public class Player : MonoBehaviour
{
    private PlayerManualMove _playerManualMove;
    private PlayerAutoMove   _playerAutoMove;
    
    private bool _autoMode = false;
    public bool AutoMode => _autoMode;
    
    private float _health = 3;
    private const float MaxHealth = 10;
    public float Health => _health;

    private float _moveSpeed = 2;
    private const float MaxMoveSpeed = 4;
    public float MoveSpeed => _moveSpeed;

    private float _attackCoolTime = 1f;
    private const float MaxAttackCoolTime = 0.2f;
    public float AttackCoolTime = 1f;
    

    private void Start()
    {
        _playerAutoMove   = GetComponent<PlayerAutoMove>();
        _playerManualMove = GetComponent<PlayerManualMove>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) _autoMode = true;
        if (Input.GetKeyDown(KeyCode.Alpha2)) _autoMode = false;
        
        if (_autoMode)
        {
            _playerAutoMove.Execute();
        }
        else
        {
            _playerManualMove.Execute();
        }
    }
    

    public void Hit(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(float value)
    {
        _health = Math.Min(_health + value, MaxHealth);
    }

    public void AttackSpeedUp(float value)
    {
        _attackCoolTime = Math.Max(_attackCoolTime - value, MaxAttackCoolTime);
    }

    public void MoveSpeedUp(float value)
    {
        _moveSpeed = Math.Min(_moveSpeed + value, MaxMoveSpeed);
    }
}
