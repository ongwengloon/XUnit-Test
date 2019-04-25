# MS Test vs XUnit Test

This project is to run & compare performance for MS Unit Test & XUnit Testing.

## Item to be setup, compare and Test :
- AssemblyInitialize
- AssemblyCleanup
- ClassInitialize
- ClassCleanup
- TestInitialize
- TestCleanup
- Serialize
- Parallelization

![result](https://github.com/ongwengloon/XUnit-Test/blob/master/Result.png)

## Conclusion
- XUnit is Good in syntax but heavy if not using Fixture (1 time declare test class) declaration.
- MS Test can be parallel execution to test method level, and XUnit to test class level.
