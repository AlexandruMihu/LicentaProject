using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Patrol : FSMAction
{
    [Header("Config")]
    [SerializeField] private float speed;
    private Waypoint waypoint;
    private int pointIndex;
    private Vector3 nextPosition;
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    public override void Act()
    {
        FollowPath();
    }
    private Vector3 GetCurrentPosition()
    {
        return waypoint.getPosition(pointIndex);
    }
    private void FollowPath()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetCurrentPosition(), speed * Time.deltaTime);
        if(Vector3.Distance(transform.position,GetCurrentPosition())<=0.1)
        {
            UpdateNextPosition();
        }
    }
    private void UpdateNextPosition()
    {
        pointIndex++;
        if (pointIndex > waypoint.Points.Length - 1)
        {
            pointIndex = 0;
        }
    }
}
