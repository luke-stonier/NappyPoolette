using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public CanvasGroup nameModalGroup;
    public CanvasGroup spinTheWheelGroup;
    public CanvasGroup beforeSpinGroup;
    public InputField name1Text;
    public InputField name2Text;
    public WheelCreator WheelCreator;
    public Text coinCountText;
    public GameObject splat;
    private string _name1, _name2;
    private int _coins;

    public string name1
    {
        get { return _name1; }
    }

    public string name2
    {
        get { return _name2; }
    }

    public int coins
    {
        get { return _coins; }
    }

    private void enableGroup(CanvasGroup group)
    {
        group.alpha = 1;
        group.blocksRaycasts = true;
        group.interactable = true;
    }

    private void disableGroup(CanvasGroup group)
    {
        group.alpha = 0;
        group.blocksRaycasts = false;
        group.interactable = false;
    }

    public void Start()
    {
        try
        {
            _name1 = PlayerPrefs.GetString("name1");
            _name2 = PlayerPrefs.GetString("name2");
            _coins = PlayerPrefs.GetInt("Coins");
            if (_name1 != "" && _name2 != "")
                disableGroup(nameModalGroup);

            //setWheelNames();
            //setCoinCount();
        }
        catch (Exception ex)
        {
            print(ex);
        }
    }

    public void OpenNameModal()
    {
        print("Open name modal");
        enableGroup(nameModalGroup);
        hideSpinButton();

        name1Text.text = name1;
        name2Text.text = name2;
    }

    public void SavePlayerNames()
    {
        print("close name modal");

        _name1 = name1Text.text;
        _name2 = name2Text.text;
        PlayerPrefs.SetString("name1", _name1);
        PlayerPrefs.SetString("name2", _name2);

        disableGroup(nameModalGroup);
        setWheelNames();
        showSpinButton();
    }

    private void setWheelNames()
    {
        try
        {
            string[] names = new string[6];
            names[0] = _name1;
            names[1] = _name2;
            WheelCreator.setNames(names);
        }
        catch (Exception ex)
        {
            print(ex);
        }
    }

    public void hideSpinButton()
    {
        disableGroup(spinTheWheelGroup);
    }

    public void showSpinButton()
    {
        enableGroup(spinTheWheelGroup);
    }

    public void hideMenu()
    {
        disableGroup(beforeSpinGroup);
    }

    private void setCoinCount()
    {
        PlayerPrefs.SetInt("Coins", coins);
        coinCountText.text = coins.ToString();
    }

    public void ShowSplat(string name)
    {
        var s = splat.GetComponent<Splat>();
        s.SetName(name);
        StartCoroutine(slideTimeout());
    }

    private IEnumerator slideTimeout()
    {
        yield return new WaitForSeconds(5);
        var s = splat.GetComponent<Splat>();
        s.clear();
        showSpinButton();
        enableGroup(beforeSpinGroup);
    }
}
