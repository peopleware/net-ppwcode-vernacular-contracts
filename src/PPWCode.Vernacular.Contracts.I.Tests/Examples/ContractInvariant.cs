// Copyright 2026 by PeopleWare n.v.
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

public class ContractInvariant : BaseTest
{
    private void Exec(Action action)
    {
        try
        {
            action();
        }
        catch (ApplicationException)
        {
        }
    }

    [Test]
    public void TestInvariant_Correct() // <.>
    {
        Chest chest = new();
        Assert.That(chest.IsOpen, Is.False);
        Assert.That(chest.IsLocked, Is.False);

        Exec(() => chest.Lock());
        Exec(() => chest.Open());
        Exec(() => chest.Unlock());
        Exec(() => chest.Open());

        Assert.That(chest.IsOpen, Is.True);
        Assert.That(chest.IsLocked, Is.False);
    }

    [Test]
    public void TestInvariant_Bug() // <.>
    {
        FaultyChest chest = new();
        Assert.That(chest.IsOpen, Is.False);
        Assert.That(chest.IsLocked, Is.False);

        Exec(() => chest.Lock());
        Assert.Throws<InvariantViolation>(
            () => Exec(() => chest.Open()),
            "Invariant should throw for faulty implementation");
    }
}
