﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class PawnUI : MonoBehaviour
{
    [SerializeField]
    private HealthBar healthBar = null;
    private Pawn pawn = null;

    private void Awake()
    {
        pawn = GetComponentInParent<Pawn>();
        pawn.OnHealthChanged += HandleOnPawnHealthChanged;
    }

    private void HandleOnPawnHealthChanged(int change)
    {
        float fill = (float)pawn.Health / pawn.MaxHealth;
        healthBar.SetHealth(fill);
    }
}