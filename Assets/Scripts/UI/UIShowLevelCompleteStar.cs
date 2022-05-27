using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShowLevelCompleteStar : MonoBehaviour
{
    [SerializeField] LevelData _level;
    void Start()
    {
        gameObject.SetActive(LevelStatusSaver.HaveCompleteLevel(_level));
    }
}
