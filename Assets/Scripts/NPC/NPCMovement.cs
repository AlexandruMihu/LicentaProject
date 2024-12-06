using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float moveSpeed;

    private readonly int moveX = Animator.StringToHash("MoveX");
    private readonly int moveY = Animator.StringToHash("MoveY");

    private Waypoint waypoint;
    private Animator animator;
    private Vector3 previousPos;
    private int currentPointIndex;
    private bool canMove = true; // Boolean to control NPC movement


    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!canMove) return; // Check if the NPC is allowed to move

        Vector3 nextPos = waypoint.getPosition(currentPointIndex);
        UpdateMoveValues(nextPos);
        transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, nextPos) <= 0.2)
        {
            previousPos = nextPos;
            currentPointIndex = (currentPointIndex + 1) % waypoint.Points.Length;
        }
    }

    private void UpdateMoveValues(Vector3 nextPos)
    {
        Vector2 direction = Vector2.zero;
        if (previousPos.x < nextPos.x) direction = new Vector2(1, 0);
        if (previousPos.x > nextPos.x) direction = new Vector2(-1, 0);
        if (previousPos.y < nextPos.y) direction = new Vector2(0, 1);
        if (previousPos.y > nextPos.y) direction = new Vector2(0, -1);

        animator.SetFloat(moveX, direction.x);
        animator.SetFloat(moveY, direction.y);
    }
    public void SetMovement(bool state)
    {
        canMove = state;
    }
}
