using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public CanvasGroup nameModalGroup;
    public InputField name1Text;
    public InputField name2Text;
    public WheelCreator WheelCreator;
    private string _name1, _name2;

    public string name1
    {
        get { return _name1; }
    }

    public string name2
    {
        get { return _name2; }
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
        _name1 = PlayerPrefs.GetString("name1");
        _name2 = PlayerPrefs.GetString("name2");
        if (_name1 != "" && _name2 != "")
            disableGroup(nameModalGroup);

        setWheelNames();
    }

    public void OpenNameModal()
    {
        print("Open name modal");
        enableGroup(nameModalGroup);

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
    }

    private void setWheelNames()
    {
        string[] names = new string[6];
        names[0] = _name1;
        names[1] = _name2;
        WheelCreator.setNames(names);
    }
}
