using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler interaceEvent;
    [SerializeField] private KitchenObject something;

    public override void interace(Player player)
    {
        if (!player.HasItem())
        {
            Transform trans = Instantiate(something.prefab, TopPosition);
            if (trans.TryGetComponent<KitchenItem>(out kitchenItem))
            {
                player.setItem(kitchenItem);
                kitchenItem.setClearCounter(Player.Instance);
                interaceEvent?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override CounterType getCounterType()
    {
        return CounterType.contaionCounter;
    }
}
