using System.Collections;
using System.Collections.Generic;
using UnityEditor;

#if UNITY_EDITOR
using UnityEngine;
#endif

public class __Tower : MonoSingleton<__Tower>
{
    public List<TowerData> _Data = new List<TowerData>();



#if UNITY_EDITOR
    public string[] paths;

    [ContextMenu("PreLoadDataSkill")]
    public void PreloadAbility()
    {
        _Data = new List<TowerData>();

        var guids = AssetDatabase.FindAssets("t:scriptableobject", paths);

        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            var Tower = AssetDatabase.LoadAssetAtPath(path, typeof(TowerData)) as TowerData;

            if (Tower)
                _Data.Add(Tower);            
        }
    }

#endif
}
