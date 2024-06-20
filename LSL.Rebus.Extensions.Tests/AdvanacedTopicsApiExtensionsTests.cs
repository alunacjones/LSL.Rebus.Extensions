using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Rebus.Bus;

namespace LSL.Rebus.Extensions.Tests;

public class AdvanacedTopicsApiExtensionsTests
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
            "LSL.Rebus.Extensions.Tests.AdvanacedTopicsApiExtensionsTests+MyEvent, LSL.Rebus.Extensions.Tests@MyExchange"
        );
    }

    private class MyEvent {}
}