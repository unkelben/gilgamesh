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

    void Update()
    {
        shareButtonActive = flowchart.GetBooleanVariable("shareButtonActive");
        

        if (shareButtonActive == true)
        {
            shareClothes.SetActive(true);
        } else
        {
            shareClothes.SetActive(false);
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
}
