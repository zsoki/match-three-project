using UnityEngine;

[CreateAssetMenu]
public class RuntimeSet2D : ScriptableObject
{
    public IntVariable width;
    public IntVariable height;

    private GameObject[,] _matrix;
    private GameObject[,] Matrix => _matrix ?? (_matrix = new GameObject[width.value, height.value]);

    public void Register(GameObject gameObject, int horizontalIndex, int verticalIndex)
    {
        Matrix[horizontalIndex, verticalIndex] = gameObject;
    }
}