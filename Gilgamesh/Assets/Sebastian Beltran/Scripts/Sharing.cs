using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCreator2D;

public class Sharing : MonoBehaviour
{
    [SerializeField] CharacterViewer enkidu;
    [SerializeField] CharacterViewer shamhat;
    public Color skirtColor;

    public void ShareClothes()
    {
        enkidu.EquipPart(SlotCategory.Skirt, "Fantasy 03", "Fantasy");
        enkidu.SetPartColor(SlotCategory.Skirt, ColorCode.Color1, skirtColor);

        shamhat.EquipPart(SlotCategory.Skirt, "Fantasy 03", "Fantasy");
        shamhat.SetPartColor(SlotCategory.Skirt, ColorCode.Color1, skirtColor);
    }


}
