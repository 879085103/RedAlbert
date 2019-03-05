using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {

    private SceneStateController controller = null;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

	// Use this for initialization
	void Start () {
        controller = new SceneStateController();
        //设置默认状态
        controller.SetState(new StartSceneState(controller),false);
	}
	
	// Update is called once per frame
	void Update () {
        controller.StateUpdate();
	}
}
