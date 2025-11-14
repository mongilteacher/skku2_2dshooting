using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누르면 총알을 만들어서 발사하고 싶다.
    
    // 필요 속성
    [Header("총구")]
    public Transform FirePosition;
    public float FireOffset = 0.3f;
    public Transform SubFirePositionLeft;
    public Transform SubFirePositionRight;

    [Header("사운드")] 
    public AudioSource FireSound;
    
    private float _coolTimer;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _coolTimer = _player.AttackCoolTime;
    }

    
    private void Update()
    {
        _coolTimer -= Time.deltaTime;
        if (_coolTimer > 0) return;     // 조기 리턴
        
        // 1. 발사 버튼을 누르고 있거나 (혹은) or == || 자동 모드라면...
        if (Input.GetKey(KeyCode.Space) || _player.AutoMode)
        {
            Fire();
        }
    }

    public void Fire()
    {
        if (_coolTimer > 0) return;     // 조기 리턴
        _coolTimer = _player.AttackCoolTime;

        FireSound.Play();
        
        MakeBullets();
        MakeSubBullets();
    }
    

    // 기획은 다같이
    // 정희연: 총알 -> bullet.SetDamage(int damage);
    //         ㄴ 생성 로직이 바뀔때마다 아래 모든 코드가 수정되야한다.
    //         ㄴ 총알 생성이라는 행위 자체를 담당하는 클래스를 만들면 편하지 않을까?
    
    //          총알 생성기.만들어줘(타입, 대미지, 위치, 생성이펙트);
    
    // 하소정: 플레이어가 총알 생성(PlayerFire)
    // 이승빈: 적이 총알 생성(EnemyFire, Enemy, EnemyController)
    // 이승빈: 펫도 총알 생성 (PetFire, Pet, PetController)
    
    private void MakeBullets()
    {
        BulletFactory.Instance.MakeBullet(FirePosition.position + new Vector3(-FireOffset, 0, 0));
        BulletFactory.Instance.MakeBullet(FirePosition.position + new Vector3(+FireOffset, 0, 0));
    }

    private void MakeSubBullets()
    {
        BulletFactory.Instance.MakeSubBullet(SubFirePositionLeft.position);
        BulletFactory.Instance.MakeSubBullet(SubFirePositionRight.position);
    }
}
