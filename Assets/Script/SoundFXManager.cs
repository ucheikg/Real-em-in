using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayerSoundFXClip(AudioClip clip, Transform spawnTransform, float volume)
    {
        // spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity, spawnTransform);

        // assign the audioClip
        audioSource.clip = clip;
        // assign volume
        audioSource.volume = volume;

        // play sound clip
        audioSource.Play();

        // get length of sound FX clip
        float clipLength = audioSource.clip.length;

        // destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);

    }
}