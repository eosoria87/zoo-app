using ZooApp.Application.Common.Exceptions;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;
using ZooApp.Application.Animal.Commands.CreateAnimal;
using ZooApp.Application.Animal.Commands.UpdateAnimal;
using ZooApp.Domain.Entities;

namespace ZooApp.Application.IntegrationTests.Animal.Commands
{
    using static Testing;

    public class UpdateAnimalTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new UpdateAnimalCommand
            {
                Id = 99,
                Nombre = "Yanko Dog"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateTodoItem()
        {
            var userId = await RunAsDefaultUserAsync();

            var createAnimalId = await SendAsync(new CreateAnimalCommand
            {
                Nombre = "KonanUpdate",
                Edad = 4,
                Genero = "Masculino",
                Raza = "Perro",
                Comida = "Pepas"
            });

            var command = new UpdateAnimalCommand
            {
                Id = createAnimalId,
                Nombre = "FiruailsUpdate"
            };

            await SendAsync(command);

            var item = await FindAsync<AnimalEntity>(createAnimalId);

            item.Nombre.Should().Be(command.Nombre);
            item.LastModifiedBy.Should().NotBeNull();
            item.LastModifiedBy.Should().Be(userId);
            item.LastModified.Should().NotBeNull();
            item.LastModified.Should().BeCloseTo(DateTime.Now, 1000);
        }
    }
}
