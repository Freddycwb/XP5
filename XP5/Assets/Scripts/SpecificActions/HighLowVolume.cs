using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLowVolume : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    private Coroutine _coroutine;
    private float _delay;
    private float _transitionSpeed;
    private float _volume;

    public void SetDelay(float value)
    {
        _delay = value;
    }

    public void SetVolume(float newVolume, float newTransitionSpeed)
    {
        _volume = newVolume;
        _transitionSpeed = newTransitionSpeed;
        if (_coroutine != null)
        {
            StopCoroutine(VolumeRoutine());
        }
        _coroutine = StartCoroutine(VolumeRoutine());
    }

    IEnumerator VolumeRoutine()
    {
        yield return new WaitForSeconds(_delay);
        if (_volume > source.volume)
        {
            for (float i = source.volume; i < _volume; i += Time.deltaTime * _transitionSpeed)
            {
                source.volume = i;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            for (float i = source.volume; i > _volume; i -= Time.deltaTime * _transitionSpeed)
            {
                source.volume = i;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
