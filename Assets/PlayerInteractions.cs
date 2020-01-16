using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Rigidbody enemy;
    [Header("Melee Attack Attributes")]
    public float meleeAttackDistance;
    [Header("Ranged Attack Attributes")]
    public float rangedAttackDistance;

    private RaycastHit enemyDetected;
    private PlayerInput inputActions;
    private float attackDetection;

    private void Awake() {
        inputActions = new PlayerInput();
        inputActions.Player.General.performed += ctx => attackDetection = ctx.ReadValue<float>();
    }
    void FixedUpdate()
    {
        CapsuleCollider playerCollider = gameObject.GetComponent<CapsuleCollider>();
        Vector3 playerColliderCenter = playerCollider.transform.position;
        playerColliderCenter.y += playerCollider.height/2f;
        // Melee Attack Detection
        if (Physics.Raycast(playerColliderCenter, playerCollider.transform.forward, out enemyDetected, meleeAttackDistance))
        {
            //Debug.Log(enemyDetected);
        }
        //Debug.DrawRay(playerColliderCenter, playerCollider.transform.forward + new Vector3(0,0,1), Color.red);

        // Ranged Attack Detection
        if (Physics.Raycast(playerColliderCenter, playerCollider.transform.forward, out enemyDetected, rangedAttackDistance))
        {
            if (enemyDetected.transform.gameObject.tag == "Enemy" && attackDetection == 1)
            {
                Debug.Log(enemyDetected.collider);
            }
        }
        //Debug.DrawRay(playerColliderCenter, playerCollider.transform.forward + new Vector3(0,0,4), Color.blue);
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