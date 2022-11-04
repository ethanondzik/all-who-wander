using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class crystalWalletUI : MonoBehaviour
{
    private TextMeshProUGUI crystalWalletText;
    public int walletQuantity;
    public Wallet playerWallet;
    // Start is called before the first frame update

    public void Awake()
    {
        playerWallet = GameObject.FindGameObjectWithTag("Player").GetComponent<Wallet>();
        crystalWalletText = GetComponent<TextMeshProUGUI>();
    }
    public void Start()
    {
        walletQuantity = playerWallet.quantity;
    }

    // Update is called once per frame
    public void Update()
    {
        //Debug.Log(walletQuantity.ToString());
        crystalWalletText.text = walletQuantity.ToString();
        walletQuantity = playerWallet.quantity;
    }
}
