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
    private Vector3 clickedItemPosition;
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
    /// <summary>
    /// Das Kind-Objekt des Prefabs, das den Text enthalten soll
    /// </summary>
    private GameObject descriptionText;
    /// <summary>
    /// Der derzeitige Text
    /// </summary>
    private Text currentText;
    /// <summary>
    /// Die Textzeilen, die in das Textobjekt geschrieben werden sollen
    /// </summary>
    public string[] lines;


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

            // mit Hilfe von: https://docs.unity3d.com/ScriptReference/Transform.GetChild.html
            // Speichert das erste Kind-Objekt (der Text in der Beschreibungsbox) in einer Variable
            descriptionText = activeDescription.gameObject.transform.GetChild(0).gameObject;

            // Den derzeitigen Text zwischenspeichern
            currentText = descriptionText.GetComponent<Text>();

            currentText.text = lines[index];

            // Beschreibung nach Klick auf Lupensmybol aktivieren
            activeDescription.SetActive(true);

            // Das klickbare Item wird über den Index ausgewählt
            clickedItem = clickableItems[index];

            // Die Position des geklickten Items ermitteln
            clickedItemPosition = clickedItem.transform.position;

            // mit Hilfe von: https://docs.unity3d.com/ScriptReference/Camera.WorldToScreenPoint.html
            // Die aktive Beschreibung wird mit einem leichten Abstand zum geklickten Item gesetzt
            activeDescription.transform.position = camera.WorldToScreenPoint(clickedItemPosition) + new Vector3(0f, 300f, 0f);
        }
    }
}
