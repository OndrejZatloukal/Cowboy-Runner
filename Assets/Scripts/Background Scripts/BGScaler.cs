using UnityEngine;
using System.Collections;

public class BGScaler : MonoBehaviour
{
	void Start()
    {
        // Calculate the size of the Camera and fills the Quad with Background Material

        CalculateCameraSize();
    }

    private void CalculateCameraSize()
    {
        var height = Camera.main.orthographicSize * 2f;
        var width = height * Screen.width / Screen.height;

        if (gameObject.name == "Background")
        {
            ScaleTheCameraToPresetValues(height, width);
        }
        else
        { 
            ScaleTheGround();
        }
    }

    private void ScaleTheGround()
    {
        transform.localScale = new Vector3(30f + 3f, 3, 0);
    }

    private void ScaleTheCameraToPresetValues(float height, float width)
    {
        transform.localScale = new Vector3(width, height, 0);
    }
} // BGScaler
