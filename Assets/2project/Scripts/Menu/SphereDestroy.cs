using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDestroy : MonoBehaviour
{
    [SerializeField] private float timeDestroy = 5f;
    private float _timeDestroy;

    private void Start()
    {
        _timeDestroy = Time.time + timeDestroy;
        StartCoroutine(DestroySphere());
    }  
    private IEnumerator DestroySphere()
    {
        while (enabled)
        {
            if (Time.time > _timeDestroy)
            {
                Destroy(gameObject);
                StopCoroutine(DestroySphere());
            }
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
}
