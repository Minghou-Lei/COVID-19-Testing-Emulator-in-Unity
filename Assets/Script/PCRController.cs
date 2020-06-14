using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCRController : MonoBehaviour
{
    public string c;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name.Contains(c)) {
            Destroy(other.gameObject);
            text.SetActive(true);
        }
    }
}
