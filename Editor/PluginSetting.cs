using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PluginSetting : EditorWindow
{
    private SunhokimPlugIn sunhokimPlugin;

    private int newTextSize = 12;
    private Color newTextColor = Color.white;
    private bool isFontStyleBold = false;
    private bool isFontStyleItalic = false;
    public Color backgroundColor;


    public static void ShowWindow()
    {
        GetWindow<PluginSetting>("설정");
    }

    void OnGUI()
    {
        GUILayout.Label("텍스트 변경 옵션", EditorStyles.boldLabel);
        if (sunhokimPlugin == null)
        {
            sunhokimPlugin = SunhokimPlugIn.Instance;
        }
        newTextSize = EditorGUILayout.IntSlider("텍스트 사이즈", newTextSize, 20, 40);
        newTextColor = EditorGUILayout.ColorField("텍스트 색상", newTextColor);
        isFontStyleBold = EditorGUILayout.Toggle("볼드", isFontStyleBold);
        isFontStyleItalic = EditorGUILayout.Toggle("이태릭", isFontStyleItalic);
        if (GUILayout.Button("폰트 스타일 적용"))
        {
            if (sunhokimPlugin != null)
            {
                sunhokimPlugin.SetLabelFontSize(newTextSize);
                sunhokimPlugin.SetButtonFontSize(newTextSize - 10);
                sunhokimPlugin.SetFontColor(newTextColor);
                FontStyle fontStyle = FontStyle.Normal;
                if (isFontStyleBold)
                {
                    fontStyle |= FontStyle.Bold;
                }
                if (isFontStyleItalic)
                {
                    fontStyle |= FontStyle.Italic;
                }
                sunhokimPlugin.SetFontStyle(fontStyle);
            }
        }
    }
}
