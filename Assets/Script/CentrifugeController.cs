using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrifugeController : MonoBehaviour
{
    public float offset;
    public float offsetV;
    public float duration = 1.0f;
    public Color endColor;
    public Color startColor;
    public List<string> snacks;
    private AudioSource audio;
    private bool rotate = false;
    // Start is called before the first frame update
    void Start() {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        
    }
    private void OnTriggerEnter(Collider other) {
        //startColor = other.GetComponent<LiquidControl>().color;
    }


    private void OnTriggerStay(Collider other) {
        if (other.gameObject.GetComponent<Rigidbody>() == null) {
            return;
        }

        if (other.transform.GetComponent<Rigidbody>().isKinematic && other != null) {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;

            if (other.gameObject.GetComponent<LiquidControl>() != null) {
                other.GetComponent<LiquidControl>().color = Color.Lerp(startColor, endColor, lerp);
                other.transform.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(0, Time.realtimeSinceStartup*1000, 0));
            }
        }

        if (other.gameObject.name.Contains("tube") && Input.GetKeyDown(KeyCode.Space)) {
            audio.Play();
            if (other.gameObject.name.Contains("V")) {
                other.transform.position = new Vector3(transform.position.x, transform.position.y + offsetV, transform.position.z);
            } else {
                other.transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
            }
            other.transform.GetComponent<Rigidbody>().isKinematic = true;         
        }

        if (other.gameObject.name.Contains("tube") && Input.GetKeyUp(KeyCode.Space)) {
            audio.Stop();
            other.transform.GetComponent<Rigidbody>().isKinematic = false;
        }

    }
}
