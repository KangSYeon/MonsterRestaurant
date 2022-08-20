using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount1 : MonoBehaviour
{
    Text text;
    public static int CoinAmount = 1000;


    public Text countText;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = CoinAmount.ToString();
    }
}
