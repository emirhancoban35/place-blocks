using TMPro;
using UnityEngine;
using Zenject;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_timerText;  

    private LevelData _levelData;  
    private float _remainingTime;
    private bool _isTimerRunning;
    
    private LevelManager _levelManager;

    [Inject]
    public void Construct(LevelManager levelManager)
    {
        _levelManager = levelManager;
    }
    
    private void Start()
    {
        _levelData = GameManager.Instance.playingLevelData;
        if (_levelData != null)
        {
            _remainingTime = _levelData.GetTotalTimeInSeconds();
            _isTimerRunning = true;
        }
        else
        {
            Debug.LogError("LevelData is not assigned.");
        }
    }

    private void Update()
    {
        if (_isTimerRunning)
        {
            if (_remainingTime > 0)
            {
                _remainingTime -= Time.deltaTime;
                UpdateTimerDisplay(_remainingTime);
            }
            else
            {
                _isTimerRunning = false;
                _remainingTime = 0;
                OnTimerEnd();
            }
        }
    }

    private void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        m_timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void OnTimerEnd()
    {
        Debug.Log("Timer has ended!");
        if (!_levelData.isLevelCompleted)
        {
            _levelManager.FailLevel();
            this.gameObject.SetActive(false);
        }
    }

    public void PauseTimer()
    {
        _isTimerRunning = false;
    }

    public void ResumeTimer()
    {
        _isTimerRunning = true;
        this.gameObject.SetActive(true);

    }
}