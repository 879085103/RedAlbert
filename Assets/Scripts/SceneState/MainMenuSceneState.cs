using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuSceneState:ISceneState
{
    public MainMenuSceneState(SceneStateController controller):base("02-MainMenuScene",controller)
    {
        Controller = controller;
    }

    private Button mGameStartButton;
    public override void StateStart()
    {
        mGameStartButton = GameObject.Find("GameStart").GetComponent<Button>();
        mGameStartButton.onClick.AddListener(() =>
        {
            Controller.SetState(new BattleSceneState(Controller));
        });
    }
 
   
    public override void StateUpdate()
    {
        
    }

    public override void StateEnd()
    {
        
    }
}

