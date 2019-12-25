using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Rigidbody player;
    
    public float meleeAttackDistance;

    private RaycastHit enemyDetected;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out enemyDetected, meleeAttackDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * enemyDetected.distance, Color.red);
            Debug.Log("enemy hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("not hit");
        }
    }
}
