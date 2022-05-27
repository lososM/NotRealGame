using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExecuteLightMethods : MonoBehaviour
{
    public const string ENTERLIGHT = "EnterLight";
    public const string EXITLIGHT = "ExitLight";

    public static List<Transform> LastHits = new List<Transform>();
    public static List<Transform> HaveHits = new List<Transform>();
    
    void LateUpdate()
    {
        foreach (var lastHit_item in LastHits)
        {
            if(!HaveHits.Contains(lastHit_item))
            {
                HaveHits.Add(lastHit_item);
                lastHit_item.transform.SendMessageUpwards(ENTERLIGHT, SendMessageOptions.DontRequireReceiver);
            }
        }

        foreach (var haveHit_item in HaveHits.ToList())
        {
            if (!LastHits.Contains(haveHit_item))
            {
                HaveHits.Remove(haveHit_item);
                haveHit_item.transform.SendMessage(EXITLIGHT, SendMessageOptions.DontRequireReceiver);
            }
        }
        LastHits.Clear();
    }
    private void OnLevelWasLoaded(int level)
    {
        LastHits.Clear();
        HaveHits.Clear();
    }
}