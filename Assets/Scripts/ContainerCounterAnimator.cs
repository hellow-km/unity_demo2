using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterAnimator : MonoBehaviour
{
    string OpenClose = "OpenClose";
    [SerializeField] private ContainerCounter containerCounter;
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        containerCounter.interaceEvent += ContainerCounter_interaceEvent;
    }

    private void ContainerCounter_interaceEvent(object sender, System.EventArgs e)
    {
        anim.SetTrigger(OpenClose);
    }
}
