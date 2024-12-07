using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using OfficeOpenXml;

[InitializeOnLoad]
public class StartUp
{
    static StartUp()
    {
        //Debug.Log("StartUp");
        string path = Application.dataPath + "/Editor/关卡管理.xlsx";
        string assetName = "Level";
         
        FileInfo fileInfo = new FileInfo(path);
        LevelData levelData = (LevelData)ScriptableObject.CreateInstance(typeof(LevelData));


        using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["僵尸"];
            for (int i = worksheet.Dimension.Start.Row + 2; i <= worksheet.Dimension.End.Row; i++)
            {
                LevelItem levelItem = new LevelItem(); 
                Type type = typeof(LevelItem);
               //Debug.Log(worksheet.GetValue(3, 3).ToString()); 
                for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                {
                    //Debug.Log(i + " " + j);
                    //Debug.Log("数据内容 ：" + worksheet.GetValue(i, j));
                    FieldInfo variable = type.GetField(worksheet.GetValue(2, j).ToString()); 
                   
                    string tableValue = worksheet.GetValue(i, j).ToString();
                    variable.SetValue(levelItem, Convert.ChangeType(tableValue, variable.FieldType));
                }
                levelData.levelDataList.Add(levelItem);
            }
        }
        AssetDatabase.CreateAsset(levelData, "Assets/Resources/" + assetName + ".asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
