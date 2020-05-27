using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SampleExtrace : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject tubePrefab;
    public float offset;
    public VRTK_InteractableObject linkedObject;

    protected virtual void OnEnable() {

        if(linkedObject!=null){
            linkedObject.InteractableObjectUsed += InteractableObjectUsed;
        }

    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        if (linkedObject != null)
            {
                linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
            }
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        GameObject tube = Instantiate(tubePrefab,new Vector3(transform.position.x,transform.position.y+offset,transform.position.z),Quaternion.Euler(0,0,0));
        tube.GetComponent<LiquidControl>().fill = 0.5f;
        tube.GetComponent<LiquidControl>().color = Color.blue;
    }

    void Start()
    {
        linkedObject = GetComponent<VRTK_InteractableObject>();
    }
}