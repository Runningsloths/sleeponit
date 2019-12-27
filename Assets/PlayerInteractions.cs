using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Melee Attack Attributes")]
    public Rigidbody enemy;
    public float meleeAttackDistance;
    
    private RaycastHit enemyDetected;

    void FixedUpdate()
    {
        // Melee Attack Detection
        CapsuleCollider playerCollider = gameObject.GetComponent<CapsuleCollider>();
        Vector3 playerColliderCenter = playerCollider.transform.position;
        playerColliderCenter.y += playerCollider.height/2f;
        if (Physics.Raycast(playerColliderCenter, playerCollider.transform.forward, out enemyDetected, meleeAttackDistance))
        {
            Debug.Log(enemyDetected);
        }
        Debug.DrawRay(playerColliderCenter, playerCollider.transform.forward, Color.red);
    }
}
