using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public SaveSystem saveSystem;
    public static Action<GameState> OnGameStateChanged;
    public GameState currentGameState = GameState.Default;

    public SliderControl sliderControl;

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
        sliderControl.Load();
    }

    public void SaveData()
    {
        if (player != null)
            saveSystem.SaveData(SceneManager.GetActiveScene().buildIndex + 1);
        sliderControl.Save();
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
    }
}
