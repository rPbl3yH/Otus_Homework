using UnityEngine;

[CreateAssetMenu(fileName =nameof(ProgressBarConfig), menuName = "Presentation model/"+ nameof(ProgressBarConfig))]
public class ProgressBarConfig : ScriptableObject
{
    public Sprite DefaultBarSprite;
    public Sprite FillingBarSprite;
}
