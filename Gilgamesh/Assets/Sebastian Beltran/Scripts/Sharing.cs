using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCreator2D;

public class Sharing : MonoBehaviour
{
    [SerializeField] CharacterViewer enkidu;
    [SerializeField] CharacterViewer shamhat;
    [SerializeField] Part skirt;
    public Color skirtColor;

    public void ShareClothes()
    {
        enkidu.EquipPart(SlotCategory.Skirt, skirt);
        enkidu.SetPartColor(SlotCategory.Skirt, ColorCode.Color1, skirtColor);

        shamhat.EquipPart(SlotCategory.Skirt, skirt);
        shamhat.SetPartColor(SlotCategory.Skirt, ColorCode.Color1, skirtColor);
    }


}
