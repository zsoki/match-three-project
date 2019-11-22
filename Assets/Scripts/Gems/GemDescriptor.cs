using UnityEngine;

[CreateAssetMenu(fileName = "New Gem", menuName = "Gem")] 
public class GemDescriptor : ScriptableObject
{
    public Sprite sprite;
    public GemType type;
}

public enum GemType
{
    Blue, Red, Purple, Yellow, Green
}