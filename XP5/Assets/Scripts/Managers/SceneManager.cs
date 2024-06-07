using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private StringVariable currentScene;
    private Coroutine _coroutine;

    private float delay = 1;

    public Action onStartChangeScene;

    private void Start()
    {
        currentScene.Value = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    public void ReloadScene()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(ChangeSceneRoutine(currentScene.Value));
    }

    public void ChangeScene(string scene)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        currentScene.Value = scene;
        _coroutine = StartCoroutine(ChangeSceneRoutine(scene));
    }

    public void ChangeScene(StringVariable scene)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        currentScene.Value = scene.Value;
        _coroutine = StartCoroutine(ChangeSceneRoutine(scene.Value));
    }

    private IEnumerator ChangeSceneRoutine(string scene)
    {
        if (onStartChangeScene != null)
        {
            onStartChangeScene.Invoke();
        }
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
