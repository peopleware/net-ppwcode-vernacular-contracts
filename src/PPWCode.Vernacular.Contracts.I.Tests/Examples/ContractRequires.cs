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

using NUnit.Framework;

namespace PPWCode.Vernacular.Contracts.I.Tests.Examples;

public class ContractRequires : BaseTest
{
    [Test]
    public void TestRequires_ValidInput() // <.>
    {
        string s = "Hello";
        string repeated = s.RepeatWithRequires(2);
        Assert.That(repeated, Is.EqualTo("HelloHello"));
    }

    [Test]
    public void TestRequires_InvalidInputSource() // <.>
    {
        string s = null;
        Func<string> lambda = () => s.RepeatWithRequires(2);
        Assert.That(
            lambda,
            Throws.InstanceOf<PreConditionViolation>(),
            "Precondition 'source != null' should throw");
    }

    [Test]
    public void TestRequires_InvalidInputNr() // <.>
    {
        string s = "Hello";
        Func<string> lambda = () => s.RepeatWithRequires(-1);
        Assert.That(
            lambda,
            Throws.InstanceOf<PreConditionViolation>(),
            "Precondition 'nr >= 0' should throw");
    }
}
