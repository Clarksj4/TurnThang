﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Rendering;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Actor))]
    public class ActorAppearance : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer frameImage = null;
        [SerializeField]
        private SpriteRenderer actorImage = null;
        [SerializeField]
        private SortingGroup maskSortingGroup = null;

        private Actor actor = null;

        private void Awake()
        {
            actor = GetComponent<Actor>();
            actor.OnTeamChanged += HandleOnTeamChanged;

            TurnManager.Instance.OnTurnStart += HandleOnTurnStart;
            TurnManager.Instance.OnTurnEnd += HandleOnTurnEnd;
        }

        private void Start()
        {
            RefreshActorImage();
        }

        private void RefreshActorImage()
        {
            actorImage.sprite = SpriteManager.Instance.GetSpriteByName(name);
        }

        private void IncrementSortOrders(int amount)
        {
            frameImage.sortingOrder += amount;
            actorImage.sortingOrder += amount;
            maskSortingGroup.sortingOrder += amount;
        }

        private void ApplySelectionColour()
        {
            frameImage.color = Color.green;
            IncrementSortOrders(1);
        }

        private void ApplyTeamColour()
        {
            frameImage.color = actor.Team.Colour;
            IncrementSortOrders(-1);
        }

        private void HandleOnTurnStart(ITurnBased turnBasedEntity)
        {
            if (turnBasedEntity == (ITurnBased)actor)
                ApplySelectionColour();
        }

        private void HandleOnTurnEnd(ITurnBased turnBasedEntity)
        {
            if (turnBasedEntity == (ITurnBased)actor)
                ApplyTeamColour();
        }

        private void HandleOnTeamChanged()
        {
            ApplyTeamColour();
        }
    }
}