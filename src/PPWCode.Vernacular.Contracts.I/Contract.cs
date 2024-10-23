// Copyright 2024 by PeopleWare n.v.
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
#if NETSTANDARD2_0 || NET462_OR_GREATER
using JetBrains.Annotations;
#endif

namespace PPWCode.Vernacular.Contracts.I;

#if NETSTANDARD2_0 || NET462_OR_GREATER
[UsedImplicitly]
#endif
[SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local", Justification = "The whole point is to validate conditions")]
public static class Contract
{
    [Conditional("CONTRACTS_PRE")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETSTANDARD2_0 || NET462_OR_GREATER
    [ContractAnnotation("condition: false => halt")]
#endif
    public static void Requires(
#if !(NETSTANDARD2_0 || NETFRAMEWORK)
        [DoesNotReturnIf(false)]
#endif
        bool condition,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        if (!condition)
        {
            throw new PreConditionViolation(
                $"Pre-condition violated in method {memberName} on [{filePath}:{lineNumber}].",
                filePath,
                memberName,
                lineNumber);
        }
    }

    [Conditional("CONTRACTS_POST")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETSTANDARD2_0 || NET462_OR_GREATER
    [ContractAnnotation("condition: false => halt")]
#endif
    public static void Ensures(
#if !(NETSTANDARD2_0 || NETFRAMEWORK)
        [DoesNotReturnIf(false)]
#endif
        bool condition,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        if (!condition)
        {
            throw new PostConditionViolation(
                $"Post-condition violated in method {memberName} on [{filePath}:{lineNumber}].",
                filePath,
                memberName,
                lineNumber);
        }
    }

    [Conditional("CONTRACTS_INVARIANT")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETSTANDARD2_0 || NET462_OR_GREATER
    [ContractAnnotation("condition: false => halt")]
#endif
    public static void Invariant(
#if NET6_0_OR_GREATER
        [DoesNotReturnIf(false)]
#endif
        bool condition,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        if (!condition)
        {
            throw new InvariantViolation(
                $"Invariant violated in method {memberName} on [{filePath}:{lineNumber}].",
                filePath,
                memberName,
                lineNumber);
        }
    }

    [Conditional("CONTRACTS_ASSERT")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETSTANDARD2_0 || NET462_OR_GREATER
    [ContractAnnotation("condition: false => halt")]
#endif
    public static void Assert(
#if NET6_0_OR_GREATER
        [DoesNotReturnIf(false)]
#endif
        bool condition,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        if (!condition)
        {
            throw new AssertViolation(
                $"Assert violated in method {memberName} on [{filePath}:{lineNumber}].",
                filePath,
                memberName,
                lineNumber);
        }
    }

    [Conditional("CONTRACTS_ASSERT")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETSTANDARD2_0 || NET462_OR_GREATER
    [ContractAnnotation("condition: false => halt")]
#endif
    private static void InternalAssert(
#if NET6_0_OR_GREATER
        [DoesNotReturnIf(false)]
#endif
        bool condition,
        string filePath,
        string memberName,
        int lineNumber)
    {
        if (!condition)
        {
            throw new AssertViolation(
                $"Assert violated in method {memberName} on [{filePath}:{lineNumber}].",
                filePath,
                memberName,
                lineNumber);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETSTANDARD2_0 || NET462_OR_GREATER
    [AssertionMethod]
#endif
    public static bool Assume(
#if NETSTANDARD2_0 || NET462_OR_GREATER
        [AssertionCondition(AssertionConditionType.IS_TRUE)]
#endif
#if NET6_0_OR_GREATER
        [DoesNotReturnIf(false)]
#endif
        bool condition,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        InternalAssert(
            condition,
            filePath,
            memberName,
            lineNumber);
        return true;
    }
}
