﻿using System.Linq;

public class RankCellsRestriction : TargetingRestriction
{
    /// <summary>
    /// Gets or sets the ranks that are valid targets.
    /// </summary>
    public int[] Ranks = new int[0];

    public override bool IsTargetValid(Pawn actor, Cell cell)
    {
        return Ranks.Contains(cell.Formation.GetRank(cell.Coordinate));
    }
}
