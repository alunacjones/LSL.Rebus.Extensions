using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Rebus.Bus;

namespace LSL.Rebus.Extensions.Tests;

public class AdvancedTopicsApiExtensionsTests
{
    [Test]
    public async Task Subscribe_GivenAnExchangeItShouldSubscribeToTheCorrectTypeAndExchange()
    {
        // Arrange
        var fakeBus = Substitute.For<IBus>();

        // Act
        await fakeBus.Advanced.Topics.Subscribe<MyEvent>("MyExchange");  

        // Assert
        await fakeBus.Advanced.Topics.Received(1).Subscribe(
            "LSL.Rebus.Extensions.Tests.AdvancedTopicsApiExtensionsTests+MyEvent, LSL.Rebus.Extensions.Tests@MyExchange"
        );
    }

    [Test]
    public async Task SubscribeToMutipleTypes_GivenAnExchangeItShouldSubscribeToTheCorrectTypeAndExchange()
    {
        // Arrange
        var fakeBus = Substitute.For<IBus>();

        // Act
        await fakeBus.Advanced.Topics.Subscribe("MyExchange", new[] { typeof(MyEvent), typeof(MyOtherEvent) });  

        // Assert
        await fakeBus.Advanced.Topics.Received(1).Subscribe(
            "LSL.Rebus.Extensions.Tests.AdvancedTopicsApiExtensionsTests+MyEvent, LSL.Rebus.Extensions.Tests@MyExchange"
        );

        await fakeBus.Advanced.Topics.Received(1).Subscribe(
            "LSL.Rebus.Extensions.Tests.AdvancedTopicsApiExtensionsTests+MyOtherEvent, LSL.Rebus.Extensions.Tests@MyExchange"            
        );
    }    

    private class MyEvent {}
    private class MyOtherEvent {}
}