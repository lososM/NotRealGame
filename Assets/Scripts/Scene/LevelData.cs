using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Data/Level")]
public class LevelData : ScriptableObject
{
    public string Key;
    public string Name;
    public string SceneName;
}
