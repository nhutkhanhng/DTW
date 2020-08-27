using System;
using System.Collections;
using System.Collections.Generic;
using Core.Utilities;
using UnityEngine;

/// <summary>
/// States the placement tile can be in
/// </summary>
public enum PlacementTileState
{
    Filled,
    Empty
}

public class TowerPlacementGrid : MonoBehaviour, IPlacementArea
{
    public PlacementTile placementTilePrefab;

    [Tooltip("The size of the edge of one grid cell for this area. Should match the physical grid size of towers")]
    public float gridSize = 1;


    float m_InvGridSize;

    bool[,] m_AvailableCells;


    PlacementTile[,] m_Tiles;
    public IntVector2 dimensions;

    public void Clear(IntVector2 gridPos, IntVector2 size)
    {
        IntVector2 extents = gridPos + size;

        // Validate the dimensions and size
        if ((size.x > dimensions.x) || (size.y > dimensions.y))
        {
            throw new ArgumentOutOfRangeException("size", "Given dimensions do not fit in our grid");
        }

        // Out of range of our bounds
        if ((gridPos.x < 0) || (gridPos.y < 0) ||
            (extents.x > dimensions.x) || (extents.y > dimensions.y))
        {
            throw new ArgumentOutOfRangeException("gridPos", "Given footprint is out of range of our grid");
        }

        // Fill those positions
        for (int y = gridPos.y; y < extents.y; y++)
        {
            for (int x = gridPos.x; x < extents.x; x++)
            {
                m_AvailableCells[x, y] = false;

                // If there's a placement tile, clear it
                if (m_Tiles != null && m_Tiles[x, y] != null)
                {
                    m_Tiles[x, y].SetState(PlacementTileState.Empty);
                }
            }
        }
    }

    public Vector3 GridToWorld(IntVector2 gridPosition, IntVector2 sizeOffset)
    {
        Vector3 localPos = new Vector3(gridPosition.x + (sizeOffset.x * 0.5f), 0, gridPosition.y + (sizeOffset.y * 0.5f)) *
                           gridSize;

        return transform.TransformPoint(localPos);
    }

    public TowerFitStatus Fits(IntVector2 gridPos, IntVector2 size)
    {
        // Out of range of our bounds
        if ((size.x > dimensions.x) || (size.y > dimensions.y))
        {
            return TowerFitStatus.OutOfBounds;
        }

        IntVector2 extents = gridPos + size;

        if ((gridPos.x < 0) || (gridPos.y < 0) ||
            (extents.x > dimensions.x) || (extents.y > dimensions.y))
        {
            return TowerFitStatus.OutOfBounds;
        }

        for (int y = gridPos.y; y < extents.y; y++)
        {
            for (int x = gridPos.x; x < extents.x; x++)
            {
                if (m_AvailableCells[x, y])
                {
                    return TowerFitStatus.Overlaps;
                }
            }
        }

        return TowerFitStatus.Fits;
    }
    public void Occupy(IntVector2 gridPos, IntVector2 size)
    {
        IntVector2 extents = gridPos + size;

        if ((size.x > dimensions.x) || (size.y > dimensions.y))
        {
            throw new ArgumentOutOfRangeException("size", "Given dimensions do not fit in our grid");
        }

        if ((gridPos.x < 0) || (gridPos.y < 0) ||
            (extents.x > dimensions.x) || (extents.y > dimensions.y))
        {
            throw new ArgumentOutOfRangeException("gridPos", "Given footprint is out of range of our grid");
        }

        for (int y = gridPos.y; y < extents.y; y++)
        {
            for (int x = gridPos.x; x < extents.x; x++)
            {
                m_AvailableCells[x, y] = true;

                // If there's a placement tile, clear it
                if (m_Tiles != null && m_Tiles[x, y] != null)
                {
                    m_Tiles[x, y].SetState(PlacementTileState.Filled);
                }
            }
        }
    }

    public IntVector2 WorldToGrid(Vector3 worldPosition, IntVector2 sizeOffset)
    {
        Vector3 localLocation = transform.InverseTransformPoint(worldPosition);

        // Scale by inverse grid size
        localLocation *= m_InvGridSize;

        // Offset by half size
        var offset = new Vector3(sizeOffset.x * 0.5f, 0.0f, sizeOffset.y * 0.5f);
        localLocation -= offset;

        int xPos = Mathf.RoundToInt(localLocation.x);
        int yPos = Mathf.RoundToInt(localLocation.z);

        return new IntVector2(xPos, yPos);
    }
}
