﻿using SimpleBehaviourTree;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BurningStatus : PawnStatus
{
    [Tooltip("The amount of damage that will be done to adjacent cells each turn.")]
    public int DamagePerTurn;

    protected override void DoEffect()
    {
        DoDamageNode damage = new DoDamageNode() { BaseDamage = DamagePerTurn };

        IEnumerable<Cell> adjacentCells = Pawn.Grid.GetRange(Pawn.Coordinate, 1, 1);
        foreach (Cell cell in adjacentCells)
        {
            BehaviourTreeState state = new BehaviourTreeState()
            {
                { "Actor", Pawn },
                { "Cell", cell }
            };

            damage.Do(state);
        }
    }
}
