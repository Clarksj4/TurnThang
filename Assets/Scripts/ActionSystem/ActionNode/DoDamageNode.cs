﻿
public class DoDamageNode : ActionNode
{
    /// <summary>
    /// Gets or sets the amount of damage this action will do.
    /// </summary>
    public int BaseDamage;
    /// <summary>
    /// Gets or sets whether the damage is amplified by the
    /// actor's power level.
    /// </summary>
    public bool Amplifyable = true;
    /// <summary>
    /// Gets or sets whether this damage can be reduced by
    /// defense or delegated to a surrogate.
    /// </summary>
    public bool Defendable = true;

    public override bool Do(Pawn actor, Cell target)
    {
        Pawn defender = target.GetContent<Pawn>();
        if (defender != null)
        {
            int inflicted = Amplifyable ? actor.GetAmplifiedDamage(BaseDamage) : BaseDamage;
            defender.TakeDamage(inflicted, Defendable);
        }
        
        return true;
    }
}
