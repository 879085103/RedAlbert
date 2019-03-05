using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class UnityTool
{
    public static GameObject FindChild(GameObject parent,string childName)
    {
        Transform [] children = parent.GetComponentsInChildren<Transform>();
        bool isFinded = false;
        Transform child = null;
        foreach (Transform t in children)
        {
            if(t.name == childName)
            {
                if(isFinded)
                {
                    Debug.LogWarning("在父物体" + parent + "下存在不止一个" + childName + "子物体");
                }
                isFinded = true;
                child = t;
            }          
        }
        if(isFinded) return child.gameObject;
        return null;
    }

    public static void Attach(GameObject parent,GameObject child)
    {
        child.transform.parent = parent.transform;
        child.transform.localPosition = Vector3.zero;
        child.transform.localScale = Vector3.one;
        child.transform.localEulerAngles = Vector3.zero;
    }
}

