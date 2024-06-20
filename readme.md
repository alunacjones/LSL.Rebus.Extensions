[![Build status](https://img.shields.io/appveyor/ci/alunacjones/lsl-rebus-extensions.svg)](https://ci.appveyor.com/project/alunacjones/lsl-rebus-extensions)
[![Coveralls branch](https://img.shields.io/coverallsCoverage/github/alunacjones/LSL.Rebus.Extensions)](https://coveralls.io/github/alunacjones/LSL.Rebus.Extensions)
[![NuGet](https://img.shields.io/nuget/v/LSL.Rebus.Extensions.svg)](https://www.nuget.org/packages/LSL.Rebus.Extensions/)

# LSL.Rebus.Extensions

This package provides some basic extensions to Rebus.

## AdvancedTopicsApiExtensions

Two options allow for less string-based topics. Please see the example below for details:

```csharp
using LSL.Rebus.Extensions

// the bus variable used in the examples below is a Rebus IBus instance

// Subscribe to "MyEvent" but routed via the exchange called "MyOtherTopicExchange"
bus.Subscribe<MyEvent>("MyOtherTopicExchange");

// Subscribe to "MyEvent" and "MyOtherEvent" but routed via the exchange called "MyOtherTopicExchange"
bus.Subscribe("MyOtherTopicExchange", new[] { typeof(MyEvent), typeof(MyOtherEvent)});
```

Under the hood, the topic is created using the Rebus `TypeExtension` of `GetSimpleAssemblyQualifiedName` combined with the exchange name in the Rebus default format of `Topic@Exchange`