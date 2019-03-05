using System;
using System.Collections.Generic;
using System.Text;


public class BattleSceneState : ISceneState
{
    public BattleSceneState(SceneStateController controller) : base("03-BattleScene", controller)
    {
    }



    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }

    public override void StateEnd()
    {
        GameFacade.Instance.Release();
    }

    public override void StateUpdate()
    {
        //游戏结束跳转回主菜单
        if(GameFacade.Instance.IsGameOver)
        {
            Controller.SetState(new MainMenuSceneState(Controller));
        }
        GameFacade.Instance.Update();
    }
}

