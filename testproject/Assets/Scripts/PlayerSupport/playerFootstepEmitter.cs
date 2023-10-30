using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFootstepEmitter : MonoBehaviour
{
    private const float footstepCooldown = 0.1f;
    private static float lastFootstepTime;
    public void ExecuteLeftFootstep()
    {
        if (Time.time - lastFootstepTime >= footstepCooldown)
        {
            EventManager.TriggerEvent<playerFootstepEvent, Vector3>(transform.position);
            lastFootstepTime = Time.time;
        }
    }

    public void ExecuteRightFootstep()
    {
        if (Time.time - lastFootstepTime >= footstepCooldown)
        {
            EventManager.TriggerEvent<playerFootstepEvent, Vector3>(transform.position);
            lastFootstepTime = Time.time;
        }
    }
}
