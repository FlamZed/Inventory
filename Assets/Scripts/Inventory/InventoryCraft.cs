using System.Collections.Generic;
using UnityEngine;

public class InventoryCraft : MonoBehaviour
{
    public Reciple[] listReciples;
    public Transform craftCells;
    public Transform resultCraftCell;

    [System.Serializable]
    public class Reciple // ������ ������
    {
        public Item resultItem; // ��������� ������
        public List<Item> NeededItems; // ����������� �������� ��� ������
    }

    public void CraftItem()
    {
        var items = InventoryManager.Instance.GetItems();
        foreach (var reciple in listReciples)
        {
            var countNeedItem = reciple.NeededItems.Count;
            var countHaveItem = 0;
            foreach (var item in items)
            {
                if (reciple.NeededItems.Contains(item))
                {
                    countHaveItem++;
                }
            }
            if (countNeedItem == countHaveItem)
            {
                InventoryManager.Instance.InventoryListAdd(reciple.resultItem);

                foreach (var item in reciple.NeededItems)
                    InventoryManager.Instance.InventoryListRemove(item);
            }
        }
    }
}