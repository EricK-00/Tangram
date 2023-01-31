using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour
{
    public int level = 0;
    public List<TangramLvPart> tangramLvParts;

    private void Awake()
    {
        GameManager.Instance.gameObjs.Add(gameObject.name, gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        tangramLvParts = new List<TangramLvPart>();
        for (int i  = 0; i < transform.childCount; i++)
        {
            tangramLvParts.Add(transform.GetChild(i).gameObject.GetComponentMust<TangramLvPart>());
        }       // loop: 레벨 하위에서 퍼즐 파츠를 모두 캐싱
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
