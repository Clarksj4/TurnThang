﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FrostWallAction : BattleAction
{
    public FrostWallAction(Actor actor)
        : base(actor) { /* Nothing! */ }

    protected override void Setup()
    {
        // Can only target empty cells on the same rank
        targetRestrictions = new List<TargetingRestriction>()
        {
            new CellContentRestriction(this, TargetableCellContent.Empty),
            new FormationRestriction(this, TargetableFormation.Self)
        };

        // Affects all cells in targeted rank
        areaOfEffect = new List<AffectedArea>()
        {
            new AffectedRank(this)
        };

        // Will only affect empty cells
        areaOfEffectRestrictions = new List<TargetingRestriction>()
        {
            new CellContentRestriction(this, TargetableCellContent.Empty)
        };

        targetedActions = new List<ActionNode>()
        {
            new SummonNode(this) { Name = "FrostWall", Priority = Actor.Priority, Duration = 3 }
        };
    }
}