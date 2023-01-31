using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TangramPlayPart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public PartsType partType = PartsType.NONE;
    private Image partsImage;

    private bool isClicked;
    private RectTransform rect;
    private TangramInitZone tangramInitZone;
    private PlayLevel playLevel;

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;
        rect = gameObject.GetRect();
        tangramInitZone = transform.parent.gameObject.GetComponentMust<TangramInitZone>();
        playLevel = GameManager.Instance.gameObjs[GData.OBJ_NAME_CURRENT_LEVEL].GetComponentMust<PlayLevel>();

        partsImage = gameObject.FindChildObj("TangramImage").GetComponentMust<Image>();

        switch (partsImage.sprite.name)
        {
            case "Tangram_BigTriangle1":
                partType = PartsType.TANGRAM_BIG_TRIANGLE;
                break;

            case "Tangram_BigTriangle2":
                partType = PartsType.TANGRAM_BIG_TRIANGLE;
                break;

            default:
                partType = PartsType.NONE;
                break;
        }       // switch
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //! 마우스 버튼을 눌렀을 때
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }

    //! 마우스 버튼을 뗐을 때
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;

        TangramLvPart closeLvpart = playLevel.GetCloseSameTypePart(partType, transform.position);

        if (closeLvpart != null)
        {
            transform.position = closeLvpart.transform.position;
            GFunc.Log($"가장 가까운 조각: {closeLvpart.name}");
        }
    }

    //! 마우스를 드래그 중일 때
    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked)
        {
            gameObject.AddAnchoredPos(eventData.delta / tangramInitZone.parentCanvas.scaleFactor);

            //Vector2 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
            //rect.position = new Vector3(mousePos.x, mousePos.y, 90);
        }
    }
}