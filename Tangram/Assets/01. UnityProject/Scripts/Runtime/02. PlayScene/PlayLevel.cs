using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour
{
    public int level = 0;
    public List<TangramLvPart> tangramLvParts;

    private const float LV_PART_DISTANCE_LIMIT = 0.2f;

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

    //! 퍼즐 타입을 받아서 해당 타입과 같은 타입의 퍼즐을 리턴하는 함수
    public List<TangramLvPart> GetSameTypeParts(PartsType partsType)
    {
        List<TangramLvPart> sameTypeParts = new List<TangramLvPart>();

        foreach (var part in tangramLvParts)
        {
            if (part.partType.Equals(partsType))
            {
                sameTypeParts.Add(part);
            }
        }

        return sameTypeParts;
    }

    //! 가장 가까운 퍼즐을 찾아주는 함수
    public TangramLvPart GetCloseSameTypePart(PartsType partsType, Vector3 worldPos)
    {
        List<TangramLvPart> sameTypeParts = GetSameTypeParts(partsType);

        float minDistance = float.MaxValue;
        float distance = 0f;
        TangramLvPart result = default;

        int index = 0;

        foreach (var part in sameTypeParts)
        {
            distance = Mathf.Abs((part.transform.position - worldPos).magnitude);
            if (distance <= minDistance)
            {
                minDistance = distance;
                result = part;
            }
            ++index;
        }

        if (LV_PART_DISTANCE_LIMIT < minDistance)
        {
            result = null;
        }       // if: 너무 멀리 있는 퍼즐은 생략

        return result;
    }       // GetCloseSameTypePart()
}
