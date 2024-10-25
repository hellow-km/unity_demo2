using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearCounter : BaseCounter
{
    [SerializeField] private KitchenObject something;

    public override void interace(Player player)
    {
        if (HasItem())
        {
            if (!player.HasItem())
            {
                player.setItem(getItem());
                getItem().setClearCounter(Player.Instance);
                if (HasPlate())
                {
                    clearPlate();
                }
            }
            else if (player.HasPlate())
            {
                getItem().setPlate(player.getPlate());
                player.clearPlate();
            }
        }
        else
        {
            if (HasPlate())
            {
                if (player.HasItem())
                {
                    player.getItem().setPlate(getPlate());
                    setItem(player.getItem());
                }
                else
                {
                    player.setPlate(getPlate());
                }
                clearPlate();
            }
            else
            {
                if (player.HasItem())
                {
                    setItem(player.getItem());
                    player.getItem().setClearCounter(this);
                    player.clearPlate();
                }
                else if (player.HasPlate())
                {
                    setPlate(player.getPlate());
                    player.clearPlate();
                }
            }

        }
    }

    public void playerHandle()
    {

    }

    public void setKitchenObj(KitchenObject _kitchenObject)
    {
        something = _kitchenObject;
    }

    public KitchenObject getKitchenObj()
    {
        return something;
    }

    public bool HasKitchenObj()
    {
        return something != null;
    }

    public void ClearKitchenObj()
    {
        something = null;
    }

    public override CounterType getCounterType()
    {
        return CounterType.clearCounter;
    }
}
