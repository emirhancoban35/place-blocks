using JetBrains.Annotations;
using UnityEngine;
using Zenject;

public class LevelManager : MonoBehaviour
{
    private CountdownTimer _countdownTimer;

    [Inject]
    public void Construct(CountdownTimer countdownTimer)
    {
        _countdownTimer = countdownTimer;
    }

    public void CompleteLevel()
    {
        GameManager.Instance.playingLevelData.isLevelCompleted = true;
        _countdownTimer.PauseTimer();
        Debug.Log("Level is complete");
    }

    public void FailLevel()
    {
        GameManager.Instance.DecreaseHealth();
        _countdownTimer.PauseTimer();
        Debug.Log("Level Failed");
    }

    public void ContinueLevel()
    {
        _countdownTimer.ResumeTimer();
    }
}