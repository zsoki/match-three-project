using System.Collections;
using UnityEngine;

public class MouseHoverScaling : MonoBehaviour
{
    public float maxSize;
    public float growFactor;

    private float _initialScale;
    private bool _scaleUp;
    private bool _scaleDown;

    private void Awake()
    {
        _initialScale = transform.localScale.x;
    }
    
    private void OnMouseEnter()
    {
        StartCoroutine(ScaleUp());
    }


    private void OnMouseExit()
    {
        StartCoroutine(ScaleDown());
    }

    private IEnumerator ScaleUp()
    {
        _scaleUp = true;

        if (_scaleDown)
        {
            StopCoroutine(ScaleDown());
            _scaleDown = false;
        }
        
        while(!_scaleDown && maxSize > transform.localScale.x)
        {
            transform.localScale += growFactor * Time.deltaTime * new Vector3(1, 1, 1);
            yield return null;
        }
        _scaleUp = false;
    }

    private IEnumerator ScaleDown()
    {
        _scaleDown = true;

        if (_scaleUp)
        {
            StopCoroutine(ScaleUp());
            _scaleUp = false;
        }
        
        while(!_scaleUp && _initialScale < transform.localScale.x)
        {
            transform.localScale -= growFactor * Time.deltaTime * new Vector3(1, 1, 1);
            yield return null;
        }
        _scaleDown = false;
    }
}
