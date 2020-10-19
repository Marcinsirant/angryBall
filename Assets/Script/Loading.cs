using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation game = SceneManager.LoadSceneAsync(1);
        yield return new WaitForEndOfFrame();
    }
}
