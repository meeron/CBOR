/*
Written in 2013 by Peter O.
Any copyright is dedicated to the Public Domain.
http://creativecommons.org/publicdomain/zero/1.0/
If you like this, you should donate to Peter O.
at: http://upokecenter.dreamhosters.com/articles/donate-now-2/
 */
using System;

namespace PeterO {
  internal static class BigNumberFlags {
    internal const int FlagNegative = 1;
    internal const int FlagQuietNaN = 4;
    internal const int FlagSignalingNaN = 8;
    internal const int FlagInfinity = 2;
    internal const int FlagSpecial = FlagQuietNaN | FlagSignalingNaN |
    FlagInfinity;

    internal const int FlagNaN = FlagQuietNaN | FlagSignalingNaN;
    internal const int UnderflowFlags = PrecisionContext.FlagInexact |
    PrecisionContext.FlagSubnormal |
                PrecisionContext.FlagUnderflow | PrecisionContext.FlagRounded;

    internal const int LostDigitsFlags = PrecisionContext.FlagLostDigits |
    PrecisionContext.FlagInexact | PrecisionContext.FlagRounded;

    internal const int FiniteOnly = 0;
    internal const int FiniteAndNonFinite = 1;
  }
}