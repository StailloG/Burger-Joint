using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderBoardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;


    public void NewOrder()
    {
        text.text = "TEESTING NEW ORDER CUSTOMER WOOOOOOO";
    }

}
