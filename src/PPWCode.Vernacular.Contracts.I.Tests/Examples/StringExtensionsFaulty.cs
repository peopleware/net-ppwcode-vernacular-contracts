// Copyright 2025 by PeopleWare n.v.
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#nullable disable

namespace PPWCode.Vernacular.Contracts.I.Tests.Examples;

public static class StringExtensionsFaulty
{
    public static string RepeatWithBug(this string source, int nr) // <.>
    {
        Contract.Requires(source != null);
        Contract.Requires(nr >= 0);

        string result = string.Empty;
        int i = nr;
        while (i-- >= 0) // <.>
        {
            result += source;
        }

        Contract.Ensures(result.Length == nr * source.Length); // <.>
        return result;
    }
}
