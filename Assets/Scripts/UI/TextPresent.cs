using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
public class TextPresent : MonoBehaviour
{
    [SerializeField] Text _title;
    [SerializeField] Animator _animator;
    public void ShowLevelName(LevelData level)
    {
        ShowText(level.Name);
        //start animation
    }
    public void ShowText(string text)
    {
        _title.text = text;
        _animator.SetTrigger("Show");
    }
}
