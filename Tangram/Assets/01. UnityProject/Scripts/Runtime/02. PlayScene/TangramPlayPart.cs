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

    //! ���콺 ��ư�� ������ ��
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }

    //! ���콺 ��ư�� ���� ��
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
    }

    //! ���콺�� �巡�� ���� ��
    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked)
        {
            gameObject.AddAnchoredPos(eventData.delta / tangramInitZone.parentCanvas.scaleFactor);

            //Vector2 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
            //rect.position = new Vector3(mousePos.x, mousePos.y, 90);

            GFunc.Log($"���콺 ������ Ȯ��: ({eventData.position}, inputMouse{Input.mousePosition}, ��ġ: {transform.position})");
        }
    }
}