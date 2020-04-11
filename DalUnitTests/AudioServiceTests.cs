using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace DalUnitTests
{
    [TestClass]
    public class AudioServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<IAudioRepository> _mockAudioRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            _mockAudioRepository = _mockRepository.Create<IAudioRepository>();
        }

        private AudioService CreateService()
        {
            return new AudioService(_mockAudioRepository.Object);
        }

        [TestMethod]
        public void AddAudioFile_ReturnFalse_WhenFileIsNotAdded()
        {
            // Arrange
            var audioService = CreateService();
            var audioFile = new AudioFile();

            _mockAudioRepository.Setup(x => x.AddAudioFile(audioFile)).Returns(0);

            // Act
            var result = audioService.AddAudioFile(audioFile);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddAudioFile_ReturnTrue_WhenFileIsAdded()
        {
            // Arrange
            var audioService = CreateService();
            var audioFile = new AudioFile();

            _mockAudioRepository.Setup(x => x.AddAudioFile(audioFile)).Returns(1);

            // Act
            var result = audioService.AddAudioFile(audioFile);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
