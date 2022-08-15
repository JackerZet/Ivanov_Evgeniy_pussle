using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Puzzle.UI
{
    public class MainMenu : MonoBehaviour
    {            
        [SerializeField] private Button quitBut;
        [SerializeField] private Button[] levelsBut;
        [SerializeField] private string[] gameLevels;
        

        private void Awake()
        {
            Time.timeScale = 1;

            LoadLevel(0);
            LoadLevel(1);
            LoadLevel(2);

            quitBut.onClick.AddListener(QuitGame);
        }       
        private void LoadLevel(int _ind)
        {
            levelsBut[_ind].onClick.AddListener(() => LevelStart(_ind));
        }
        
        private void LevelStart(int _ind)
        {
            SceneManager.LoadScene(gameLevels[_ind]);
        }
        private void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}