using UnityEngine;

public class GemController : MonoBehaviour
{
    public GemSet gemSet;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = gemSet.GetRandomGemData().sprite;
    }
}
