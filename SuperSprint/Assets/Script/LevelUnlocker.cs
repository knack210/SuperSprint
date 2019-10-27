using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    [SerializeField]
    private GameObject l2Button;
    [SerializeField]
    private GameObject l3Button;
    [SerializeField]
    private Sprite clickableButton;

    void Start()
    {
        if (PlayerPrefs.GetInt("isLevel2") == 1)
        {
            l2Button.GetComponent<Image>().sprite = clickableButton;
            l2Button.transform.Find("greencircle").gameObject.GetComponent<Image>().color = Color.white;
            l2Button.transform.Find("Lock").gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("isLevel3") == 1)
        {
            l3Button.GetComponent<Image>().sprite = clickableButton;
            l3Button.transform.Find("greencircle").gameObject.GetComponent<Image>().color = Color.white;
            l3Button.transform.Find("Lock").gameObject.SetActive(false);
        }

    }

    
    
}
