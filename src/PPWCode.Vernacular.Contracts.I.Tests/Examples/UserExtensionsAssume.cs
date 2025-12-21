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

using System.Linq;

namespace PPWCode.Vernacular.Contracts.I.Tests.Examples;

public static class UserExtensionsAssume
{
    /// <summary>
    ///     Return the sum of the length of the
    ///     name of the given <paramref name="users" />.
    /// </summary>
    /// <param name="users">
    ///     the given array of <see cref="User" />s;
    ///     must not be <c>null</c>
    /// </param>
    /// <returns>
    ///     The sum of the length of the name of the
    ///     given <paramref name="users" />.
    /// </returns>
    public static int SumNameLength(this User[] users) // <.>
    {
        Contract.Requires(users != null);

        int totalLength =
            users
                .Where(u => u != null)
                .Where(u => Contract.Assume(u.Name != null)) // <.>
                .Sum(u => u.Name.Length);

        Contract.Ensures((totalLength == 0) || (users.Length > 0));
        Contract.Ensures((users.Length == 0) || (totalLength > 0));
        return totalLength;
    }
}
