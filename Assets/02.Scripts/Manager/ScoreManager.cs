using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // 단하나여야 한다.
    // 전역적인 접근점을 제공해야한다.
    // 게임 개발에서는 Manager(관리자) 클래스를 보통 싱글톤 패턴으로 사용하는것이 관행이다.
    private static ScoreManager _instance = null;
    public static ScoreManager Instance => _instance;
    private void Awake()
    {
        // 인스턴스가 이미 생성(참조)된게 있다면
        // 후발주자들은 삭제해버린다.
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        
        _instance = this;
    }
    
    
    
    [SerializeField]
    private Text _currentScoreTextUI;
    private int _currentScore = 0;

    private const string ScoreKey = "Score";
    
    private void Start()
    {
        Load();
        
        Refresh();
    }

    // 하나의 메서드는 한 가지 일만 잘 하면된다.
    public void AddScore(int score)
    {
        if (score <= 0) return;
        
        _currentScore += score;
        
        Refresh();

        Save();
    }

    private void Refresh()
    {
        _currentScoreTextUI.text = $"현재 점수: {_currentScore:N0}";
    }

    private void Save()
    {
        PlayerPrefs.SetInt(ScoreKey, _currentScore);
    }

    private void Load()
    {
        _currentScore = PlayerPrefs.GetInt(ScoreKey, 0);
    }
}
