using System;
using System.Collections.Generic;
using MyGrid.Code;
using UnityEngine;

public class BaseGrid : Singleton<BaseGrid>
{
    [SerializeField] private GridManager _gridmanager;

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
                Debug.Log("Grid is full");
            }
        }
    }

    /// <summary>
    /// Checks if the entire grid is full.
    /// </summary>
    private bool IsGridFull()
    {
        foreach (var tile in _gridmanager.Tiles)
        {
            var myTile = tile.GetComponent<MyTile>();
            if (myTile == null || myTile.OnMyTile == null)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Checks and destroys full columns in the grid.
    /// </summary>
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
                var tile = (MyTile)_gridmanager.GetTile(new Vector2Int(column, y));
                if (tile.OnMyTile) tile.OnMyTile.Destroy(y * .05f);
            }
        }
    }

    /// <summary>
    /// Checks and destroys full rows in the grid.
    /// </summary>
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
                var tile = (MyTile)_gridmanager.GetTile(new Vector2Int(x, rowIndex));
                if (tile.OnMyTile) tile.OnMyTile.Destroy(x * .05f);
            }
        }
    }

    /// <summary>
    /// Checks if a row is full.
    /// </summary>
    private bool IsFullRow(int row)
    {
        for (int i = 0; i < 10; i++)
        {
            var tile = (MyTile)_gridmanager.GetTile(new Vector2Int(i, row));
            if (!tile.OnMyTile) return false;
        }
        return true;
    }

    /// <summary>
    /// Checks if a column is full.
    /// </summary>
    private bool IsFullColumn(int column)
    {
        for (int i = 0; i < 10; i++)
        {
            var tile = (MyTile)_gridmanager.GetTile(new Vector2Int(column, i));
            if (!tile.OnMyTile) return false;
        }
        return true;
    }
}
