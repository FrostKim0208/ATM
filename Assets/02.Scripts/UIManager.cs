using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text cashTxt;
    [SerializeField] TMP_Text balanceTxt;
    [SerializeField] TMP_Text usernameTxt;

    [SerializeField] TMP_InputField depositValue;
    [SerializeField] TMP_InputField withdrawValue;

    [SerializeField] GameObject PopupError;

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    string FormatNumber(int num)
    {
        return string.Format("{0:#,###}",num);
    }

    private void Refresh()
    {
        cashTxt.text = FormatNumber(MoneyManager.Instance.userData.cash);
        balanceTxt.text = FormatNumber(MoneyManager.Instance.userData.balance);
        usernameTxt.text = MoneyManager.Instance.userData.UserName.ToString();
    }

    public void Deposit(int money)
    {
        if(money > MoneyManager.Instance.userData.cash) 
        {
            PopupError.SetActive(true);
            return;
        }
        MoneyManager.Instance.userData.cash -= money;
        MoneyManager.Instance.userData.balance += money;

        Refresh();
    }

    public void Withdraw(int money)
    {
        if (money > MoneyManager.Instance.userData.balance)
        {
            PopupError.SetActive(true);
            return;
        }
        MoneyManager.Instance.userData.cash += money;
        MoneyManager.Instance.userData.balance -= money;

        Refresh();
    }

    public void CustomDeposit()
    {
        Deposit(int.Parse(depositValue.text));
    }

    public void CustomWithdraw()
    {
        Withdraw(int.Parse(withdrawValue.text));
    }

}
