using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{
    public EventSound3D eventSound3DPrefab;
    public AudioClip[] playerFootstepAudio;

    private UnityAction<Vector3> playerFootstepEventListener;

    void Awake()
    {

        playerFootstepEventListener = new UnityAction<Vector3>(playerFootstepEventHandler);

    }

    void Start()
    {



    }
    void OnEnable()
    {

        EventManager.StartListening<playerFootstepEvent, Vector3>(playerFootstepEventListener);

    }

    void OnDisable()
    {

        EventManager.StopListening<playerFootstepEvent, Vector3>(playerFootstepEventListener);

    }

    void playerFootstepEventHandler(Vector3 pos)
    {

        EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);

        snd.audioSrc.clip = this.playerFootstepAudio[Random.Range(0, playerFootstepAudio.Length)];

        snd.audioSrc.minDistance = 5f;
        snd.audioSrc.maxDistance = 100f;
        snd.audioSrc.volume = 0.25f;

        snd.audioSrc.Play();

    }
}
