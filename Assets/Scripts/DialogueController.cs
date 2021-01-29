using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    public GameObject dialogueParent;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;

    private void Start()
    {
        Time.timeScale = 0;
        if (GameController.levelNum==1)
        {
            dialogueParent.SetActive(true);
            return;
        }
        else
        {
            dialogueParent.SetActive(false);
        }

        
    }

    private void Update()
    {
        if (Text1.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Text1.SetActive(false);
                Text2.SetActive(true);
                return;
            }
            return;
        }
        if (Text2.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Text2.SetActive(false);
                Text3.SetActive(true);
                return;
            }
            return;
        }
        if (Text3.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Text3.SetActive(false);
                dialogueParent.SetActive(false);
                Time.timeScale = 1;
                return;
            }
            return;
        }
    }
}
