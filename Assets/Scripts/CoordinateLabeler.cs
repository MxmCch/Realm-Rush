﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways] 
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake() 
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    } 

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ChangeCoordinateColor();
        
        ToggleLabels();
    }

    void ChangeCoordinateColor()
    {
        if (waypoint.IsPlaceable == true)
        {
            label.color = defaultColor;
        } 
        else 
        {
            label.color = blockedColor;
        }
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt((transform.parent.position.x)*2/3);
        coordinates.y = Mathf.RoundToInt((transform.parent.position.z)*2/3);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
