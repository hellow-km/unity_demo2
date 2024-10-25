using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Custom attribute to mark fields as read-only
public class UpdateProgress : EventArgs
{
    public float progress;
}

public class ProgressCounter : BaseCounter
{
    public virtual event EventHandler<UpdateProgress> handleUpdateProgress;
    public float progress = 0;


    public Color foodColor = new Color(255, 214, 92, 255);
    public bool isDoing;
    public KitchenItem food;
    public bool isCoroutineRunning = false;
}
