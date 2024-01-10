using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class PluginHelp : EditorWindow
{
    private Color backgroundColor;
    private GUIStyle greetStyle;
    private GUIStyle labelStyle;
    private float labelFontSize = 15f;
    private float greetFontSize = 20f;
    Color fontColor = Color.white;
    public static void ShowWindow()
    {
        GetWindow<PluginHelp>("Help");
    }

    void OnGUI()
    {
        if (labelStyle == null)
        {
            labelStyle = new GUIStyle(GUI.skin.label);
            labelStyle.fontSize = (int)labelFontSize;
            labelStyle.normal.textColor = fontColor;
            labelStyle.clipping = TextClipping.Overflow;
            labelStyle.fontStyle = FontStyle.Normal;
        }
        greetStyle = new GUIStyle(GUI.skin.label);
        greetStyle.fontSize = (int)greetFontSize;
        greetStyle.normal.textColor = fontColor;
        greetStyle.clipping = TextClipping.Overflow;
        greetStyle.fontStyle = FontStyle.Normal;

        EditorGUI.DrawRect(new Rect(0, 0, position.width, position.height), backgroundColor);
        GUILayout.Space(15);
        GUILayout.Label("�����÷����� Version 0.1 \n" +
            "ȯ���մϴ�.", greetStyle);
        GUILayout.Space(30);
        GUILayout.Label("�����÷����� ��� : \n" +
            "���� ���Ǽ��� ���� 3D Artist Tool", labelStyle);
        GUILayout.Space(10);
        GUILayout.Label("������ : �輱ȣ", labelStyle);
        GUILayout.Space(10);
        GUILayout.Label("E-Mail : srrsr14@naver.com", labelStyle);
        GUILayout.Space(10);
        GUILayout.Label("���θ����� Ȩ������", labelStyle);
        GUILayout.Space(15);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUILayout.BeginVertical();

        if (GUILayout.Button("���θ�����", GUILayout.Width(200), GUILayout.Height(50)))
        {
            OpenWebPage("https://dainleaders.com/");
        }
        EditorGUILayout.EndVertical();
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
    }

    private void OpenWebPage(string url)
    {
        Process.Start(url);
    }
}
