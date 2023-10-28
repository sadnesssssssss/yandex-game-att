using System;

public class Singleton<T>
{
    public T Instance { get; private set; }

    public void Bind(T instance)
    {
        if (Instance is not null) throw new InvalidOperationException("Instance already exists!");
        Instance = instance;
    }

    public void Unbind()
    {
        Instance = default;
    }
}