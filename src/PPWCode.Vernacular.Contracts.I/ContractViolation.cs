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
using System.Runtime.Serialization;
#endif

using JetBrains.Annotations;

using PPWCode.Vernacular.Exceptions.IV;

namespace PPWCode.Vernacular.Contracts.I;

#if NETSTANDARD2_0
[Serializable]
#endif
public class ContractViolation : ProgrammingError
{
    private const string FilePathKey = nameof(FilePathKey);
    private const string MemberNameKey = nameof(MemberNameKey);
    private const string LineNumberKey = nameof(LineNumberKey);

    public ContractViolation(
        [NotNull] string message,
        string filePath,
        string memberName,
        int? lineNumber)
        : base(message)
    {
        FilePath = filePath;
        MemberName = memberName;
        LineNumber = lineNumber;
    }

#if NETSTANDARD2_0
    protected ContractViolation(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
#endif

    public string FilePath
    {
        get => (string)Data[FilePathKey];
        private set => Data[FilePathKey] = value;
    }

    public string MemberName
    {
        get => (string)Data[MemberNameKey];
        private set => Data[MemberNameKey] = value;
    }

    public int? LineNumber
    {
        get => (int?)Data[LineNumberKey];
        private set => Data[LineNumberKey] = value;
    }
}
