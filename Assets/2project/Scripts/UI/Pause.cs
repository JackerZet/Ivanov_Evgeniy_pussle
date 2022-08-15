using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Pussle.UI
{ 
    public class Pause : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private Button backToMenuBut;
        [SerializeField] private string menu;

        private bool _pause = false;
        void Awake()
        {
            backToMenuBut.onClick.AddListener(() => GoToMenu());
        }      
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)&& !_pause)
            {
                _pause = true;
                pauseMenu.SetActive(_pause);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }           
            else if(Input.GetKeyDown(KeyCode.Escape) && _pause)
            {
                _pause = false;
                pauseMenu.SetActive(_pause);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }                                             
        }
        private void GoToMenu()
        {
            SceneManager.LoadScene(menu);
        }
    }
}
