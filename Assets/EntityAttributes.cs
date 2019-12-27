using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public abstract class EntityAttributes : MonoBehaviour
{
    [SerializeField]
    protected float dmg;
    [SerializeField]
    protected float maxHealth;
    [SerializeField]
    protected float level;

    protected abstract void levelUp();
}
