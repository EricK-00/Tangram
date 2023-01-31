using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TangramLvPart : MonoBehaviour
{
    //private string[] PARTS_IMAGE_NAMES = new string[7] { "Tangram_BigTriangle1", "Tangram_BigTriangle2", " ", " ", " ", " ", " "};

    public PartsType partsType = PartsType.NONE;
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
                partsType = PartsType.TANGRAM_BIG_TRIANGLE;
                break;

            case "Tangram_BigTriangle2":
                partsType = PartsType.TANGRAM_BIG_TRIANGLE;
                break;

            default:
                partsType = PartsType.NONE;
                break;
        }       // switch
    }       //Start()

    // Update is called once per frame
    void Update()
    {
        
    }
}
