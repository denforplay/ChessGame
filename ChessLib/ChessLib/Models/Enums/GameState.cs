namespace ChessLib.Models.Enums
{
    /// <summary>
    /// Game states
    /// </summary>
    public enum GameState
    {
        ACTIVE_GAME,
        WHITE_UNDER_CHECK,
        BLACK_UNDER_CHECK,
        BLACK_UNDER_MATE,
        WHITE_UNDER_MATE
    }
}
