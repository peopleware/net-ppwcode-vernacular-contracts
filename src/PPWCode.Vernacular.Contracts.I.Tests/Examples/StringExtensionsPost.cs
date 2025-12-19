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

public static class StringExtensionsPost
{
    /// <summary>
    ///     Returns a string that is the concatenation of
    ///     <paramref name="nr"/> times the input string
    ///     <paramref name="source"/>.
    /// </summary>
    /// <param name="source">
    ///     the input string; this must not be <c>null</c>
    /// </param>
    /// <param name="nr">
    ///     the number of times that the source string must
    ///     be repeated; this must be a positive number
    /// </param>
    /// <returns>
    ///     A string concatenation of <paramref name="nr"/>
    ///     times the input string <paramref name="source"/>.
    /// </returns>
    /// <remarks>
    ///     The returned value is never <c>null</c>.
    /// </remarks>
    public static string RepeatWithEnsures(this string source, int nr) // <.>
    {
        Contract.Requires(source != null);
        Contract.Requires(nr >= 0);

        string result = string.Empty;
        int i = nr;
        while (i-- > 0)
        {
            result += source;
        }

        Contract.Ensures(result != null);                      // <.>
        Contract.Ensures(result.Length == nr * source.Length); // <.>
        return result;
    }
}
