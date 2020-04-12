using DAL;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace DalUnitTests
{
    [TestClass]
    public class AudioServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<IAudioRepository> _mockAudioRepository;
        private Mock<IAudioFileService> _mockAudioFileService;
        private ILogger<AudioService> _mockLogger;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            _mockLogger = Mock.Of<ILogger<AudioService>>();
            _mockAudioRepository = _mockRepository.Create<IAudioRepository>();
            _mockAudioFileService = _mockRepository.Create<IAudioFileService>();
        }

        private AudioService CreateService()
        {
            return new AudioService(_mockLogger, 
                _mockAudioRepository.Object, _mockAudioFileService.Object);
        }

        [TestMethod]
        public async Task AddAudioFile_ReturnFalse_WhenFileIsNotAdded()
        {
            // Arrange
            var audioService = CreateService();
            var audioFile = new AudioFile
            { 
                AudioData = new byte[10]
            };

            _mockAudioRepository.Setup(x => x.AddAudioFile(audioFile)).ReturnsAsync(0);
            _mockAudioRepository.Setup(x => x.DeleteAudioFile(audioFile.Id)).ReturnsAsync(1);

            // Act
            var result = await audioService.AddAudioFile(audioFile);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task AddAudioFile_ReturnTrue_WhenFileIsAdded()
        {
            // Arrange
            var audioService = CreateService();
            var audioFile = new AudioFile
            {
                AudioData = new byte[10]
            };

            _mockAudioRepository.Setup(x => x.AddAudioFile(audioFile)).ReturnsAsync(1);
            _mockAudioFileService.Setup(x => x.SaveAudioFile(It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<byte[]>())).ReturnsAsync(true);

            // Act
            var result = await audioService.AddAudioFile(audioFile);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
