using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        Player.Singleton.Instance.OnScoreChanged += OnScoreUpdate;
        OnScoreUpdate(Player.Singleton.Instance.GetScore());
    }

    private void OnScoreUpdate(long currScore)
    {
        _text.text = currScore.ToString();
    }
}