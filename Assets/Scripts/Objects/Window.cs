using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] List<GameObject> _abstcles;
    [SerializeField] OutsideLightObj _outsideLight;
    private void Start()
    {
        _outsideLight.HaveLoad.AddListener( DestroyAbstcles);
    }
    public void EnterLight()
    {
        _outsideLight.StartLoad();
    }
    public void ExitLight()
    {
        _outsideLight.CloseLoad();
    }

    private void DestroyAbstcles()
    {
        if(_abstcles != null)
        {
            foreach (var item in _abstcles)
            {
                if(item.TryGetComponent(out ICoveredOutsideLight cover))
                {
                    cover.Cover();
                }
                else
                {
                    Debug.LogError(item.name + " Haven't interface ICoveredOutsideLight!");
                }
            }
        }
    }
}
