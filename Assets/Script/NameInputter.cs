using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NameInputter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMP;

    private List<char> characters = new List<char>();

    KeyCode? _result;
    private KeyCode? Key => _result;

    private GameSettings _settings;

    // Start is called before the first frame update
    void Start()
    {
        _settings = GameObject.Find("[GameSettings]").GetComponent<GameSettings>();
    }

    // Update is called once per frame
    void Update()
    {
        string text = string.Empty;
        foreach (char c in characters)
        {
            text = text + c;
        }
        TMP.text = text;


        if (Input.anyKeyDown)
        {
            foreach (var item in Enum.GetValues(typeof(KeyCode)))
            {
                var key = (KeyCode)item;
                if (Input.GetKeyDown(key))
                {
                    _result = key;
                    if (_result.ToString().ToCharArray().Length > 1)
                    {
                        if (_result == KeyCode.Backspace)
                        {
                            DeletePress();
                        }
                        if (_result == KeyCode.Return)
                        {
                            EnterPress();
                        }
                    }
                    else
                    {
                        CharPress(_result.ToString());
                    }
                    
                    break;
                }
            }
        }
    }


    public void CharPress(string letter)
    {
        foreach (char c in letter.ToCharArray())
        {
            characters.Add(c);
        }
    }

    public void DeletePress()
    {
        if (characters.Count <= 0) return;
        
        characters.RemoveAt(characters.Count - 1);
    }

    public void EnterPress()
    {
        if (TMP.text ==  null) return;

        _settings.SetPlayerName(TMP.text);
        int i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(i + 1);
    }
}
