using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Utilities;


[RequireComponent(typeof(Collider))]
public class SingleTowerPlacementArea : MonoBehaviour, IPlacementArea
{
    public PlacementTile placementTilePrefab;

    public PlacementTile placementTilePrefabMobile;

    PlacementTile m_SpawnedTile;

    bool m_IsOccupied;

    protected void Awake()
    {
        PlacementTile tileToUse;
#if UNITY_STANDALONE
        tileToUse = placementTilePrefab;
#else
			tileToUse = placementTilePrefabMobile;
#endif

        if (tileToUse != null)
        {
            m_SpawnedTile = Instantiate(tileToUse);
            m_SpawnedTile.transform.SetParent(transform);
            m_SpawnedTile.transform.localPosition = new Vector3(0f, 0.05f, 0f);
        }
    }


    public IntVector2 WorldToGrid(Vector3 worldPosition, IntVector2 sizeOffset)
    {
        return new IntVector2(0, 0);
    }

    public Vector3 GridToWorld(IntVector2 gridPosition, IntVector2 sizeOffset)
    {
        return transform.position;
    }

    public TowerFitStatus Fits(IntVector2 gridPos, IntVector2 size)
    {
        return m_IsOccupied ? TowerFitStatus.Overlaps : TowerFitStatus.Fits;
    }

    public void Occupy(IntVector2 gridPos, IntVector2 size)
    {
        m_IsOccupied = true;

        if (m_SpawnedTile != null)
        {
            m_SpawnedTile.SetState(PlacementTileState.Filled);
        }
    }

    public void Clear(IntVector2 gridPos, IntVector2 size)
    {
        m_IsOccupied = false;

        if (m_SpawnedTile != null)
        {
            m_SpawnedTile.SetState(PlacementTileState.Empty);
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Color prevCol = Gizmos.color;
        Gizmos.color = Color.cyan;

        Matrix4x4 originalMatrix = Gizmos.matrix;
        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawWireSphere(Vector3.zero, 1);

        Gizmos.matrix = originalMatrix;
        Gizmos.color = prevCol;

        // Gizmos.DrawIcon(transform.position + Vector3.up, "build_zone.png", true);
    }
#endif
}