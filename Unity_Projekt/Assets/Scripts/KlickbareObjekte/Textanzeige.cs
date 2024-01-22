using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textanzeige : MonoBehaviour
{
    /// <summary>
    /// Die auszugenden Texte
    /// </summary>
    public GameObject description;
    /// <summary>
    /// Die gerade aktive Beschreibung
    /// </summary>
    private GameObject activeDescription;
    /// <summary>
    /// Das geklickte Item, über dem die Beschreibung erscheinen soll
    /// </summary>
    private GameObject clickedItem;
    /// <summary>
    /// Die Objekte, die geklickt werden können
    /// </summary>
    public GameObject[] clickableItems;
    /// <summary>
    /// Die Position des geklickten Objekts
    /// </summary>
    public Vector3 clickedItemPosition;
    /// <summary>
    /// Referenz zur Main Camera
    /// </summary>
    public Camera mainCamera;
    //mit Hilfe von: https://docs.unity3d.com/ScriptReference/Camera.WorldToScreenPoint.html
    /// <summary>
    /// Die Kamera
    /// </summary>
    private Camera camera;
    /// <summary>
    /// Der Canvas, unter den die Beschreibung gehängt werden soll
    /// </summary>
    public GameObject canvas;
   
    void Start()
    {
        // Kamera-Komponente holen
        camera = mainCamera.GetComponent<Camera>();
        // Beschreibung erst mal deaktivieren
        description.SetActive(false);
    }


    void Update()
    {
        //mit Hilfe von https://discussions.unity.com/t/if-gameobject-is-active/13770
        if (activeDescription != null && activeDescription.active == false)
            Destroy(activeDescription);
    }


    public void SetDescription(int index)
    {
        if (index >= 0 && index <= clickableItems.Length - 1)
        {
            // Die Beschreibung wird instanziert
            activeDescription = Instantiate(description);
            
            // Die Beschreibung wird als Child des Canvas gesetzt
            activeDescription.transform.SetParent(canvas.transform);

            // Beschreibung nach Klick auf Lupensmybol aktivieren
            activeDescription.SetActive(true);
            
            // Diese Beschreibung ist die aktive Beschreibung
            //activeDescription = description; 

            // Das klickbare Item wird über den Index ausgewählt
            clickedItem = clickableItems[index];

            // Die Position des geklickten Items ermitteln
            clickedItemPosition = clickedItem.transform.position;

            // mit Hilfe von: https://docs.unity3d.com/ScriptReference/Camera.WorldToScreenPoint.html
            // Die aktive Beschreibung wird mit einem leichten Abstand zum geklickten Item gesetzt
            activeDescription.transform.position = camera.WorldToScreenPoint(clickedItemPosition) + new Vector3(0f, 200f, 0f);
        }
    }
}
