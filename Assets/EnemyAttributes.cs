using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyAttributes : EntityAttributes
{
    protected override void levelUp()
    {
        maxHealth += Mathf.Floor(maxHealth * 0.1f) + 50f;
        level++;
    }
}
