using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderBoardText : MonoBehaviour
{
    public TextMeshProUGUI boardText;
    public BoxCollider boxCol;
    [SerializeField] private bool boxColActive = false;

    void Update()
    {
        //if (Customer walks in & gives order)
        //{
        //    Display order
        //}

        if (boxCol.enabled)
        {
            boxColActive = true;
        }

        if (boxColActive == true)
        {
            DisplayGoodBeansssOrder();
        }
    }

    public void DisplayGoodBeansssOrder()
    {
        boardText.text = "Plain burger\nFries\nDrink";
    }
}
