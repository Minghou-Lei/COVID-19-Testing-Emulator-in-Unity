using UnityEngine;

public class Assemble : MonoBehaviour {
	public GameObject combination;
	public float offset = 0.5f;
	private bool hasAssabled = false;
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	private void OnTriggerEnter(Collider other) {

		if (other.gameObject.GetComponent<LiquidControl>() == null) {
			return;
		}
		if (other.gameObject.name.Contains("Filter") && !hasAssabled) {
			hasAssabled = false;
			GameObject c = Instantiate(combination, new Vector3(transform.position.x, transform.position.y + offset, transform.position.z), transform.rotation);

			c.GetComponent<CombinationLiquidController>().setF(other.gameObject.GetComponent<LiquidControl>());
			c.GetComponent<CombinationLiquidController>().setV(transform.gameObject.GetComponent<LiquidControl>());

			Destroy(transform.gameObject);
			Destroy(other.gameObject);

		}


	}
}
