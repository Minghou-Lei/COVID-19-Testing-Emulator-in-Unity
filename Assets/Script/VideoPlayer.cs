using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class VideoPlayer : MonoBehaviour {
	public VRTK_DestinationMarker pointer;
	public GameObject video;
	private bool isPlayed = false;
	protected virtual void OnEnable() {
		pointer = (pointer == null ? GetComponent<VRTK_DestinationMarker>() : pointer);
		if (pointer == null) {
			pointer = GameObject.Find("RightControllerScriptAlias").GetComponent<VRTK_DestinationMarker>();
		}
		if (pointer != null) {
			pointer.DestinationMarkerEnter += DestinationMarkerEnter;
		}
	}

	protected virtual void OnDisable() {
		if (pointer != null) {
			pointer.DestinationMarkerEnter -= DestinationMarkerEnter;
		}
	}

	protected virtual void DestinationMarkerEnter(object sender, DestinationMarkerEventArgs e) {
		if (e.target == transform && !isPlayed) {
			GameObject v = Instantiate(video, new Vector3(pointer.transform.position.x, pointer.transform.position.y + 0.3f, pointer.transform.position.z), Quaternion.Euler(0, 90, 0), transform);
			v.transform.LookAt(GameObject.Find("Neck").transform);
			v.transform.Rotate(new Vector3(90, 0, 0));
			isPlayed = true;
		}
	}
}
