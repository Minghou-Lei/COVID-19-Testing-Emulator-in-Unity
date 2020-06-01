using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLiquidController : MonoBehaviour
{
    public float VtubeLiquid;
    public float FilterLiquid;
    private LiquidControl vtube;
    private LiquidControl filter;
    // Start is called before the first frame update
    void Start()
    {
        LiquidControl[] liquidControls = GetComponentsInChildren<LiquidControl>();
        foreach(LiquidControl l in liquidControls){
            switch(l.name){
                case "vtube":
                    vtube = l;
                    break;
                case "filter":
                    filter = l;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        vtube.fill = VtubeLiquid;
        filter.fill = FilterLiquid;
    }
}
