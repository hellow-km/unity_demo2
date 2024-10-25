using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookCounter : ProgressCounter
{
    private KitchenItem orignFood;
    private KitchenObject targetFood;
    public override event EventHandler<UpdateProgress> handleUpdateProgress;

    public GameObject[] CookingObj;

    private void Update()
    {
        if (isDoing)
        {
            if (!isCoroutineRunning)
            {
                StartCoroutine(incubeProgress());
            }

            if (progress >= GameData.Instance.maxCookProgress)
            {
                progress = 0;
                if (orignFood.kitchenObject.prefabSlice != null)
                {
                    changeItem(orignFood.kitchenObject.prefabSlice);
                }
                else
                {
                    isDoing = false;
                }
            }
        }
    }

    public override void interace(Player player)
    {
        if (player.HasItem())
        {
            if (!HasItem())
            {
                orignFood = player.getItem();
                startCook();
            }
            else
            {
                stopCook();
            }
        }
        else
        {
            if (isDoing)
            {
                stopCook();
            }
            else
            {
                if (HasItem())
                {
                    player.setItem(getItem());
                    getItem().setClearCounter(player);
                }
            }
        }
    }

    private void startCook()
    {
        progress = 0;
        isDoing = true;
        foodColor = orignFood.kitchenObject.color;
        setItem(orignFood);
        orignFood.setClearCounter(this);
        targetFood = orignFood.kitchenObject;
        setCookAnim(false);
    }

    private IEnumerator incubeProgress()
    {
        isCoroutineRunning = true;
        progress += GameData.Instance.cookSpeed;
        yield return new WaitForSeconds(0.03f);
        handleUpdateProgress.Invoke(this, new UpdateProgress() { progress = progress / GameData.Instance.maxCookProgress });
        isCoroutineRunning = false;
    }

    private void stopCook()
    {
        endCook(targetFood);
        progress = 0;
        isDoing = false;
        handleUpdateProgress.Invoke(this, new UpdateProgress() { progress = 0 });
        setCookAnim(false);
    }

    private void setCookAnim(bool flag)
    {
        foreach (GameObject c in CookingObj)
        {
            c.SetActive(flag);
        }
    }

    private void changeItem(KitchenObject kobj)
    {
        orignFood.Destory();
        Transform trans = Instantiate(kobj.prefab, TopPosition);
        if (trans.TryGetComponent<KitchenItem>(out kitchenItem))
        {
            setItem(kitchenItem);
            kitchenItem.setClearCounter(this);
            orignFood = kitchenItem;
            targetFood = kitchenItem.kitchenObject;
            if (orignFood.kitchenObject.prefabSlice == null)
            {
                isDoing = false;
                setCookAnim(false);
            }
        }
    }

    private void endCook(KitchenObject kobj)
    {
        changeItem(kobj);
    }

    public override CounterType getCounterType()
    {
        return CounterType.cookCounter;
    }
}
