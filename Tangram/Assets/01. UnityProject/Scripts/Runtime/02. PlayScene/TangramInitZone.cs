using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangramInitZone : MonoBehaviour
{
    public Canvas parentCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GFunc.Assert(parentCanvas != null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}