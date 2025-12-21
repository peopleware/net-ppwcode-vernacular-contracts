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

public static class IntArrayExtensionsAssert
{
    /// <summary>
    ///     Find the value of the maximum subarray sum
    ///     in the given <paramref name="values"/> array.
    /// </summary>
    /// <param name="values">
    ///     the given array;
    ///     must not be <c>null</c>
    /// </param>
    /// <returns>
    ///     The value of the maximum subarray when
    ///     <paramref name="values"/> is not empty, and
    ///     <c>null</c> when <paramref name="values"/>
    ///     is empty.
    /// </returns>
    public static int? MaxSubarraySum(this int[] values) // <.>
    {
        Contract.Requires(values != null);

        int? best = null;
        int current = 0;

        foreach (int v in values)
        {
            current += v;

            // update best when sum improved
            if ((best == null) || (current > best))
            {
                best = current;
            }

            // Sanity check: best should never be less than current
            Contract.Assert(best >= current); // <.>

            // sum up till now is negative, then restart
            if (current < 0)
            {
                current = 0;
            }
        }

        Contract.Ensures((best == null) || (values.Length > 0));
        return best;
    }
}
