using ZooApp.Application.Animal.Commands.CreateAnimal;
using ZooApp.Application.Common.Exceptions;
using ZooApp.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace ZooApp.Application.IntegrationTests.Animal.Commands
{
    using static Testing;

    public class CreateAnimalTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateAnimalCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateAnimal()
        {
            var userId = await RunAsDefaultUserAsync();

            var command = new CreateAnimalCommand
            {
                Nombre = "Konan",
                Edad = 4,
                Genero = "Masculino",
                Raza = "Perro",
                Comida = "Pepas"
            };

            var itemId = await SendAsync(command);

            var item = await FindAsync<AnimalEntity>(itemId);

            item.Should().NotBeNull();
            item.CreatedBy.Should().Be(userId);
            item.Created.Should().BeCloseTo(DateTime.Now, 10000);
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
        }
    }
}
