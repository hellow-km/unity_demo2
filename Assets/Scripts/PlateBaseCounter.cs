using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBaseCounter : ProgressCounter
{
    public List<KitchenItem> plateKitchenItem = new List<KitchenItem>();

    public override void addPlate(KitchenItem PKI)
    {
        plateKitchenItem.Add(PKI);
    }
    public override bool hasPlateCount()
    {
        return plateKitchenItem.Count > 0;
    }
    public override KitchenItem popPlate()
    {
        if (plateKitchenItem != null && plateKitchenItem.Count > 0)
        {
            KitchenItem newPKI = plateKitchenItem[plateKitchenItem.Count - 1];
            plateKitchenItem.Remove(newPKI);
            return newPKI;
        }
        else
        {
            return null;
        }
    }
}
