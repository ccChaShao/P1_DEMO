using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ScripteTemplateGenerator : MonoBehaviour
{
    [MenuItem("Assets/Create/Scripte Template/IComponent", priority = 0)]
    public static void CreateIComponentScript()
    {
        // 获取选中路径
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (string.IsNullOrEmpty(path))
        {
            path = "Assets";
        }
        
        // 读取模板内容
        string templatePath = "Assets/Editor/Script Templates/ECS/IComponent.cs.txt";
        string templateText = File.ReadAllText(templatePath);
        
        // 生成脚本文件
        string scriptPath = $"{path}/NewIComponent.cs";
        File.WriteAllText(scriptPath, templateText);
        AssetDatabase.Refresh();
    }
}
