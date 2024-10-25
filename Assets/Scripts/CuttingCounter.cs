using System;
using System.Collections;
using UnityEngine;



public class CuttingCounter : ProgressCounter
{
    public override event EventHandler<UpdateProgress> handleUpdateProgress;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public override void interace(Player player)
    {
        if (isDoing)
        {
            stopCutFood();
            return;
        }
        if (player.HasItem())
        {
            if (!HasItem())
            {
                KitchenObject sliceItem = player.getItem().getItemSlice();
                if (sliceItem != null)
                {
                    food = player.getItem();
                    foodColor = player.getItem().kitchenObject.color;
                    startCutFood();
                }
            }
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

    private void Update()
    {
        if (isDoing)
        {
            if (!isCoroutineRunning)
            {
                StartCoroutine(incubeProgress());
            }

            if (progress >= GameData.Instance.maxCutProgress)
            {
                isDoing = false;
                progress = 0;
                if (food != null && food.getItemSlice() != null)
                {
                    endCutFood(food.getItemSlice());
                }
            }
        }
    }

    private IEnumerator incubeProgress()
    {
        isCoroutineRunning = true;
        progress += GameData.Instance.cutSpeed;
        yield return new WaitForSeconds(0.03f);
       
        handleUpdateProgress.Invoke(this, new UpdateProgress() { progress = progress / GameData.Instance.maxCutProgress });
        isCoroutineRunning = false;
    }

    private void stopCutFood()
    {
        isDoing = false;
        progress = 0;
        endCutFood(food.getItem());
        handleUpdateProgress.Invoke(this, new UpdateProgress() { progress = progress / GameData.Instance.maxCutProgress });
    }

    private void startCutFood()
    {
        isDoing = true;
        progress = 0;
        //food.Hide();
        setItem(food);
        food.setClearCounter(this);
        anim.SetBool("Cutting", true);
    }

    private void endCutFood(KitchenObject kobj)
    {
        anim.SetBool("Cutting", false);
        Transform trans = Instantiate(kobj.prefab, TopPosition);
        if (trans.TryGetComponent<KitchenItem>(out kitchenItem))
        {
            setItem(kitchenItem);
            kitchenItem.setClearCounter(this);
        }
        food.Destory();
    }

    public override CounterType getCounterType()
    {
        return CounterType.cuttingCounter;
    }
}
