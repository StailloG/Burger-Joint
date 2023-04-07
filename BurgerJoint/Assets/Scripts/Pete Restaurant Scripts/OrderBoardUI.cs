using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderBoardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private OrderBoardUIAudio orderBoardUIAudio;

    private void Start()
    {
        orderBoardUIAudio = GetComponent<OrderBoardUIAudio>();
    }

    public void NewOrder(RecipeSO recipeSo)
    {
        text.text ="Order 1: " + recipeSo.recipeName;
        orderBoardUIAudio.PlayNewOrderClip();
    }

    public void ClearOrder()
    {
        text.text = "No current orders! ";
        orderBoardUIAudio.PlayOrderCompleteClip();

    }

}
