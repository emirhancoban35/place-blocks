using UnityEngine;
using Zenject;
using JetBrains.Annotations;

public class GameManager : MonoSingleton<GameManager>
{
    public int m_remainingHealth;
    public bool isInEndlessMode;
    [CanBeNull] public LevelData playingLevelData;
    public LevelData[] allLevelDatas;

    private HealthUIManager _healthUIManager;

    [Inject]
    public void Construct(HealthUIManager healthUIManager)
    {
        _healthUIManager = healthUIManager;
    }

    private void Start()
    {
        playingLevelData = allLevelDatas[0];
        DontDestroyOnLoad(this.gameObject);
        _healthUIManager.InitializeHearts(m_remainingHealth);
    }

    public void DecreaseHealth()
    {
        if (m_remainingHealth > 0)
        {
            m_remainingHealth--;
            _healthUIManager.UpdateHearts(m_remainingHealth);
        }
        else
        {
            Debug.Log("No Health");
        }
    }
}