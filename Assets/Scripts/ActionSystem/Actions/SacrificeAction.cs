﻿using System.Collections.Generic;

public class SacrificeAction : BattleAction
{
    protected override void Setup()
    {
        // Misc information about the ability
        Tags = ActionTag.Heal;

        actorRestrictions = new List<TargetingRestriction>()
        {
            new ManaRestriction() { Amount = 1 },
            new HealthRestriction() { Amount = 25 }
        };

        // The cells we can target
        targetRestrictions = new List<TargetingRestriction>()
        {
            new CellContentRestriction() { Content = TargetableCellContent.Ally },
            new HealthRestriction() { Amount = -1 }
        };

        // The cells that will be affected
        areaOfEffect = new List<AffectedArea>()
        {
            new AffectedPoint()
        };

        // Remove own health...
        selfActions = new List<ActionNode>()
        {
            new RemoveManaNode() { Amount = 1 },
            new DoDamageNode() { BaseDamage = 25 }
        };

        // ... give that health to target.
        targetedActions = new List<ActionNode>()
        {
            new HealNode() { Amount = 25 }
        };
    }
}
