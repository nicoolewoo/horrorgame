using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightDim : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration = 60.0f; // time in seconds
    public float targetLight = 0.0f; 

    private Light pointLight;
    private float initialLight;
    private bool dim = true;
    private bool battery = false;

    private void Start() {
        pointLight = GetComponent<Light>();
        initialLight = pointLight.intensity;
    }

    private void Update() {
        if (dim) {
            StartCoroutine(DimLights());
        }
    }

    private IEnumerator DimLights() {
        dim = true;
        float elapsedTime = 0.0f;

        while (elapsedTime < duration) {
            float currLight = Mathf.Lerp(initialLight, targetLight, elapsedTime / duration);
            pointLight.intensity = currLight;
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        pointLight.intensity = targetLight;
        dim = false;
    }

}
