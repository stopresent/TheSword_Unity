using UnityEngine;

public class UI_LobbyScene : UI_Scene
{
    #region Enum
    enum Images
    {
        ToGame,
        UpgradeStat,
        UpgradeSkill,
        ExitGame,
    }
    #endregion
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        #region Bind
        BindImage(typeof(Images));
        #endregion

        GetImage((int)Images.ToGame).gameObject.BindEvent(OnClickToGame);
        GetImage((int)Images.UpgradeStat).gameObject.BindEvent(OnClickUpgradeStat);
        GetImage((int)Images.UpgradeSkill).gameObject.BindEvent(OnClickUpgradeSkill);
        GetImage((int)Images.ExitGame).gameObject.BindEvent(OnClickExitGame);

        return true;
    }

    void OnClickToGame()
    {
        Managers.Scene.LoadScene(Define.Scene.Game2Scene);
    }

    void OnClickUpgradeStat()
    {
        //Managers.UI.ShowPopupUI<UI_UpgradeStat>();
    }

    void OnClickUpgradeSkill()
    {
        //Managers.UI.ShowPopupUI<UI_UpgradeSkill>();
    }

    void OnClickExitGame()
    {
        Application.Quit();
    }
}
