# TDD Stack - TDD Exercise

TDD implementation of the stack. Done purely as a learning exercise based on [freeCodeCamp article](https://www.freecodecamp.org/news/tdd-explanation-hands-on-practice-with-c-a0124338be44/). Tests are a bit different from in the article since I'm following guidelines from [Pragmatic Test-Driven Development in C# and .NET](https://www.packtpub.com/product/pragmatic-test-driven-development-in-c-and-net/9781803230191) by Adam Tibi as it's the book I'm starting my TDD journey with it.

## Changes from article worth mentioning

- This project uses [xUnit](https://github.com/xunit/xunit) instead of [NUnit](https://github.com/nunit/nunit)
- Targeting .NET 6 instead of .NET Core 3
- Using test cases naming convention of `Method_Condition_Expectation` instead of more, let's say, free form approach from the article. 