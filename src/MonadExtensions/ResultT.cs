namespace MonadExtensions
{
    public record Result<TValue>
    {
        public Result(TValue value, bool isFailure)
        {
            Value = value;
            IsFailure = isFailure;
        }

        public TValue Value { get; }

        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        public static Result<TValue> Success(TValue value) => new(value, false);

        public static Result<TValue> Failure(TValue value) => new(value, true);
    }
}