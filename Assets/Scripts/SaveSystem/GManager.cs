using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    public GameObject player;
    private SaveSystem saveSystem;
    public static Action<GameState> OnGameStateChanged;
    public GameState currentGameState = GameState.Default;

    public void ChangeGameState(GameState state)
    {
        if (currentGameState != state)
        {
            currentGameState = state;
            OnGameStateChanged?.Invoke(state);
        }
    }

    private void Awake()
    {
        //SceneManager.sceneLoaded += Initialize;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel()
    {
        if(saveSystem.LoadedData != null)
        {
            SceneManager.LoadScene(saveSystem.LoadedData.sceneIndex);
            return;
        }
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveData()
    {
        if (player != null)
            saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
