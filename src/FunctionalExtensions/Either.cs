namespace FunctionalExtensions
{
    /// <summary>
    ///     http://hackage.haskell.org/package/category-extras-0.52.1/docs/Control-Monad-Either.html#t:Either
    /// </summary>
    public class Either<TL, TR>
    {
        private readonly bool isLeft;
        private readonly TL left;
        private readonly TR right;

        public Either(TL left)
        {
            this.left = left;
            isLeft = true;
        }

        public Either(TR right)
        {
            this.right = right;
            isLeft = false;
        }

        public static implicit operator Either<TL, TR>(TL left) => new Either<TL, TR>(left);

        public static implicit operator Either<TL, TR>(TR right) => new Either<TL, TR>(right);
    }
}