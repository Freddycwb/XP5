using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioSetter : MonoBehaviour
{
    [SerializeField] private Instantiator instantiator;
    [SerializeField] private AudioClip[] clips;

    [SerializeField] private float volume = 1;
    [SerializeField] private Vector2 minMaxPitch = new Vector2(0.9f, 1.1f);

    [SerializeField] private float delayToLowVolume;
    [SerializeField] private float volumeTransitionSpeed = 1;


    private void Start()
    {
        instantiator.onObjCreated += SetAudio;
    }

    private void SetAudio(GameObject value)
    {
        if (value.GetComponent<AudioSource>() == null)
        {
            return;
        }
        AudioSource source = value.GetComponent<AudioSource>();
        AudioClip currentAudio = clips[Random.Range(0, clips.Length)];
        source.clip = currentAudio;
        source.volume = volume;
        source.pitch = Random.Range(minMaxPitch.x, minMaxPitch.y);
        source.Play();
        if (value.GetComponent<Destroyer>() != null)
        {
            if (delayToLowVolume <= 0)
            {
                value.GetComponent<Destroyer>().Delete(currentAudio.length);
            }
            else
            {
                value.GetComponent<Destroyer>().Delete(delayToLowVolume + (1 * volumeTransitionSpeed));
            }
        }
        HighLowVolume highLowVolume = value.GetComponent<HighLowVolume>();
        if (delayToLowVolume > 0)
        {
            highLowVolume.SetDelay(delayToLowVolume);
            highLowVolume.SetVolume(0, volumeTransitionSpeed);
        }
        if (value.GetComponent<SetParent>() != null && value.transform.parent != null)
        {
            value.GetComponent<SetParent>().enabled = false;
        }
    }
}
