using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Sign : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
    PlayerControls controls;
    public bool SouthB;

    void Start()
    {
        controls = new PlayerControls();

        controls.Gameplay.SouthB.performed += ctx =>  Debug.Log("pressed");
        controls.Gameplay.SouthB.canceled += ctx => SouthB = false; 
    }


    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space) || SouthB) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            } else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
