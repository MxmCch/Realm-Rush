using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable {get {return isPlaceable;} }

    void OnMouseUp() 
    {
        if (isPlaceable)
        {
            Instantiate(towerPrefab, transform.position,Quaternion.identity,this.transform);
            isPlaceable = false;
        }
    }
}
