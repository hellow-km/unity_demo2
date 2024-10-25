using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public override void interace(Player player)
    {
        if (player.HasItem())
        {
            player.getItem().Destory();
        }
    }

    public override CounterType getCounterType()
    {
        return CounterType.trashCounter;
    }
}