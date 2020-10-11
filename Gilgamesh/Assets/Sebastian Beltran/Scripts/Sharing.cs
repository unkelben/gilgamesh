using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCreator2D;
using Fungus;

public class Sharing : MonoBehaviour
{
    [SerializeField] CharacterViewer enkidu;
    [SerializeField] CharacterViewer shamhat;
    [SerializeField] Part skirt;
    [SerializeField] GameObject shareClothes;
    public Flowchart flowchart;

    bool shareButtonActive = false;
    public Color skirtColor;
    public Color shirtColor1;
    public Color shirtColor2;
    public Color pantsColor;
    public Color bootsColor;
    public Color weaponColor1;
    public Color weaponColor2;
    public Color weaponColor3;


    void Update()
    {
        shareButtonActive = flowchart.GetBooleanVariable("shareButtonActive");
        

        if (shareButtonActive == true)
        {
            shareClothes.SetActive(true);
        }
    }


    public void ShareClothes()
    {
        enkidu.EquipPart(SlotCategory.Skirt, skirt);
        enkidu.SetPartColor(SlotCategory.Skirt, ColorCode.Color1, skirtColor);

        shamhat.EquipPart(SlotCategory.Skirt, skirt);
        shamhat.SetPartColor(SlotCategory.Skirt, ColorCode.Color1, skirtColor);

        flowchart.ExecuteBlock("Thank You");
    }

    public void wearManClothes()
    {
        enkidu.EquipPart(SlotCategory.Armor, "Fantasy 01 Male");
        enkidu.SetPartColor(SlotCategory.Armor, shirtColor1, shirtColor2, shirtColor2);

        enkidu.EquipPart(SlotCategory.Pants, "Fantasy 00 Male");
        enkidu.SetPartColor(SlotCategory.Pants, ColorCode.Color1, pantsColor);

        enkidu.EquipPart(SlotCategory.Boots, "Fantasy 00");
        enkidu.SetPartColor(SlotCategory.Boots, ColorCode.Color1, bootsColor);

        enkidu.EquipPart(SlotCategory.OffHand, "Axe 01");
        enkidu.SetPartColor(SlotCategory.OffHand, weaponColor1, weaponColor2, weaponColor3);

        enkidu.EquipPart(SlotCategory.Skirt, "");

    }


}
