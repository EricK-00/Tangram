using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TangramPlayPart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
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

        playLevel = GameManager.Instance.gameObjs["Level_1"].GetComponentMust<PlayLevel>();
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
    }

    //! 마우스를 드래그 중일 때
    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked)
        {
            gameObject.AddAnchoredPos(eventData.delta / tangramInitZone.parentCanvas.scaleFactor);

            //Vector2 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
            //rect.position = new Vector3(mousePos.x, mousePos.y, 90);

            GFunc.Log($"마우스 포지션 확인: ({eventData.position}, inputMouse{Input.mousePosition}, 위치: {transform.position})");
        }
    }
}