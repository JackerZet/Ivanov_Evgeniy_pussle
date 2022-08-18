using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Puzzle.Audio
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(ParticleSystem))]
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private GameObject _go;
        private AudioSource _as;
        private ParticleSystem _ps;
        private void Awake()
        {
            _as = GetComponent<AudioSource>();
            _ps = GetComponent<ParticleSystem>();
            
        }
        private void Start()
        {           
            _as.Play();
            _ps.Play();
        }
        private void Update()
        {
            if (!_as.isPlaying)
            {
                Destroy(_go);
            }
        }
    }
}
