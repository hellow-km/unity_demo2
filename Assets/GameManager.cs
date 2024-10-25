using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CounterObj
{
    public CounterType counterType;
    public GameObject prefab;
}

[System.Serializable]
public class MapObject
{
    public CounterType counterType;
    public Vector3 postion;
    public Quaternion rotate;
}


public class GameManager : MonoBehaviour
{
    [SerializeField]
    public List<CounterObj> counterList = new List<CounterObj>();
    public MapObject[] mapList;
    public GameObject map;
    private void Awake()
    {
        init();
    }

    private void init()
    {
        foreach (MapObject mapObject in mapList)
        {

            CounterObj counterObj = counterList.Find((CounterObj counterObj) =>
            {
                return counterObj.counterType == mapObject.counterType;
            });
            if (counterObj != null)
            {
                GameObject obj = Instantiate(counterObj.prefab, Vector3.zero, Quaternion.identity, map.transform);
                obj.transform.localPosition = mapObject.postion;
            }
        }
    }
}
