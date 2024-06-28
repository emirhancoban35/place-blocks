using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
   public int m_remaingHealth { get; private set; }
   public bool isInLevel;
}