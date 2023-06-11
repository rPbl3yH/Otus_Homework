using UnityEngine;

[CreateAssetMenu(fileName = nameof(InteractableButtonConfig), menuName = "Presentation model/" + nameof(InteractableButtonConfig))]
public class InteractableButtonConfig : ScriptableObject
{
    public Sprite InteractableSprite;
    public Sprite NonInteractableSprite;
}
