using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerHandler 
{
    private const string DEFAULT = "Default";
    private const string EXIST = "Exist";
    private const string NO_EXIST = "NoExist";
    public static int GetExist()
    {
        return LayerMask.NameToLayer(EXIST);
    }
    public static int GetNoExist()
    {
        return LayerMask.NameToLayer(NO_EXIST);
    }
    public static int GetDefault()
    {
        return LayerMask.NameToLayer(DEFAULT);
    }
}
