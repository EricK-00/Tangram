using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GSingleton<GameManager>
{
    public Dictionary<string, GameObject> gameObjs;

    public override void Awake()
    {
        base.Awake();

        //Create();
    }

    protected override void Init()
    {
        base.Init();

        // 여기서 게임 매니저의 멤버 초기화
        gameObjs = new Dictionary<string, GameObject>();
    }
}