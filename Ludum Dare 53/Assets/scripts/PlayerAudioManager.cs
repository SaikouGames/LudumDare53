using UnityEngine;
using System.Collections;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource engineStart;
    [SerializeField] private AudioSource engineLoop;
    private AudioSource audioSource;

    private void Start()
    {
        engineStart.Play();
        engineLoop.PlayDelayed(engineStart.clip.length-0.01f);
    }

    /*[SerializeField] private AudioClip engineStartClip;
    [SerializeField] private AudioClip engineLoopClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        StartCoroutine(PlayEngineSound());
    }

    IEnumerator PlayEngineSound()
    {
        audioSource.clip = engineStartClip;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = engineLoopClip;
        audioSource.Play();
        audioSource.loop = true;
    }*/
}