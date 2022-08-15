using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.UI
{
    public class MainSettings : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        private void Awake()
        {
            slider.onValueChanged.AddListener(value => AudioListener.volume = value);
        }       
    }
}
