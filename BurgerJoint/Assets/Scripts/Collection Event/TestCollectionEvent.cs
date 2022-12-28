using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///
/// This is the script that is "subscribed" to the collection event. for example we this can be an UI that shows a message when all items are shown
/// </summary>
public class TestCollectionEvent : MonoBehaviour
{
    private CollectionEvent ce;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplaySomeText() //we assign it in the inspector of CollectionEvent, kinda like UI events
    {
        Debug.Log("yo all the items were collected! ");
    }
}
