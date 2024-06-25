using System;
using MyGrid.Code;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour ,IPointerDownHandler,IDragHandler,IPointerUpHandler
{
    private Vector3 _offset;
    [SerializeField] private LayerMask mask;
    
    private Transform _currentMovable;
    private Vector3 _homePosition;
    private GridManager _gridManager;


    private void Start()
    {
        _currentMovable = transform.parent;
        _homePosition = transform.position;
        _gridManager = transform.parent.GetComponent<GridManager>();

    }

    #region Pointers
    public void OnPointerDown(PointerEventData eventData)
    {
        var target = Camera.main.ScreenToWorldPoint(eventData.position);
        _offset = _currentMovable.position - target;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var target = Camera.main.ScreenToWorldPoint(eventData.position);
        target += _offset;
        target.z = 0;
        _currentMovable.position= target;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var allowSetIsGrid = AllowSetToGrid();
        if (allowSetIsGrid)
        {
            SetPositionAll();
        }
        else
        {
            BackHomeAll();
        }
    }
    
    #endregion

    #region Managers
    private bool AllowSetToGrid()
    {
        var allowSetIsGrid = true;
        foreach (var tiles in _gridManager.Tiles)
        {
            if(tiles.gameObject.activeSelf)continue;
            
            var myTile = (TileManager)tiles;
            var baseTile = myTile.Draggable.Hit();
            if (baseTile)continue;

            allowSetIsGrid = false;
            break;
        }
        return allowSetIsGrid; 
    }
    private void SetPositionAll()
    {
        foreach (var tile in _gridManager.Tiles)
        {
            // if (!tile.gameObject.activeSelf) continue;
            var myTile = (TileManager)tile;
            myTile.Draggable.SetPositionToHit();
        }
    }

    private void BackHomeAll()
    {
        foreach (var tiles in _gridManager.Tiles)
        {
            if(tiles.gameObject.activeSelf)continue;
            var myTile = (TileManager)tiles;
            myTile.Draggable.BackHome();
        }
    }

    #endregion
     
    private void SetPositionToHit()
    {
        var hit = Hit();
        var target = hit.transform.position;
        target.z = 0.5f;
        transform.position = target;

    }

   
    private void BackHome()
    {
        transform.position = _homePosition;
    }

  

    private RaycastHit2D Hit()
    {
        var orgin = transform.position;
        return Physics2D.Raycast(orgin, Vector3.forward,10,mask);
    }

    // private void FixedUpdate()
    // {
    //     var hit = Hit();
    //     Debug.Log(hit ? $"hit {hit.transform.name}":"no hit");
    //     if (hit)
    //     {
    //         Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)* hit.distance ,Color.yellow);
    //         Debug.Log("did hit");
    //     }
    //     else
    //     {
    //         Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)* 1000,Color.red);
    //         Debug.Log("did not hit");
    //     }
    // }
}
