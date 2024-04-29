using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class AberrationController : MonoBehaviour
{
    #region Inspector
    [Header("Behaviour References"), Space(6)]
    [SerializeField] private Volume globalVolume;

    [Header("Behaviour Variables"), Space(6)]
    [SerializeField, Range(0f, 1f)] private float targetValue;
    [Space(4)]
    [SerializeField, Range(0f, 1f)] private float lerpDuration;
    #endregion

    #region Private Variables
    private ChromaticAberration chromaticAberration;
    private bool toggle;
    #endregion

    #region Default Functions
    private void Start()
    {
        globalVolume.profile.TryGet(out chromaticAberration);
    }
    #endregion

    #region Custom Functions
    public void StartAberration()
    {
        StartCoroutine(AberrationLerp(0f, targetValue));
    }

    public void EndAberration()
    {
        StartCoroutine(AberrationLerp(targetValue, 0f));
    }
    #endregion

    #region Coroutines
    private IEnumerator AberrationLerp(float startValue, float targetValue)
    {
        if (chromaticAberration.intensity.value != targetValue)
        {
            float timeElapsed = 0f;
            float currentValue = startValue;

            while (timeElapsed < lerpDuration)
            {
                float t = timeElapsed / lerpDuration;
                t = t * t;

                currentValue = Mathf.Lerp(startValue, targetValue, t);
                chromaticAberration.intensity.value = currentValue;

                timeElapsed += Time.deltaTime;

                yield return null;
            }

            yield return null;
        }
    }
    #endregion
}