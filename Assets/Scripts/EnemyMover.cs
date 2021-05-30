using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float TravelSpeed = 2f;

    void Start()
    {
        StartCoroutine(PrintWaypointName());
    }

    IEnumerator PrintWaypointName()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 StartPosition = transform.position;
            Vector3 EndPosition = waypoint.transform.position;
            float TravelPercent = 0f;

            transform.LookAt(EndPosition);

            while(TravelPercent < 1f)
            {
                TravelPercent += Time.deltaTime * TravelSpeed;
                transform.position = Vector3.Lerp(StartPosition,EndPosition,TravelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
