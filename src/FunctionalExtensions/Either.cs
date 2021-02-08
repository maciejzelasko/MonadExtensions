using System;
using EnsureThat;

namespace FunctionalExtensions
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
            this._left = left;
            this._isLeft = true;
            this._right = default;
        }

        public Either(TR right)
        {
            this._right = right;
            this._isLeft = false;
            this._left = default;
        }

        public T Match<T>(Func<TL, T> leftFunc, Func<TR, T> rightFunc)
        {
            Ensure.That(leftFunc, nameof(leftFunc)).IsNotNull();
            Ensure.That(rightFunc, nameof(rightFunc)).IsNotNull();

            return this._isLeft ? leftFunc(this._left) : rightFunc(this._right);
        }

        public TL LeftOrDefault() => this.Match(l => l, r => default);

        public TR RightOrDefault() => this.Match(l => default, r => r);

        public static implicit operator Either<TL, TR>(TL left) => new Either<TL, TR>(left);

        public static implicit operator Either<TL, TR>(TR right) => new Either<TL, TR>(right);
    }
}