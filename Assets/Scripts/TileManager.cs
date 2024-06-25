using System;
using System.Collections;
using System.Collections.Generic;
using MyGrid.Code;
using UnityEngine;

public class TileManager : TileController
{
   public Draggable Draggable { get; private set; }

   private void Start()
   {
      Draggable = GetComponent<Draggable>();
   }
}
