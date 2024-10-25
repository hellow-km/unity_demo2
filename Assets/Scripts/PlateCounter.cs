using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounter : PlateBaseCounter
{
    public override event EventHandler<UpdateProgress> handleUpdateProgress;
    public int plateCount;

    private void Awake()
    {

    }

    public override void interace(Player player)
    {
        if (plateCount > 0)
        {
            if (!player.getItem() || !player.getItem().HasPlate())
            {
                PlateKitchenItem plate = popPlate().getPlate();
                player.setPlate(plate);
                reducePlate(plate);
            }
        }
    }

    private void Update()
    {
        if (plateCount < GameData.Instance.maxPlateCount)
        {
            if (!isCoroutineRunning)
            {
                StartCoroutine(incubeProgress());
            }

            if (progress >= GameData.Instance.plateMaxProgress)
            {
                instancePlate();
            }
        }
    }

    private IEnumerator incubeProgress()
    {
        isCoroutineRunning = true;
        progress += GameData.Instance.plateAddSpeed;
        yield return new WaitForSeconds(0.03f);
        handleUpdateProgress.Invoke(this, new UpdateProgress() { progress = progress / GameData.Instance.plateMaxProgress });
        isCoroutineRunning = false;
    }

    private void reducePlate(PlateKitchenItem plate)
    {
        plateCount--;
        plateKitchenItem.Remove(plate);
    }

    private void instancePlate()
    {
        plateCount++;
        progress = 0;
        KitchenItem plate = Instantiate(food, TopPosition);
        plate.gameObject.transform.localPosition = new Vector3(0, plateCount * 0.2f, 0);
        addPlate(plate);
    }

    public override CounterType getCounterType()
    {
        return CounterType.PlatesCounter;
    }
}
