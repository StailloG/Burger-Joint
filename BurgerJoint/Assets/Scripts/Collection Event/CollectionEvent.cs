using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

/// <summary>
/// This script can be considered the manager or the "bowl" of the system. It will track  when specific items enter and exit its radius.
/// When all neccessary items are inside the radius, then it will send off a unity event which we can do what ever method we wont with it
/// </summary>
public class CollectionEvent : MonoBehaviour
{
    public List<GameObject> neccessaryItems; //these are all the items we need for the collection
    public List<GameObject> currentItemsInCollection; //leave this empty, this is to see what is currently in the collection

    public UnityEvent OnAllItemsCollected;

    [SerializeField] private LayerMask itemLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(itemLayer.value + " is the one we are looking for");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yo triggered this mf before" + other.gameObject.layer);

        //if item has the layer we want 
        if (other.gameObject.layer != itemLayer) return; 
        Debug.Log("yo triggered this mf after" + other.gameObject.layer);
        //and if the gameobject is the same as the one in neccesaryItems 
        if (!IsGameObjectInNeccesaryItems(other.gameObject)) return; 

        //then we add it to the collection 
        currentItemsInCollection.Add(other.gameObject);

        //if all objects in currentItems is in neccesaryItems, then we send off an event 
        //first we "sort" them, so its easier to check if they are the same
        neccessaryItems.Sort((p1,p2)=>p1.GetInstanceID().CompareTo(p2.GetInstanceID()));
        currentItemsInCollection.Sort((p1,p2)=>p1.GetInstanceID().CompareTo(p2.GetInstanceID()));
        if (IsNeccesaryItemsAndCurrentItemsTheSame())
        {
            OnAllItemsCollected.Invoke();
        }
    }

    private bool IsNeccesaryItemsAndCurrentItemsTheSame()
    {
        if (neccessaryItems.Count != currentItemsInCollection.Count) return false;


        for (int i = 0; i < neccessaryItems.Count; i++)
        {
            if (!GameObject.ReferenceEquals(neccessaryItems[i], currentItemsInCollection[i]))
            {
                return false;
            }
        }

        return true;

    }


    //looping through neccesaryItems, checking if the gameobject is in it
    private bool IsGameObjectInNeccesaryItems(GameObject otherGameObject)
    {
        foreach (var i in neccessaryItems)
        {
            if (GameObject.ReferenceEquals(i, otherGameObject))
                return true;
        }


        return false;
    }

    private void OnTriggerExit(Collider other)
    {
        //if item has the layer we want 
        //and if the gameobject is the same as the ine in neccesaryItems 
        //then we remove it to the collection 
    }
}
