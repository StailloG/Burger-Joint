using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderBoardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    

    public void NewOrder(RecipeSO recipeSo)
    {
        text.text ="Order 1: " + recipeSo.recipeName;
    }

    public void ClearOrder()
    {
        text.text = "No current orders! ";
    }

}
