using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using System;

public class shopSystem : MonoBehaviour
{
    public TextMeshProUGUI inPocketMeatText;
    public TextMeshProUGUI inPocketWoodText;
    public TextMeshProUGUI normal;

    public int normalMeat = 20;
    public int normalWood = 50;

    public int inPocketMeat;
    public int inPocketWood;

    public bool normalPlaceAble;
    public bool reset;

    private void Start()
    {
        // setting the cost values and inpocket values to standard

        normal.text = normalMeat + " meat\n" +
                      normalWood + " wood";

        inPocketMeatText.text = "Meat: " + inPocketMeat;
        inPocketWoodText.text = "Wood: " + inPocketWood;
    }
    private void Update()
    {
        // if inpocket loot is less than normal tower cost disable button and make placeable false
        if (inPocketMeat < normalMeat || inPocketWood < normalWood)
        {
            if (!reset)
            {
                normalPlaceAble = false;
                reset = true;
            }
        }
        // if inpocket loot is equal or higher than normal tower cost enable button and make placeable true
        else if (inPocketMeat >= normalMeat && inPocketWood >= normalWood && !normalPlaceAble)
        {
            normalPlaceAble = true;
            reset = false;
        }

        normal.text = normalMeat + " meat\n" +
                      normalWood + " wood";
        inPocketMeatText.text = "Meat: " + inPocketMeat;
        inPocketWoodText.text = "Wood: " + inPocketWood;
    }
    public void normalBought()
    {
        // if placeable and clicked on buy button take away amount of meat and wood that the tower cost
        // add 5 meat and 10 wood to the price
        if (normalPlaceAble)
        {
            inPocketMeat -= normalMeat;
            inPocketWood -= normalWood;

            normalMeat += 5;
            normalWood += 10;
        }
    }
}
