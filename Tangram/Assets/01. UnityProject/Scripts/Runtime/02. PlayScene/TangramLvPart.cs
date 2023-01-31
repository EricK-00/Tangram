using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TangramLvPart : MonoBehaviour
{
    public PartsType partType = PartsType.NONE;
    private Image partsImage;
    private PlayLevel playLevel;


    // Start is called before the first frame update
    void Start()
    {
        partsImage = gameObject.FindChildObj("TangramImage").GetComponentMust<Image>();
        playLevel = transform.parent.gameObject.GetComponentMust<PlayLevel>();

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
    }       //Start()

    // Update is called once per frame
    void Update()
    {
        
    }
}
