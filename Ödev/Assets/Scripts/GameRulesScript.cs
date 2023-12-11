using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.XR.OpenXR.Input;
using JetBrains.Annotations;

public class GameRulesScript : MonoBehaviour
{
    [Header("Cube")]
    public GameObject cubeObject;
    public GameObject cubeSocket;
    public TextMeshProUGUI cubeText;
    [Header("Capsule")]
    public GameObject capsuleObject;
    public GameObject capsuleSocket;
    public TextMeshProUGUI capsuleText;
    [Header("Sphere")]
    public GameObject sphereObject;
    public GameObject sphereSocket;
    public TextMeshProUGUI sphereText;
    [Header("Others")]
    public TextMeshProUGUI correctText;
    public Vector3 cubePos;
    public Vector3 capsulePos;
    public Vector3 spherePos;

    // Update is called once per frame
    private void Awake()
    {
        
    }
    private void Start()
    {

    }
    private void Update()
    {
        CheckIfCorrect(cubeObject, sphereObject, capsuleObject, cubeSocket, cubeText, spherePos, capsulePos);
        CheckIfCorrect(capsuleObject, cubeObject, sphereObject, capsuleSocket, capsuleText, cubePos, spherePos);
        CheckIfCorrect(sphereObject, cubeObject, capsuleObject, sphereSocket, sphereText, cubePos, capsulePos);
    }
    private void CheckIfCorrect(GameObject obj1, GameObject obj2, GameObject obj3, GameObject sockt1, TextMeshProUGUI txt, Vector3 pos2, Vector3 pos3)
    {
        if (sockt1.GetComponent<XRSocketInteractor>().hasSelection)
        {
            if (sockt1.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject == obj1)
            {
                correctText.text = "Dogru";
                correctText.color = Color.blue;
                txt.color = Color.blue;
                obj1.GetComponent<XRGrabInteractable>().enabled = false;
                obj1.GetComponent<Rigidbody>().isKinematic = true;
                obj1.transform.position = sockt1.transform.position;
                sockt1.GetComponent<XRSocketInteractor>().enabled = false;
                
            }
            else if (sockt1.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject == obj2)
            {
                correctText.text = "Yanlis";
                correctText.color = Color.red;
                txt.color = Color.red;
                sockt1.GetComponent<XRSocketInteractor>().interactionManager.SelectExit(sockt1.GetComponent<XRSocketInteractor>(), obj2.GetComponent<IXRSelectInteractable>());
                obj2.transform.position = pos2;
            }
            else if (sockt1.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject == obj3)
            {
                correctText.text = "Yanlis";
                correctText.color = Color.red;
                txt.color = Color.red;
                sockt1.GetComponent<XRSocketInteractor>().interactionManager.SelectExit(sockt1.GetComponent<XRSocketInteractor>(), obj3.GetComponent<IXRSelectInteractable>());
                obj3.transform.position = pos3;
            }
        }
    }
}

   
