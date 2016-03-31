using UnityEngine;
using System.Collections;

public class BGScaler : MonoBehaviour {

	void Start () {

		// Calculate the size of the Camera and fills the Quad with Background Material

		var height = Camera.main.orthographicSize * 2f;
		var width = height * Screen.width / Screen.height;

		if (gameObject.name == "Background") {
			transform.localScale = new Vector3 (width, height, 0);
		} else { // Scale The Ground
			transform.localScale = new Vector3 (30f + 3f, 3, 0);
		}
	}
}
