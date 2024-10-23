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

#if NETSTANDARD2_0 || NET462_OR_GREATER
using System;
using System.Runtime.Serialization;

using JetBrains.Annotations;
#else
using System.Diagnostics.CodeAnalysis;
#endif

namespace PPWCode.Vernacular.Contracts.I;

#if NETSTANDARD2_0 || NET462_OR_GREATER
[Serializable]
#endif
public class PostConditionViolation : ContractViolation
{
    public PostConditionViolation(
#if NETSTANDARD2_0 || NET462_OR_GREATER
        [NotNull]
#else
        [DisallowNull]
#endif
        string message,
        string filePath,
        string memberName,
        int? lineNumber)
        : base(
            message,
            filePath,
            memberName,
            lineNumber)
    {
    }

#if NETSTANDARD2_0 || NET462_OR_GREATER
    protected PostConditionViolation(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
#endif
}
