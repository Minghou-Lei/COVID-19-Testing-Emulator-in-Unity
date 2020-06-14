using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLiquid : MonoBehaviour {
    public GameObject pipette;
    public LiquidControl liquidControl;
    // Start is called before the first frame update
    void Start() {
        pipette = GameObject.Find("Pipette");
        liquidControl = GetComponent<LiquidControl>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject == pipette) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                if (liquidControl.fill >= 0.1) {
                    liquidControl.fill = liquidControl.fill - 0.03f;
                    pipette.GetComponent<StorageLiquid>().liquidName = liquidControl.liquidName;
                    pipette.GetComponent<StorageLiquid>().fill += 0.03f;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                if (liquidControl.fill <= 1.0f) {
                    liquidControl.fill = liquidControl.fill + 0.03f;
                    liquidControl.liquidName = pipette.GetComponent<StorageLiquid>().liquidName;
                    pipette.GetComponent<StorageLiquid>().fill -= 0.03f;
                }
            }
        }

    }
}
