using UnityEngine;

[CreateAssetMenu]
public class RuntimeSet2D : ScriptableObject
{
    public IntVariable width;
    public IntVariable height;

    private GameObject[,] _matrix;

    private void Awake()
    {
        _matrix = new GameObject[width.value, height.value];
    }

    public void Register(GameObject gameObject, int horizontalIndex, int verticalIndex)
    {
        // TODO nullpointer
        _matrix[horizontalIndex, verticalIndex] = gameObject;
    }
}