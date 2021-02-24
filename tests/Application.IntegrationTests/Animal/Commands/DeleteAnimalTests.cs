using ZooApp.Application.Common.Exceptions;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using ZooApp.Application.Animal.Commands.CreateAnimal;
using ZooApp.Application.Animal.Commands.DeleteAnimal;
using ZooApp.Domain.Entities;

namespace ZooApp.Application.IntegrationTests.Animal.Commands
{
    using static Testing;

    public class DeleteAnimalTests : TestBase
    {
        [Test]
        public void ShouldRequireValidAnimalId()
        {
            var command = new DeleteAnimalCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoItem()
        {
            var createAnimalId = await SendAsync(new CreateAnimalCommand
            {
                Nombre = "Konan",
                Edad = 4,
                Genero = "Masculino",
                Raza = "Perro",
                Comida = "Pepas"
            });
          
            await SendAsync(new DeleteAnimalCommand
            {
                Id = createAnimalId
            });

            var animal= await FindAsync<AnimalEntity>(createAnimalId);

            animal.Should().BeNull();
        }
    }
}
