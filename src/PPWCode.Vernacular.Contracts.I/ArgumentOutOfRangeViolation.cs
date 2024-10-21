// Copyright 2022 by PeopleWare n.v.
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#if NETSTANDARD2_0
using System;
#endif
using System.Runtime.CompilerServices;
#if NETSTANDARD2_0
using System.Runtime.Serialization;
#endif

using JetBrains.Annotations;

namespace PPWCode.Vernacular.Contracts.I;

#if NETSTANDARD2_0
[Serializable]
#endif
public class ArgumentOutOfRangeViolation : PreConditionViolation
{
    private const string ParameterNameKey = nameof(ParameterNameKey);

    public ArgumentOutOfRangeViolation(
        [NotNull] string parameterName,
        [NotNull] string message,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "",
        [CallerLineNumber] int lineNumber = 0)
        : base(
            message,
            filePath,
            memberName,
            lineNumber)
    {
        ParameterName = parameterName;
    }

#if NETSTANDARD2_0
    protected ArgumentOutOfRangeViolation(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
#endif

    public string ParameterName
    {
        get => (string)Data[ParameterNameKey];
        private set => Data[ParameterNameKey] = value;
    }
}
