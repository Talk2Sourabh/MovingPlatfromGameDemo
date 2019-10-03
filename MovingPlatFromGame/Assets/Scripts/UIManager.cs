using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _coinCountText;
    [SerializeField]
    Text _playerLife;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    
    public void UpdateCoinText( int coinCount)
    {
       
        _coinCountText.text = "Coins : " + coinCount;
    }

    public void UpdateLifeText(int lifes)
    {
        
        _playerLife.text = "Life : " + lifes;
    }
}
