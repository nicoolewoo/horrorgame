using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recharge : MonoBehaviour
{
    // Start is called before the first frame update
    public Light pointLight;

    private void Start() {
        pointLight = GetComponent<Light>();
    }

    public void Charge() {
        pointLight.intensity = 2.0f;
    }
}
