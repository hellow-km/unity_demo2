using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{

    public BaseCounter selectCC;

    public GameObject selected;

    public bool hasThing;

    private void Start()
    {
        Player.Instance.onSelectChange += Instance_onSelectChange;
    }

    private void Instance_onSelectChange(object sender, Player.SelectCounter e)
    {
        if (selectCC == e.CC)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        selected.SetActive(true);
    }

    private void Hide()
    {
        selected.SetActive(false);
    }
}
