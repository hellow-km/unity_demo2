using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CounterType
{
    clearCounter,
    contaionCounter,
    cuttingCounter,
    trashCounter,
    cookCounter,
    PlatesCounter,
    NoSet
}

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    public virtual void interace(Player player) { }
    [SerializeField] protected Transform TopPosition;
    [SerializeField] protected Transform platePostion;
    protected KitchenItem kitchenItem;
    protected PlateKitchenItem plateItem;

    public void ClearItem()
    {
        kitchenItem = null;
    }

    public Transform getTransform()
    {
        return TopPosition;
    }

    public bool HasItem()
    {
        return kitchenItem != null;
    }

    public KitchenItem getItem()
    {
        return kitchenItem;
    }

    public void setItem(KitchenItem item)
    {
        kitchenItem = item;
        if (plateItem != null)
        {
            kitchenItem.setPlate(plateItem);
        }
    }

    public virtual CounterType getCounterType() { return CounterType.NoSet; }

    public virtual void addPlate(KitchenItem PKI)
    {

    }
    public virtual bool hasPlateCount()
    {
        return false;
    }
    public virtual KitchenItem popPlate()
    {
        return null;
    }

    public bool HasPlate()
    {
        return plateItem != null;
    }
    public PlateKitchenItem getPlate()
    {
        return plateItem;
    }
    public void setPlate(PlateKitchenItem PKI)
    {
        if (HasItem())
        {
            getItem().setPlate(PKI);
        }
        else
        {
            plateItem = PKI;
            PKI.transform.SetParent(platePostion);
            PKI.transform.localPosition = Vector3.zero;
        }
    }
    public void clearPlate()
    {
        plateItem = null;
    }
}
