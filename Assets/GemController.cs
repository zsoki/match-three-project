using System.Collections;
using UnityEngine;

public class GemController : MonoBehaviour
{

    public float maxSize;
    public float growFactor;

    private float _initialScale;
    private bool _scalingFlag;

    private void Awake()
    {
        _initialScale = transform.localScale.x;
        _scalingFlag = false;
    }
    
    private void OnMouseEnter()
    {
        if (_scalingFlag) return;
        _scalingFlag = true;
        StartCoroutine(ScaleUp());
        _scalingFlag = false;
    }


    private void OnMouseExit()
    {
        if (_scalingFlag) return;
        _scalingFlag = true;
        StartCoroutine(ScaleDown());
        _scalingFlag = false;
    }

    private IEnumerator ScaleUp()
    {
        while(maxSize > transform.localScale.x)
        {
            transform.localScale += growFactor * Time.deltaTime * new Vector3(1, 1, 1);
            yield return null;
        }
    }

    private IEnumerator ScaleDown()
    {
        while(_initialScale < transform.localScale.x)
        {
            transform.localScale -= growFactor * Time.deltaTime * new Vector3(1, 1, 1);
            yield return null;
        }
    }
}
