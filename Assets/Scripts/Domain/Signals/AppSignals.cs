using System;
using System.Collections.Generic;

namespace CookiesClicker.Signals
{
    public class PushAppStateSignal
    {
        public Type Target { get; private set; }
        public object[] Args { get; private set; }

        public PushAppStateSignal(Type target) =>
            Target = target;

        public PushAppStateSignal(Type target, params object[] args)
        {
            Target = target;
            Args = args;
        }

        public KeyValuePair<Type, object[]> ToPair() =>
            new(Target, Args);
    }

    public class PopAppStateSignal { }
}
