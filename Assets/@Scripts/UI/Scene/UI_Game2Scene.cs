using UnityEngine;

public class UI_Game2Scene : UI_Scene
{
    // TODO
    // 여기서 해야할 일. 랜덤한 몬스터 생성 및 대결.
    // 몬스터 죽으면 골드 획득
    // 이게 재미있을까?
    // Rocket Rats게임과 기존의 TheSword를 섞어보자.
    // 몬스터가 계속 나오고, 플레이어는 공격을 피하면서 공격
    // 몬스터가 죽으면 골드 획득
    // 상점에서 무기 업그레이드
    // 몬스터가 플레이어에게 닿으면 게임 오버
    // 몬스터가 플레이어에게 닿으면 체력 감소
    // 체력이 0이 되면 게임 오버
    // 어떻게 하면 좋을까?
    // gpt야 도와줘
    // 지금 코드를 짜는게 먼저가 아니라 기획이 먼저야
    // 그럼 기획을 먼저 하자
    // 어떻게 다시 만들지?

    public void IhavenoIdea()
    {
        Debug.Log("I have no idea");
        Debug.Log("기분이 너무 안좋아 속이 안좋다. 모든게 역겹다. 재밌는 게임이란 뭘까. 8시네");
    }
    

    #region Enum
    public enum Texts
    {
        
    }

    public enum Buttons
    {

    }

    public enum Images
    {

    }
    public enum GameObjects
    {

    }
    #endregion

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        #region Bind
        BindText(typeof(Texts));
        BindButton(typeof(Buttons));
        BindImage(typeof(Images));
        BindObject(typeof(GameObjects));
        #endregion

        return true;
    }
}
