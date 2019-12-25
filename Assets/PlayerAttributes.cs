﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    // public const float STARTING_HEALTH = 100;
    // public const float STARTING_MANA = 100;
    // public const float STARTING_LEVEL = 1;
    // public const float STARTING_EXP = 0;
    // public const float STARTING_EXP_CAP = 100;

    [Header("Raw Stats")]
    public float maxHealth;
    public float maxMana;
    public float dmgExperimental;
    [Header("Level")]
    public float level;
    public float exp;
    public float expCap;
    public float skillPoints;

    // void Start() {
    //     maxHealth = STARTING_HEALTH;
    //     maxMana = STARTING_MANA;
    //     level = STARTING_LEVEL;
    //     exp = STARTING_EXP;
    //     expCap = STARTING_EXP_CAP;
    // }
    public void levelUp()
    {
        maxHealth += Mathf.Floor(maxHealth * 0.1f) + 50f;
        maxMana += Mathf.Floor(maxMana * 0.1f) + 50f;
        level++;
        exp = 0;
        expCap += Mathf.Floor(expCap * 0.75f);
        skillPoints++;
    }
}
