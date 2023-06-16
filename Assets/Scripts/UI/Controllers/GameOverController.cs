using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public static GameOverController instance { get; private set; }

    [SerializeField] private Canvas _gameOverCanvas;
    [SerializeField] AssetReference _sceneToLoad;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        _gameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        AsyncOperationHandle<SceneInstance> loadHandle = Addressables.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Single, activateOnLoad: true);
        loadHandle.Completed += OnSceneLoaded;
    }

    public void OnSceneLoaded(AsyncOperationHandle<SceneInstance> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            // Scene loaded successfully, you can access the loaded scene using handle.Result
            SceneInstance loadedScene = handle.Result;
            Time.timeScale = 1f;

            Debug.Log("Loaded");
        }
        else
        {
            // Failed to load the scene, handle the error
            Debug.LogError($"Failed to load scene: {handle.OperationException}");
        }
    }
}
