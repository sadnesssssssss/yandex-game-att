using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private long _currScore = 1;
    public event Action<long> OnScoreChanged;
    public static readonly Singleton<Player> Singleton = new Singleton<Player>();

    private void Awake()
    {
        Singleton.Bind(this);
        PlayerCollision.OnPortalEnter += OnPortalEnter;
    }

    public long GetScore()
    {
        return _currScore;
    }

    private void OnPortalEnter(string operation, int value)
    {
        _currScore = operation switch
        {
            "-" => _currScore - value,
            "+" => _currScore + value,
            "*" => _currScore * value,
            "/" => _currScore / value,
            "^" => (int)Math.Pow(_currScore, value),
            _ => _currScore
        };
        print(_currScore);
        _currScore = Math.Max(1, _currScore);
        OnScoreChanged?.Invoke(_currScore);
    }
}