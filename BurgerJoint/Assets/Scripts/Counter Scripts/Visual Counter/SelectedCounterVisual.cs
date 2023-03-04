using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{

    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;
    
    private void Start()
    {
        PlayerMovement.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;

    }

    private void Player_OnSelectedCounterChanged(object sender, PlayerMovement.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == baseCounter)
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
        foreach (GameObject visualGO in visualGameObjectArray)
        {
            visualGO.SetActive(true);
        }
    }
    
    private void Hide()
    {
        foreach (GameObject visualGO in visualGameObjectArray)
        {
            visualGO.SetActive(false);
        }
    }
}
