using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
  [SerializeField] private KitchenObjectSO kitchenObjectSo;
  [SerializeField] private Transform counterTopPoint;

  private KitchenObject kitchenObject;
  public void Interact()
  {

    if (kitchenObject == null)
    {
      Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, counterTopPoint);
      kitchenObjectTransform.localPosition = Vector3.zero;
      kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
      kitchenObject.SetClearCounter(this);
    }
    else
    {
      Debug.Log(kitchenObject.GetClearCounter());
    }
    
  }

  public Transform GetKitchenObjectFollowTransform()
  {
    return counterTopPoint;
  }


  public void SetKitchenObject(KitchenObject kitchenObject)
  {
    this.kitchenObject = kitchenObject;
  }

  public KitchenObject GetKitchenObject()
  {
    return kitchenObject;
  }

  public void ClearKitchenObject()
  {
    kitchenObject = null;
  }

  public bool HasKitchenObject()
  {
    return kitchenObject != null;
  }
  
}
