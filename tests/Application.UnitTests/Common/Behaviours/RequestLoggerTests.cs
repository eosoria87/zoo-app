using ZooApp.Application.Animal.Commands.CreateAnimal;
using ZooApp.Application.Common.Behaviours;
using ZooApp.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace ZooApp.Application.UnitTests.Common.Behaviours
{
    public class RequestLoggerTests
    {
        private readonly Mock<ILogger<CreateAnimalCommand>> _logger;
        private readonly Mock<ICurrentUserService> _currentUserService;
        private readonly Mock<IIdentityService> _identityService;


        public RequestLoggerTests()
        {
            _logger = new Mock<ILogger<CreateAnimalCommand>>();

            _currentUserService = new Mock<ICurrentUserService>();

            _identityService = new Mock<IIdentityService>();
        }

        [Test]
        public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
        {
            _currentUserService.Setup(x => x.UserId).Returns("Administrator");

            var requestLogger = new LoggingBehaviour<CreateAnimalCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

            await requestLogger.Process(new CreateAnimalCommand { Id = 1, Nombre = "Konan", Edad = 5, Raza = "Perro",Genero = "Masculino", Comida = "Pepas" }, new CancellationToken());

            _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
        {
            var requestLogger = new LoggingBehaviour<CreateAnimalCommand>(_logger.Object, _currentUserService.Object, _identityService.Object);

            await requestLogger.Process(new CreateAnimalCommand { Id = 1, Nombre = "Konan", Edad = 5, Raza = "Perro", Genero = "Masculino", Comida = "Pepas" }, new CancellationToken());

            _identityService.Verify(i => i.GetUserNameAsync(null), Times.Never);
        }
    }
}
