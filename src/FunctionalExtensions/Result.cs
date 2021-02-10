namespace FunctionalExtensions
{
    /// <summary>
    ///     http://hackage.haskell.org/package/result-0.2.6.0/docs/Control-Monad-Trans-Result.html
    /// </summary>
    public struct Result
    {
        private Result(bool isFailure)
        {
            IsFailure = isFailure;
        }

        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        public static Result Success() => new(false);

        public static Result Failure() => new(true);
    }
}