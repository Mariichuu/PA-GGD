using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Textanzeige : MonoBehaviour
{
    public GameObject[] box;
    public Text[] descriptions;
    public Text textanzeige;
    private GameObject activeBox;
    public GameObject gameManager;

    public void SetDescription(int index)
    {
        if (index >= 0 && index <= descriptions.Length - 1)
            gameObject.SetActive(box[index]);
            
        activeBox = box[index];

        activeBox.GetComponent<Animator>().SetBool("active", true);
        //https://docs.unity3d.com/Packages/com.unity.visualscripting@1.7/manual/vs-variables-reference.html
        //activeBox.transform.position = Variables.Scene(GameManagerInScene).gameObject.ClickedObject.transform.position;
    }
}
