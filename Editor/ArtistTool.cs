using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class ArtistTool : EditorWindow
{
    private Vector2 scrollPosition;
    private float previewSize = 70;
    private const float MinPreviewSize = 50;
    private const float MaxPreviewSize = 200;
    private int toolbarIndex = 0;
    private string[] toolbarOptions = new string[] { "3D Object", "Mixamo", "Effect", "BGM" };

    public static void ShowWindow()
    {
        GetWindow<ArtistTool>("3D 아티스트 툴");
    }

    void OnGUI()
    {
        toolbarIndex = GUILayout.Toolbar(toolbarIndex, toolbarOptions);
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);

        if (toolbarIndex == 0)
        {
            string[] guids = AssetDatabase.FindAssets("", new[] { "Assets/3.Prefab" });
            DisplayAssets(guids);
        }
        else if (toolbarIndex == 1)
        {
            string[] guids = AssetDatabase.FindAssets("", new[] { "Assets/Mixamo/Prefab" });
            DisplayAssets(guids);
        }
        else if (toolbarIndex == 2)
        {
            string[] guids = AssetDatabase.FindAssets("", new[] { "Assets/4.Effect" });
            DisplayAssets(guids);
        }
        else if (toolbarIndex == 3)
        {
            string[] guids = AssetDatabase.FindAssets("", new[] { "Assets/5.Sound" });
            DisplayAssets(guids);
        }
        GUILayout.EndScrollView();
        EditorGUILayout.LabelField("Preview Size", EditorStyles.boldLabel);
        previewSize = EditorGUILayout.Slider(previewSize, MinPreviewSize, MaxPreviewSize);
        Event ctrlWheel = Event.current;
        if (ctrlWheel.type == EventType.ScrollWheel && ctrlWheel.control)
        {
            previewSize -= ctrlWheel.delta.y;
            previewSize = Mathf.Clamp(previewSize, MinPreviewSize, MaxPreviewSize);
            ctrlWheel.Use();
        }
    }

    private void DisplayAssets(string[] guids)
    {
        float gridPadding = 10f;
        float labelHeight = 20f;
        float totalItemHeight = previewSize + labelHeight;
        float windowWidth = EditorGUIUtility.currentViewWidth;
        int columns = Mathf.Max(1, (int)((windowWidth - gridPadding) / (previewSize + gridPadding)));

        int index = 0;
        while (index < guids.Length)
        {
            EditorGUILayout.BeginHorizontal();
            for (int i = 0; i < columns && index < guids.Length; i++, index++)
            {
                EditorGUILayout.BeginVertical(GUILayout.Width(previewSize), GUILayout.Height(totalItemHeight));

                string assetPath = AssetDatabase.GUIDToAssetPath(guids[index]);
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);

                if (prefab != null)
                {
                    Texture2D previewImage = AssetPreview.GetAssetPreview(prefab);
                    if (previewImage != null)
                    {
                        GUILayout.Label(new GUIContent(previewImage), GUILayout.Width(previewSize), GUILayout.Height(previewSize));

                        if (Event.current.type == EventType.MouseDown && GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition))
                        {
                            DragAndDrop.PrepareStartDrag();
                            DragAndDrop.objectReferences = new[] { prefab };
                            DragAndDrop.StartDrag(prefab.name);
                            Event.current.Use();
                        }
                    }

                    GUILayout.Label(prefab.name, EditorStyles.centeredGreyMiniLabel, GUILayout.Width(previewSize));
                }

                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}

