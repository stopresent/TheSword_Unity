using UnityEngine;
using static Define;

public class Game2Scene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game2Scene;
        Managers.Game.Game2Scene = Managers.UI.ShowSceneUI<UI_Game2Scene>();

        Managers.Game.DirectionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
    }


    public override void Clear()
    {

    }


}
