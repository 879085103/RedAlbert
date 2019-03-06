using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CampOnClick:MonoBehaviour
{
    private ICamp mCamp;
    public ICamp Camp { set { mCamp = value; } }

    void OnMouseUpAsButton()
    {
        GameFacade.Instance.ShowCampInfo(mCamp);
        //Debug.Log(mCamp.energyCostTrain + mCamp.soldierType);
    }
}

