
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AntiStressBallsScriptableObject", order = 1)]

[System.Serializable]
public class AntiStressBallsScriptableObject : ScriptableObject
{
    public OverrideSize overrideSize;
    public float sizeStep;
    public SizesOfBallType[] sizesOfBallTypes;
    public ColorsOfBallType[] colorsOfBallTypes;
    public ColorsMap[] colorMap;
}
[System.Serializable]
public struct OverrideSize
{
    public BallColor color;
    public float size;
}
    [System.Serializable]
public struct SizesOfBallType
{
    public BallType ballType;
    public float minSize;
    public float maxSize;
}
[System.Serializable]
public struct ColorsOfBallType
{
    public BallType ballType;
    public BallColor[] colors;
}
[System.Serializable]
public struct ColorsMap
{
    public BallColor colorKey;
    public Color colorValue;
}




