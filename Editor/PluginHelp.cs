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
        GUILayout.Label("데모플러그인 Version 0.1 \n" +
            "환영합니다.", greetStyle);
        GUILayout.Space(30);
        GUILayout.Label("데모플러그인 기능 : \n" +
            "개발 편의성을 위한 3D Artist Tool", labelStyle);
        GUILayout.Space(10);
        GUILayout.Label("개발자 : 김선호", labelStyle);
        GUILayout.Space(10);
        GUILayout.Label("E-Mail : srrsr14@naver.com", labelStyle);
        GUILayout.Space(10);
        GUILayout.Label("다인리더스 홈페이지", labelStyle);
        GUILayout.Space(15);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUILayout.BeginVertical();

        if (GUILayout.Button("다인리더스", GUILayout.Width(200), GUILayout.Height(50)))
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
