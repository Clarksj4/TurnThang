﻿using System;
using System.Collections.Generic;

[Serializable]
public class BurningStatus : PawnStatus
{
    /// <summary>
    /// Gets or sets the amount of damage that
    /// will be done to adjacent pawns.
    /// </summary>
    public int DamagePerTurn;

    protected override void DoEffect()
    {
        DoDamageNode damage = new DoDamageNode() { BaseDamage = DamagePerTurn };
        
        IEnumerable<Cell> adjacentCells = Pawn.Grid.GetRange(Pawn.Coordinate, 1, 1);
        foreach (Cell cell in adjacentCells)
            damage.Do(Pawn, cell);
    }
}