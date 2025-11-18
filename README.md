# PPWCode.Vernacular.Contracts

This library is part of the .NET PPWCode project and encapsulates the vernacular
on contracts.

This is a helper library to apply design-by-contract principles in .NET.  It was
created to serve as a replacement for the Microsoft "Code Contracts" research
project that was halted.  Note that this library simply contains helper methods
to perform run-time contract validation.  The library is also annotated to help
the static analyzer in the Roslyn compiler, and in the JetBrains tools Rider and
ReSharper.

## Getting started

### PPWCode.Vernacular.Contracts I

This is version `I` of the library, which is designed to work both with legacy
.NET full framework versions and with modern .NET (Core) versions.

Note that support for .NET versions tracks Microsofts support for released .NET
SDKs.

The library is available as the [NuGet] package `PPWCode.Vernacular.Contracts.I`
in the [NuGet Gallery].

## PPWCode

This package is part of the .NET PPWCode project by [PeopleWare n.v.].

### PPWCode .NET

Development of the PPWCode .NET libraries is done in [GitHub] repositories, and
all releases (both stable and pre-release) are published as [NuGet] packages on
the [NuGet Gallery].

We believe in Design By Contract.  As far as is possible, pre-conditions,
post-conditions and invariants are enforced in the code using extra
`assert`-like statements (using this library).  Furthermore, unit tests are
added to verify code correctness.

Published packages include the assembly itself and both `pdb` and `xml` files,
for debugging symbols and documentation respectively.

## License and Copyright

Copyright 2022–2025 by [PeopleWare n.v.].

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.


[GitHub]: https://github.com/peopleware

[PeopleWare n.v.]: http://www.peopleware.be/

[NuGet]: https://www.nuget.org/

[NuGet Gallery]: https://www.nuget.org/policies/About
