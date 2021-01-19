﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Pawn Stats")]
public class PawnStats : ScriptableObject
{
    [Header("Initiative")]
    public float Priority = 0;

    [Header("Defense")]
    public int Defense;
    public int Evasion;
    public int MaxHealth;

    public virtual void SetStats(Pawn pawn)
    {
        pawn.name = name;
        pawn.Defense = Defense;
        pawn.Evasion = Evasion;
        pawn.MaxHealth = MaxHealth;
        pawn.Health = MaxHealth;
        pawn.Priority = Priority;
    }
}