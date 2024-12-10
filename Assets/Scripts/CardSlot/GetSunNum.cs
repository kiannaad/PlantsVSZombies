using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetSunNum : MonoSingleton<GetSunNum>
{
    private TextMeshProUGUI sunNumText;

    public CardControl[] _cardControls;
    public GameObject CarParent;
    
    private int currentSunNum;

    public int GetSunNumValue;

    private void Awake()
    {
        sunNumText = GetComponent<TextMeshProUGUI>();
        currentSunNum = int.Parse(sunNumText.text);
    }

    private void Update()
    {
        if (UIStartGame.Instance.isReady)
            _cardControls = CarParent.GetComponentsInChildren<CardControl>();
        
          GetSunNumValue = int.Parse(sunNumText.text);
        if (currentSunNum != GetSunNumValue)
        {
            currentSunNum = GetSunNumValue;
            //Debug.Log(currentSunNum);
            foreach (var card in _cardControls)
            {
                card.CheckUse();
            }
        }
        //Debug.Log(GetSunNumValue());
    }

    public void ModifySunUp(int value) => sunNumText.text = (GetSunNumValue + value).ToString();
    
    public void ModifySunDown (int value) => sunNumText.text = ((GetSunNumValue - value) < 0 ? 0 : GetSunNumValue - value).ToString();

}
