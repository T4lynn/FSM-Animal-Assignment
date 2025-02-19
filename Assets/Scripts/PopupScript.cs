using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PopupScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string typed; 
    // Start is called before the first frame update
    void Start()
    {
        text.text = typed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
