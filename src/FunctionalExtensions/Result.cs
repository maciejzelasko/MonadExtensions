namespace FunctionalExtensions
{
    public class Result
    {
        private Result(bool isFailure)
        {
            IsFailure = isFailure;
        }

        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        public static Result Success() => new Result(false);

        public static Result Failure() => new Result(true);
    }
}