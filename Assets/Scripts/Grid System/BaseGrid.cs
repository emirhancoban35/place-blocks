using System;
using System.Collections.Generic;
using MyGrid.Code;
using UnityEngine;
using Zenject;

public class BaseGrid : Singleton<BaseGrid>
{
    [SerializeField] private GridManager _gridManager;
    private LevelManager _levelManager;
    
    [Inject]
    public void Construct(LevelManager levelManager)
    {
        _levelManager = levelManager;
    }
    
    public void CheckGrid()
    {
        if (GameManager.Instance.isInEndlessMode)
        {
            CheckAndDestroyRow();
            CheckAndDestroyColumn();
        }
        else
        {
            if (IsGridFull())
            {
                _levelManager.CompleteLevel();
            }
        }
    }

    private bool IsGridFull()
    {
        foreach (var tile in _gridManager.Tiles)
        {
            var myTile = tile.GetComponent<MyTile>();
            if (myTile == null || myTile.OnMyTile == null)
            {
                return false;
            }
        }
        return true;
    }

    private void CheckAndDestroyColumn()
    {
        List<int> willDestroyColumnIndex = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            if (IsFullColumn(i))
            {
                Debug.Log($"Is Full Column {i}");
                willDestroyColumnIndex.Add(i);
            }
        }

        foreach (var column in willDestroyColumnIndex)
        {
            for (int y = 0; y < 10; y++)
            {
                var tile = (MyTile)_gridManager.GetTile(new Vector2Int(column, y));
                if (tile.OnMyTile) tile.OnMyTile.Destroy(y * .05f);
            }
        }
    }

    private void CheckAndDestroyRow()
    {
        List<int> willDestroyRowIndex = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            if (IsFullRow(i))
            {
                Debug.Log($"Is Full Row {i}");
                willDestroyRowIndex.Add(i);
            }
        }

        foreach (var rowIndex in willDestroyRowIndex)
        {
            for (int x = 0; x < 10; x++)
            {
                var tile = (MyTile)_gridManager.GetTile(new Vector2Int(x, rowIndex));
                if (tile.OnMyTile) tile.OnMyTile.Destroy(x * .05f);
            }
        }
    }

    private bool IsFullRow(int row)
    {
        for (int i = 0; i < 10; i++)
        {
            var tile = (MyTile)_gridManager.GetTile(new Vector2Int(i, row));
            if (!tile.OnMyTile) return false;
        }
        return true;
    }

    private bool IsFullColumn(int column)
    {
        for (int i = 0; i < 10; i++)
        {
            var tile = (MyTile)_gridManager.GetTile(new Vector2Int(column, i));
            if (!tile.OnMyTile) return false;
        }
        return true;
    }
}
