using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class RemoveMissingScript
{

    [MenuItem("Tools/Scripts/Cleanup Missing Scripts _F12")]
    public static void CleanupMissingScripts()
    {
        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            var obj = Selection.gameObjects[i];

            System.Action<GameObject> removeComponent = gameObject =>
            {
                var components = gameObject.GetComponents<Component>();

                // Create a serialized object so that we can edit the component list
                var serializedObject = new SerializedObject(gameObject);
                // Find the component list property
                var prop = serializedObject.FindProperty("m_Component");

                // Track how many components we've removed
                int r = 0;

                // Iterate over all components
                for (int j = 0; j < components.Length; j++)
                {
                    // Check if the ref is null
                    if (components[j] == null)
                    {
                        // If so, remove from the serialized component array
                        prop.DeleteArrayElementAtIndex(j - r);
                        // Increment removed count
                        r++;
                    }
                }

                // Apply our changes to the game object
                serializedObject.ApplyModifiedProperties();
            };


            foreach (var child in obj.GetComponentsInChildren<Transform>())
            {
                removeComponent(child.gameObject);
            }
        }
    }
}
