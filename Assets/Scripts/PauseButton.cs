using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Helpers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Buttons
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        public void ChangeTheGameState()
        {
            gameManager.ChangeGameState(GameState.Pause);
        }

        public void Continue()
        {
            DOTween.KillAll();
            gameObject.SetActive(false);
            gameManager.ChangeGameState(GameState.Playing);
        }

        public void MainMenu()
        {
            DOTween.KillAll();
            SceneManager.LoadScene(0);
        }
        
        public void OnEnable()
        {
            EnableAnimation();
        }

        public void EnableAnimation()
        {
            gameObject.transform.DOScale(Vector3.one, 0.5f).From(Vector3.zero);
        }

    }
}