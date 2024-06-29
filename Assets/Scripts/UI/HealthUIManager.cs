using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIManager : MonoSingleton<HealthUIManager>
{
    [SerializeField] private Image heartPrefab;
    [SerializeField] private Transform heartContainer;
    private List<Image> hearts = new List<Image>();

    private void Start()
    {
        var gridLayoutGroup = heartContainer.GetComponent<GridLayoutGroup>();
        if (gridLayoutGroup == null)
        {
            gridLayoutGroup = heartContainer.gameObject.AddComponent<GridLayoutGroup>();
            gridLayoutGroup.cellSize = new Vector2(50, 50); // Kalp boyutu (ihtiyacınıza göre ayarlayın)
            gridLayoutGroup.spacing = new Vector2(10, 10); // Aralarındaki boşluk (ihtiyacınıza göre ayarlayın)
        }
    }

    public void InitializeHearts(int initialHealth)
    {
        for (int i = 0; i < initialHealth; i++)
        {
            var heart = Instantiate(heartPrefab, heartContainer);
            hearts.Add(heart);
        }
    }

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}