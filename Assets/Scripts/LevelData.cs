using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : ScriptableObject
{
    public List<LevelItem> levelDataList = new List<LevelItem>();
}

[System.Serializable]
public class LevelItem
{
    public int id;
    public int levelId;
    public int progressId;
    public int createTime;
    public int zombieType;
    public int bornPos;
}
