using UnityEngine;

[CreateAssetMenu(fileName = "Create New Level Data", menuName = "ScriptableObject/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    [Header("Level Information")]
    public bool isLevelCompleted;       // Seviye bitiş durumu
    public int heartCost;               // Kalp satın almanın maliyeti 
    
    
    [Header("Time Information")]

    [SerializeField] private int m_minutes;                 // Seviye süresi - dakikalar
    [SerializeField] private int m_seconds;                 // Seviye süresi - saniyeler

    /// <summary>
    /// Seviye süresini toplam saniye cinsinden döner.
    /// </summary>
    /// <returns>Toplam saniye</returns>
    public int GetTotalTimeInSeconds()
    {
        return (m_minutes * 60) + m_seconds;
    }
}