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

using System;
using System.Reflection;

using NUnit.Framework;

namespace PPWCode.Vernacular.Contracts.I.Tests.Examples;

public class ContractAssume : BaseTest
{
    [Test]
    public void TestAssume_Correct() // <.>
    {
        User[] users =
        [
            new User("An"),
            new User("Bob")
        ];
        int totalLength = users.SumNameLength();
        Assert.That(totalLength, Is.EqualTo(5));
    }

    [Test]
    public void TestAssume_Failure() // <.>
    {
        User[] users =
        [
            new User("An"),
            new User("Bob")
        ];
        FieldInfo nameFieldInfo =
            typeof(User)
                .GetField(
                    "_name",
                    BindingFlags.Instance | BindingFlags.NonPublic);
        Contract.Assert(nameFieldInfo != null);
        nameFieldInfo.SetValue(users[0], null); // <.>
        Action lambda =
            () =>
            {
                int totalLength = users.SumNameLength();
            };
        Assert.That(
            lambda,
            Throws.InstanceOf<AssertViolation>(),
            "Assume should throw for broken postcondition");
    }
}
