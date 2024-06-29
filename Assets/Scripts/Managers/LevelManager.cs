using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [CanBeNull] public LevelData playingLevelData;

    private void Start()
    {
        //test kodudur
        playingLevelData = GameManager.Instance.playingLevelData;
    }

    public void CompleteLevel()
    {
        //
    }
}
