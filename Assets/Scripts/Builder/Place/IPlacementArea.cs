using Core.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlacementArea
{
    Transform transform { get; }

    IntVector2 WorldToGrid(Vector3 worldPosition, IntVector2 sizeOffset);

    Vector3 GridToWorld(IntVector2 gridPosition, IntVector2 sizeOffset);

    void Occupy(IntVector2 gridPos, IntVector2 size);

    void Clear(IntVector2 gridPos, IntVector2 size);

    TowerFitStatus Fits(IntVector2 gridPos, IntVector2 size);
}

public static class PlacementAreaExtensions
{
    public static Vector3 Snap(this IPlacementArea placementArea, Vector3 worldPosition, IntVector2 sizeOffset)
    {
        return placementArea.GridToWorld(placementArea.WorldToGrid(worldPosition, sizeOffset), sizeOffset);
    }
}