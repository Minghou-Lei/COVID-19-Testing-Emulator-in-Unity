using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLiquidController : MonoBehaviour
{  
    public LiquidControl vtube;
    public LiquidControl filter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setV(LiquidControl l) {
        vtube.color = l.color;
        vtube.fill = l.fill;
        vtube.liquidName = l.liquidName;
    }

    public void setF(LiquidControl l) {
        filter.color = l.color;
        filter.fill = l.fill;
        filter.liquidName = l.liquidName;
    }


}
