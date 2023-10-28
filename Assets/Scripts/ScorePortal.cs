using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class ScorePortal : MonoBehaviour
{
    private string _action;
    private int _value;
    [SerializeField]private TMP_Text _text;
    private void Awake()
    {
        _action = Operations.AllOperations[Random.Range(0, 5)];
        _value = _action == "^" ? Random.Range(1, 4) : Random.Range(1, 100);
        _text.text = _action + _value;
    }

    public string GetOperation()
    {
        return _action;
    }

    public int GetValue()
    {
        return _value;
    }

    public void ChangeOperation()
    {
        _action = Operations.AllOperations[Random.Range(0, 5)];
        _value = _action == "^" ? Random.Range(1, 3) : Random.Range(1, 100);
        _text.text = _action + _value;
    }
}