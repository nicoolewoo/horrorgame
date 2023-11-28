using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEventManager : MonoBehaviour
{
    public EventSound3D eventSound3DPrefab;
    public AudioClip[] playerFootstepAudio;
    public AudioClip[] zombieFootstepAudio;
    public AudioClip[] zombieChaseAudio;

    private UnityAction<Vector3> playerFootstepEventListener;
    private UnityAction<Vector3> zombieFootstepEventListener;
    private UnityAction<Vector3> zombieChaseEventListener;

    void Awake()
    {

        playerFootstepEventListener = new UnityAction<Vector3>(playerFootstepEventHandler);
        zombieFootstepEventListener = new UnityAction<Vector3>(zombieFootstepEventHandler);
        zombieChaseEventListener = new UnityAction<Vector3>(zombieChaseEventHandler);

    }

    void Start()
    {



    }
    void OnEnable()
    {

        EventManager.StartListening<playerFootstepEvent, Vector3>(playerFootstepEventListener);
        EventManager.StartListening<zombieFootstepEvent, Vector3>(zombieFootstepEventListener);
        EventManager.StartListening<zombieChaseEvent, Vector3>(zombieChaseEventListener);

    }

    void OnDisable()
    {

        EventManager.StopListening<playerFootstepEvent, Vector3>(playerFootstepEventListener);
        EventManager.StopListening<zombieFootstepEvent, Vector3>(zombieFootstepEventListener);
        EventManager.StopListening<zombieChaseEvent, Vector3>(zombieChaseEventListener);

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
    void zombieFootstepEventHandler(Vector3 pos)
    {

        EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);

        snd.audioSrc.clip = this.zombieFootstepAudio[Random.Range(0, zombieFootstepAudio.Length)];

        snd.audioSrc.minDistance = 1f;
        snd.audioSrc.maxDistance = 35f;
        snd.audioSrc.volume = 0.5f;

        snd.audioSrc.Play();
    }

    void zombieChaseEventHandler(Vector3 pos)
    {

        EventSound3D snd = Instantiate(eventSound3DPrefab, pos, Quaternion.identity, null);

        snd.audioSrc.clip = this.zombieChaseAudio[Random.Range(0, zombieChaseAudio.Length)];

        snd.audioSrc.minDistance = 1f;
        snd.audioSrc.maxDistance = 25f;
        snd.audioSrc.volume = 0.5f;

        snd.audioSrc.Play();
    }
}
