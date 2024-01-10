using UnityEngine;
using GoogleSheetsToUnity;
using System.Collections.Generic;
using UnityEditor;

public class SunhokimPlugIn : EditorWindow
{
    private string associatedSheet = "1C1zd5BJMwcOSQBgDgO8BZjzruSRQb_qYnlDcn8yjdJc";
    private string associatedWorksheet = "testSheet";
    private string inputPassword = "";
    private string inputID = "";
    private string nickName = "";
    private bool isAuthenticated = false;
    private float fontSize = 12f;
    private string sampleText = "데모플러그인";
    private string myString = "";
    Color backgroundColor = Color.black;
    Color fontColor = Color.white;
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    private GUIStyle labelStyle;
    private GUIStyle buttonStyle;

    public List<string> Names = new List<string>();

    public delegate void BackgroundColorChangedHandler(Color newColor);
    public static event BackgroundColorChangedHandler OnBackgroundColorChanged;
    public static SunhokimPlugIn Instance { get; private set; }

    [MenuItem("데모 메뉴탭/데모 플러그인")]
    public static void ShowWindow()
    {
        Instance = GetWindow<SunhokimPlugIn>("데모 플러그인 0.1v");
    }
    void OnGUI()
    {
        if (labelStyle == null)
        {
            labelStyle = new GUIStyle(GUI.skin.label);
            labelStyle.fontSize = (int)fontSize;
            labelStyle.normal.textColor = fontColor;
            labelStyle.clipping = TextClipping.Clip;
            labelStyle.fontStyle = FontStyle.Normal;
        }

        if (buttonStyle == null)
        {
            buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontSize = (int)fontSize;
            labelStyle.normal.textColor = fontColor;
            labelStyle.clipping = TextClipping.Clip;
            labelStyle.fontStyle = FontStyle.Normal;
        }

        if (!isAuthenticated)
        {
            GUILayout.Label("아이디를 입력하세요", labelStyle);
            inputID = EditorGUILayout.TextField("ID", inputID);
            GUILayout.Label("패스워드를 입력하세요");
            inputPassword = EditorGUILayout.PasswordField("Password", inputPassword);

            if (GUILayout.Button("Log in"))
            {
                SpreadsheetManager.Read(new GSTU_Search(associatedSheet, associatedWorksheet), (GstuSpreadSheet ss) =>
                {
                    if (ss.rows.ContainsKey(inputID))
                    {
                        string storedPassword = ss.rows[inputID][1].value.ToString();
                        nickName = ss.rows[inputID][2].value.ToString();
                        if (storedPassword == inputPassword)
                            {
                                isAuthenticated = true;
                            }
                            else
                            {
                                EditorUtility.DisplayDialog("인증실패", "ID 혹은 PASSWORD가 틀렸습니다.", "OK");
                            }
                    }
                    else
                    {
                            EditorUtility.DisplayDialog("인증실패", "ID 혹은 PASSWORD가 틀렸습니다.", "OK");
                    }
                });
            }

        }
        else
        {
            EditorGUI.DrawRect(new Rect(0, 0, position.width, position.height), backgroundColor);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.BeginVertical();
            GUILayout.Space(30);
            if (GUILayout.Button("3D 아티스트 플러그인 데모", buttonStyle, GUILayout.Width(200), GUILayout.Height(50)))
            {
                ArtistTool.ShowWindow();
            }
            GUILayout.Space(20);
            if (GUILayout.Button("설정", buttonStyle, GUILayout.Width(200), GUILayout.Height(50)))
            {
                PluginSetting.ShowWindow();
            }
            GUILayout.Space(20);
            if (GUILayout.Button("Help", buttonStyle, GUILayout.Width(200), GUILayout.Height(50)))
            {
                PluginHelp.ShowWindow();
            }
            EditorGUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
        }
    }
    public void SetLabelFontSize(int size)
    {
        fontSize = size;
        if (labelStyle != null)
        {
            labelStyle.fontSize = size;
        }
        Repaint();
    }

    public void SetButtonFontSize(int size)
    {
        fontSize = size;
        if (buttonStyle != null)
        {
            buttonStyle.fontSize = size;
        }
        Repaint();
    }

    public void SetFontColor(Color color)
    {
        fontColor = color;
        if (labelStyle != null)
        {
            labelStyle.normal.textColor = color;
        }
        if (buttonStyle != null)
        {
            buttonStyle.normal.textColor = color;
        }
        Repaint();
    }
    public void SetFontStyle(FontStyle newFontStyle)
    {
        labelStyle.fontStyle = newFontStyle;
        buttonStyle.fontStyle = newFontStyle;
        Repaint();
    }
}