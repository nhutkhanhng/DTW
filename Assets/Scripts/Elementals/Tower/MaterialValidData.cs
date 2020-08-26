using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class _MaterialValidData
{
    /// <summary>
    /// The two materials used to represent valid and invalid placement, respectively
    /// </summary>
    public Material _Valid;
    public Material _Invalid;

    /// <summary>
    /// The list of attached mesh renderers 
    /// </summary>
    public MeshRenderer[] _Meshes;
}

public class MaterialValidData : MonoBehaviour
{
    [SerializeField]
    public _MaterialValidData _Data;

    public bool validLocation;

    [ContextMenu("Test")]
    public void InValid()
    {
        foreach (MeshRenderer meshRenderer in _Data._Meshes)
        {
            meshRenderer.sharedMaterial = validLocation ? _Data._Valid : _Data._Invalid;
        }
    }
}
    