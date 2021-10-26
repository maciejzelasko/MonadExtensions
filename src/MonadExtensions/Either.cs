using System;
using EnsureThat;

namespace MonadExtensions
{
    /// <summary>
    ///     http://hackage.haskell.org/package/category-extras-0.52.1/docs/Control-Monad-Either.html#t:Either
    /// </summary>
    public struct Either<TL, TR>
    {
        private readonly bool _isLeft;
        private readonly TL _left;
        private readonly TR _right;

        public Either(TL left)
        {
            _left = left;
            _isLeft = true;
            _right = default;
        }

        public Either(TR right)
        {
            _right = right;
            _isLeft = false;
            _left = default;
        }

        public T Match<T>(Func<TL, T> leftFunc, Func<TR, T> rightFunc)
        {
            Ensure.That(leftFunc, nameof(leftFunc)).IsNotNull();
            Ensure.That(rightFunc, nameof(rightFunc)).IsNotNull();

            return _isLeft ? leftFunc(_left) : rightFunc(_right);
        }

        public TL LeftOrDefault() => Match(l => l, r => default);

        public TR RightOrDefault() => Match(l => default, r => r);

        public static implicit operator Either<TL, TR>(TL left) => new(left);

        public static implicit operator Either<TL, TR>(TR right) => new(right);
    }
}