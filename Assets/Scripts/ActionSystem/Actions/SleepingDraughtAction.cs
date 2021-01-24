﻿using System.Collections.Generic;

public class SleepingDraughtAction : BattleAction
{
    protected override void Setup()
    {
        // The cells we can target
        targetRestrictions = new List<TargetingRestriction>()
        {
            new CellContentRestriction() { Actor = Actor, Content = TargetableCellContent.Enemy },
            new ExposedCellsRestriction() { Actor = Actor },
            new FileCellsRestriction() { Actor = Actor, File = Actor.File }
        };

        // The cells that will be affected
        areaOfEffect = new List<AffectedArea>()
        {
            new AffectedPoint(this)
        };

        // The effect upon those cells.
        targetedActions = new List<ActionNode>()
        {
            new ApplyStatusNode() { Actor = Actor, Status = new DrowsyStatus() { Duration = 1, SleepDuration = 2 } }
        };
    }
}
