using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GSingleton<T> : GComponent where T : GSingleton<T>//, new()
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //_instance = GFunc.GetRootObj("GameManager").GetComponentMust<T>();
                _instance = GFunc.CreateObj<T>(typeof(T).ToString());
                DontDestroyOnLoad(_instance.gameObject);
            }       // if: 인스턴스가 비어 있을 때 새로 인스턴스화 한다

            // 여기서부터는 인스턴스가 비어있지 않아야 한다
            return _instance;
        }
    }

    public override void Awake()
    {
        base.Awake();
    }       //Awake()

    public void Create()
    {
        Init();
    }       //Create()

    protected virtual void Init()
    {
        /* Do something */
    }
}
