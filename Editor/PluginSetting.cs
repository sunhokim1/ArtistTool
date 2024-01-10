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
        GetWindow<PluginSetting>("����");
    }

    void OnGUI()
    {
        GUILayout.Label("�ؽ�Ʈ ���� �ɼ�", EditorStyles.boldLabel);
        if (sunhokimPlugin == null)
        {
            sunhokimPlugin = SunhokimPlugIn.Instance;
        }
        newTextSize = EditorGUILayout.IntSlider("�ؽ�Ʈ ������", newTextSize, 20, 40);
        newTextColor = EditorGUILayout.ColorField("�ؽ�Ʈ ����", newTextColor);
        isFontStyleBold = EditorGUILayout.Toggle("����", isFontStyleBold);
        isFontStyleItalic = EditorGUILayout.Toggle("���¸�", isFontStyleItalic);
        if (GUILayout.Button("��Ʈ ��Ÿ�� ����"))
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
