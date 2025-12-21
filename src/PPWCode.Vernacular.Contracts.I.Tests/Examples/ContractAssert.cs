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

using NUnit.Framework;

namespace PPWCode.Vernacular.Contracts.I.Tests.Examples;

public class ContractAssert : BaseTest
{
    [Test]
    public void TestAssert_Correct_Empty() // <.>
    {
        int[] values = [];
        int? maxSum = values.MaxSubarraySum();
        Assert.That(maxSum, Is.Null);
    }

    [Test]
    public void TestAssert_Correct_Not_Empty() // <.>
    {
        int[] values = [-5, 7, -1, 8];
        int? maxSum = values.MaxSubarraySum();
        Assert.That(maxSum, Is.Not.Null);
        Assert.That(maxSum, Is.EqualTo(14));
    }

    [Test]
    public void TestAssert_Faulty() // <.>
    {
        int[] values = [-5, 7, -1, 8];
        Assert.Throws<AssertViolation>(
            () =>
            {
                int? sum = values.MaxSubarraySumFaulty();
            },
            "Assert should throw for faulty implementation");
    }
}
