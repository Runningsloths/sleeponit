using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody player;

    [Header("Movement")]
    public float speed = 2500f;
    public float speedLimit = 12f;

    private PlayerInput inputActions;
    private Vector2 movementInputXY;

    void Awake()
    {
        // Reading movement input
        inputActions = new PlayerInput();
        inputActions.Player.Movement.performed += ctx => movementInputXY = ctx.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        // Movement
        Vector3 movementInputXZ = new Vector3(movementInputXY.x, 0, movementInputXY.y);
        player.AddForce(speed * movementInputXZ.normalized * Time.deltaTime);
        player.velocity = Vector3.ClampMagnitude(player.velocity, speedLimit);
    }
    private void OnEnable() 
    {
        inputActions.Enable();
    }
    private void OnDisable() 
    {
        inputActions.Disable();
    }
}