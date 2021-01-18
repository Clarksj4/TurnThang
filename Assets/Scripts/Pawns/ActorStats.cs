﻿using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Character", menuName = "Actor Stats")]
public class ActorStats : PawnStats
{
    [Header("Movement")]
    public int Movement;

    [Header("Attack")]
    public int Attack;
    public int Accuracy;

    [Header("Actions")]
    public List<string> Actions;

    public override void SetStats(Pawn pawn)
    {
        base.SetStats(pawn);

        if (pawn is Actor)
        {
            Actor actor = pawn as Actor;
            actor.Movement = Movement;
            actor.Attack = Attack;
            actor.Accuracy = Accuracy;
            actor.Actions = Actions;
        }
    }
}
