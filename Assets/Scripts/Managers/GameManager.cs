using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
   public int m_remaingHealth { get; private set; }
   public bool isInEndlessMode;
   
   [CanBeNull] public LevelData playingLevelData;
   public LevelData[] allLevelDatas;
   private void Start()
   {
      //test kodudur
      playingLevelData = allLevelDatas[0];
      DontDestroyOnLoad(this.gameObject);
   }
   
}