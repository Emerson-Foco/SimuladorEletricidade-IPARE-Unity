using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public GameObject[] objectsToEnable;
    public Toolbar.Slots actualSlot;
    private int _index;

    public void ActiveObject()
    {
        if (_index > 0 && _index < objectsToEnable.Length)
        {
            objectsToEnable[_index].SetActive(true);
        }
        
        RemoveItem();
    }

    public void RemoveItem()
    {
        if (actualSlot is not null)
        {
            actualSlot.isEmpty = true;
        }
        
        actualSlot = null;
        gameObject.SetActive(false);
    }
}
