using UnityEngine;

public class LobbyScene : BaseScene
{
    public override void Clear()
    {
        
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.LobbyScene;

        Managers.Game.DirectionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
    }

 
}
