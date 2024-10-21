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

using System;
using System.Collections;

using NUnit.Framework;

namespace PPWCode.Vernacular.Contracts.I.Tests;

public class ContractTests : BaseTest
{
    public static IEnumerable PreConditionCases
    {
        get
        {
            yield return new TestCaseData("12345", "123", "123-12345", false, false);
            yield return new TestCaseData("  1234  ", "1", null, true, false);
            yield return new TestCaseData("12345", " ", null, true, false);
            yield return new TestCaseData(" 123", "1  ", null, true, false);
            yield return new TestCaseData("12345", "12345", null, false, true);
        }
    }

    public string TestMethod(string input, string prefix)
    {
        Contract.Requires(!string.IsNullOrWhiteSpace(input));
        Contract.Requires(!string.IsNullOrWhiteSpace(prefix));
        Contract.Requires(string.Equals(input, input.Trim(), StringComparison.InvariantCulture));
        Contract.Requires(string.Equals(prefix, prefix.Trim(), StringComparison.InvariantCulture));
        Contract.Requires(input.Length < 9);
        Contract.Requires(prefix.Length < 9);

        string result = $"{prefix}-{input}";

        Contract.Ensures(result.Length <= 10);

        return result;
    }

    [Test]
    [TestCaseSource(nameof(PreConditionCases))]
    public void TestPrecondition(string input, string prefix, string result, bool preViolated, bool postViolated)
    {
        if (preViolated)
        {
            Assert.That(
                () => TestMethod(input, prefix),
                Throws.InstanceOf<PreConditionViolation>()
                    .With.Property(nameof(ContractViolation.MemberName)).EqualTo(nameof(TestMethod)),
                "Pre-condition is violated and should throw");
            return;
        }

        if (postViolated)
        {
            Assert.That(
                () => TestMethod(input, prefix),
                Throws.InstanceOf<PostConditionViolation>()
                    .With.Property(nameof(ContractViolation.MemberName)).EqualTo(nameof(TestMethod)),
                "Post-condition is violated and should throw");
            return;
        }

        Assert.That(
            () => TestMethod(input, prefix),
            Is.EqualTo(result));
    }
}
