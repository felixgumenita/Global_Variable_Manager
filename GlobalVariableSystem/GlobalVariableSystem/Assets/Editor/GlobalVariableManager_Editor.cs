using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using GlobalVariable;


public class GlobalVariableManager_Editor : EditorWindow
{
    private GlobalVariableManager manager;
    private Vector2 scrollPosition = new Vector2(0, 0);

    [MenuItem("Window/Global Variable Manager")]
    public static void Init()
    {
        GlobalVariableManager_Editor window = GetWindow<GlobalVariableManager_Editor>(typeof(SceneView));
        window.titleContent = new GUIContent
            ("Global Variable Manager", 
            EditorGUIUtility.ObjectContent
            (CreateInstance<GlobalVariableManager>(), 
            typeof(GlobalVariableManager)).image);
    }
    private void OnGUI()
    {
        EditorGUILayout.Space(10);
        GUILayout.BeginHorizontal();
        manager = (GlobalVariableManager)EditorGUILayout.ObjectField(manager, typeof(GlobalVariableManager), true);

        var managerController = FindObjectOfType<ManagerController>();

        if (manager == null)
        {
            var manager = Resources.Load<GlobalVariableManager>("Managers/GlobalVariablaManager");
            if(manager != null) this.manager = manager;
            else 
            {
                if (GUILayout.Button("Create Manager"))
                {
                    GlobalVariableManager asset = CreateInstance<GlobalVariableManager>();
                    AssetDatabase.CreateAsset(asset, "Assets/GlobalVariablaManager.asset");
                    AssetDatabase.SaveAssets();
                    manager = asset;
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginVertical(EditorStyles.helpBox);
                EditorGUILayout.HelpBox("You do not have a Global Variable Manager. Please create a manager or you can drag and drop.", MessageType.Info);
                GUILayout.EndVertical();
                return;
            }
        }
        GUILayout.EndHorizontal();

        if (managerController != null) managerController.globalVariableManager = manager;

        ScrollableList(manager);

        GUILayout.Space(10);

        VariableDetail(manager, manager.SelectedContent);

        GUILayout.Space(5);

        CreateVariable(manager);
    }
    private void CreateVariable(GlobalVariableManager manager)
    {
        EditorGUILayout.HelpBox("Create Variables", MessageType.None);
        GUILayout.BeginVertical(EditorStyles.helpBox);
        GUILayout.BeginVertical(EditorStyles.helpBox);

        GUILayout.BeginHorizontal(EditorStyles.helpBox);
        GUILayout.Label("Variable Name");
        manager.VariableNameLabel = GUILayout.TextField(manager.VariableNameLabel, new GUILayoutOption[]
        {
            GUILayout.MaxWidth(300),
        });
        GUILayout.EndHorizontal();

        GUILayout.Space(5);

        GUILayout.BeginHorizontal(EditorStyles.helpBox);
        GUILayout.Label("Description");
        manager.VariableDescriptionLabel = GUILayout.TextField(manager.VariableDescriptionLabel, new GUILayoutOption[]
        {
            GUILayout.MaxWidth(300),
        });
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        GUILayout.BeginVertical(EditorStyles.helpBox);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Bool"))
        {
            manager.CreateVariable(GlobalVariableManager.VariableType.Bool);
            ResetTextLabels(manager);
        }
        if (GUILayout.Button("Integior"))
        {
            manager.CreateVariable(GlobalVariableManager.VariableType.Integior);
            ResetTextLabels(manager);
        }
        if (GUILayout.Button("String"))
        {
            manager.CreateVariable(GlobalVariableManager.VariableType.String);
            ResetTextLabels(manager);
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Float"))
        {
            manager.CreateVariable(GlobalVariableManager.VariableType.Float);
            ResetTextLabels(manager);
        }
        if (GUILayout.Button("Vector"))
        {
            manager.CreateVariable(GlobalVariableManager.VariableType.Vector);
            ResetTextLabels(manager);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUILayout.EndVertical();
    }
    private void ResetTextLabels(GlobalVariableManager manager)
    {
        manager.VariableNameLabel = "Name";
        manager.VariableDescriptionLabel = "Variable Description";
    }
    private void ScrollableList(GlobalVariableManager manager)
    {
        EditorGUILayout.HelpBox("Variables List", MessageType.None);

        GUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.Height(300));
        EditorGUILayout.BeginHorizontal(GUILayout.Height(300));

        Rect rectPos = EditorGUILayout.GetControlRect();
        Rect rectBox = new Rect(rectPos.x, rectPos.y, rectPos.width, 300);

        Rect wievRect = new Rect(rectBox.x, rectBox.y, rectBox.width, manager.Variables.Count * 30);

        scrollPosition = GUI.BeginScrollView(rectBox, scrollPosition, wievRect, false, true, GUIStyle.none, GUI.skin.verticalScrollbar);
        
        int firstIndex = (int)scrollPosition.y / 400;

        Rect contentButton = new Rect(rectBox.x, firstIndex * 70, rectBox.width - 50, 25);
        Rect deletetButton = new Rect(contentButton.width + 10, contentButton.y, 30, 25);


        for (int i = 0; i <manager.Variables.Count; i++)
        {
            if (i == 0) 
            {
                contentButton.y += 55; 
                deletetButton.y += 55;
            }

            if (GUI.Button(contentButton, $"{i}. {manager.Variables[i].VariableName}"))
            {
                manager.SelectedContent = i;
            }

            if (GUI.Button(deletetButton, "x"))
            {
                manager.Variables.Remove(manager.Variables[i]);
                manager.SelectedContent = 0;
            }

            contentButton.y += 30;
            deletetButton.y += 30;
        }

        GUI.EndScrollView();

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();

    }
    private void VariableDetail(GlobalVariableManager manager, int selection)
    {
        EditorGUILayout.HelpBox("Variable Details", MessageType.None);

        GUILayout.BeginVertical(EditorStyles.helpBox);

        if (manager.Variables.Count != 0)
        {
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical(EditorStyles.helpBox);
            GUILayout.Label("Variable Name");
            manager.Variables[selection].VariableName = GUILayout.TextField(manager.Variables[selection].VariableName);
            GUILayout.EndHorizontal();
            GUILayout.EndHorizontal();
            GUILayout.BeginVertical(EditorStyles.helpBox);
            GUILayout.Label("Variable Descrption");
            manager.Variables[selection].VariableDescription = GUILayout.TextField(manager.Variables[selection].VariableDescription);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Default Value: ");
            if (manager.Variables[selection].VariableType == 0)
            {
                var varBool = manager.Variables[selection] as VariableTypeBool;
                varBool.BoolValue = EditorGUILayout.Toggle(varBool.BoolValue);
            }
            else if (manager.Variables[selection].VariableType == 1)
            {
                var varInt = manager.Variables[selection] as VariableTypeInt;
                varInt.IntValue = EditorGUILayout.IntField(varInt.IntValue);
            }
            else if (manager.Variables[selection].VariableType == 2)
            {
                var varFloat = manager.Variables[selection] as VariableTypeFloat;
                varFloat.FloatValue = EditorGUILayout.FloatField(varFloat.FloatValue);
            }
            else if (manager.Variables[selection].VariableType == 3)
            {
                var varString = manager.Variables[selection] as VariableTypeString;
                varString.StringValue = GUILayout.TextField(varString.StringValue);
            }
            else if (manager.Variables[selection].VariableType == 4)
            {
                var varVector = manager.Variables[selection] as VariableTypeVector;
                GUILayout.Label("X:");
                varVector.X = EditorGUILayout.FloatField(varVector.X);
                GUILayout.Label("Y:");
                varVector.Y = EditorGUILayout.FloatField(varVector.Y);
                GUILayout.Label("Z:");
                varVector.Z = EditorGUILayout.FloatField(varVector.Z);
            }

            GUILayout.EndVertical();
            GUILayout.EndVertical();

            GUILayout.BeginVertical(EditorStyles.helpBox);
            GUILayout.Label($"[Variable ID: {manager.Variables[selection].VariableID}]");
            GUILayout.EndVertical();
        }
        else
        {
            EditorGUILayout.HelpBox("Create a variable", MessageType.Info);
        }

        GUILayout.EndVertical();
    }
}
