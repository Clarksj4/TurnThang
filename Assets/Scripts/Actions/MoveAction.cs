﻿using UnityEngine;

public class MoveAction : BattleAction
{
    public override bool IsActorAble(Actor actor)
    {
        return !actor.Incapacitated;
    }

    public override bool IsTargetValid(BattleMap map, Vector2Int position)
    {
        return map.GetPawnAtCoordinate(position) == null;
    }

    public override bool Do()
    {
        bool canDo = IsActorAble(Actor) && IsTargetValid(TargetMap, TargetPosition);

        if (canDo)
            Actor.SetCoordinate(TargetPosition);
        else
            Debug.Log($"Can't perform move action.");

        return canDo;
    }
}