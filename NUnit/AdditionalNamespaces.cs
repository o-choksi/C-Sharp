// NUnit framework namespace for attributes used in test methods
using NUnit.Framework; // Provides the core attributes (like [Test], [SetUp], [TearDown]) and assertions used in writing tests with NUnit.

// NUnit namespace for dealing with constraints in assertions
using NUnit.Framework.Constraints; // Contains classes that represent conditions (constraints) used in assertions, such as Is.EqualTo, Is.Not.Null, etc.

// NUnit namespace for working with mock objects and verifying their behavior
using NUnit.Framework.Mocking; // Provides classes and interfaces to support mocking in tests. (Note: NUnit itself doesn't include a mocking framework; typically, a third-party library like Moq or NSubstitute is used).

// NUnit namespace for custom assertions and extensions
using NUnit.Framework.Assertions; // Used to create custom assertions or extend existing assertions with new functionality.

// NUnit namespace for running tests within a specific context or with special settings
using NUnit.Framework.Internal; // Provides classes and methods for internal NUnit use, such as managing test contexts, logging, and custom settings during test execution.
