using System;

public class Singleton<T> where T : class, new()
{
    protected Singleton() { }

    private sealed class SingletonCreator<S> where S : class, new()
    {
        private static readonly Lazy<S> lazy = new Lazy<S>(() => new S());

        public static S CreatorInstance
        {
            get { return lazy.Value; }
        }
    }

    public static T Instance
    {
        get { return SingletonCreator<T>.CreatorInstance; }
    }

}