using System;

namespace Helpers
{
    [Flags]
    public enum GameState
    {
        Default = 0,
        Playing = 1,
        Pause = 2,
        Finish = 4
    }
}