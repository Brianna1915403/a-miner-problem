using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OreSpawner))]
public class OreSpawnerEditor : Editor
{
    private OreSpawner m_Script;
    private GUILayoutOption[] m_ButtonOptions = new GUILayoutOption[] { GUILayout.ExpandWidth(true) };

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        DrawDefaultInspector();
        m_Script = (OreSpawner)target;

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Spawn Ore", m_ButtonOptions))
        {
            m_Script.SpawnOre();
        }
        if (GUILayout.Button("Destroy All Ore", m_ButtonOptions))
        {
            m_Script.DestroyAllOre();
        }
        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();
    }
}
