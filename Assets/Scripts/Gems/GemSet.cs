using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[CreateAssetMenu]
public class GemSet : ScriptableObject
{
    public List<GemData> gems;
    
    private readonly Random _rng = new Random();

    public GemData GetRandomGemData()
    {
        return gems[_rng.Next(gems.Count)];
    }
}