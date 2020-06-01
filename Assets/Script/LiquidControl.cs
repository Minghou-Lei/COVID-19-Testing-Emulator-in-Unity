using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidControl : MonoBehaviour
{
    public float fill;
    public string name;
    private float value;
    public Color color;
    private Renderer liquid;
    // Start is called before the first frame update
    void Start()
    {
        liquid = transform.GetChild(0).GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Range(0.382,0.63) 
        //  .382 full .63 empty
        fill = Mathf.Clamp01(fill);
        value = fill*-0.248f + 0.63f;
        liquid.material.SetFloat("_FillAmount",value);
        color.a=1f;
        liquid.material.SetColor("_Tint",color);
    }
}
