using System;
using UnityEngine;

public class Toolbar : MonoBehaviour
{
    public Slots[] slots;
    public GameObject[] itemObjects;

    public void SetItem(int index)
    {
        foreach (var i in slots)
        {
            if (i.isEmpty && !itemObjects[index].activeSelf)
            {
                itemObjects[index].transform.position = i.slotPosition.position;
                itemObjects[index].SetActive(true);
                itemObjects[index].GetComponent<ItemObject>().actualSlot = i;
                i.isEmpty = false;

                return;
            }
        }

        return;
    }

    [Serializable]
    public class Slots
    {
        public Transform slotPosition;
        public bool isEmpty = true;
    }
}
