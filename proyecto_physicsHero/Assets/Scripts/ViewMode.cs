using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewMode : MonoBehaviour
{
    public List<Sprite> images;

    public Image image;

    public void ChangeImage(TypeAction mode)
    {
        image.sprite = images[(int)mode];
    }

    public void ChangeImage(ActionableValue actionable)
    {
        TypeAction Tact = (actionable.value as Character).typeAction;
        image.sprite = images[(int)Tact];
    }
}
