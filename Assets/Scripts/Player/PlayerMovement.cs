using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    public Vector2 MoveDirection => moveDirection;

    private PlayerAnimations playerAnimations;
    private PlayerActions actions;
    private Player player;
    private Rigidbody2D rb2d;
    private Vector2 moveDirection;

    private void Awake()
    {
        actions = new PlayerActions();
        player = GetComponent<Player>();
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (player.Stats.Health <= 0) return;
        rb2d.MovePosition(rb2d.position + moveDirection * speed * Time.fixedDeltaTime);
    }
    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (moveDirection == Vector2.zero)
        {
            playerAnimations.SetMovingState(false);
            return;
        }
        playerAnimations.SetMovingState(true);
        playerAnimations.SetMoveAnimation(moveDirection);
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
