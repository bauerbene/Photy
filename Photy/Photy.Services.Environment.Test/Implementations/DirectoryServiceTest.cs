using System.Collections.Generic;
using System.IO;
using System.Linq;
using Photy.Services.Environment.Implementations;
using Xunit;

namespace Photy.Services.Environment.Test.Implementations
{
    public class DirectoryServiceTest
    {
        private readonly EnvironmentDirectoryService _cut;
        
        private const string TestResourcesPath 
            = "/home/kali/projects/github/Photy/Photy/Photy.Services.Environment.Test/TestResources";
        
        public DirectoryServiceTest()
        {
            _cut = new EnvironmentDirectoryService();
        }

        [Fact]
        public void CreateDirectory_ValidPath_DirectoryIsCreated()
        {
            // Arrange
            const string createDirName = "createDir";
            var dirPath = Path.Combine(TestResourcesPath, createDirName);
            
            // Act
            _cut.CreateDirectory(dirPath);
            
            // Assert
            Assert.True(Directory.Exists(dirPath));
            
            // Cleanup
            Directory.Delete(dirPath);
        }

        [Fact]
        public void EnumerateFilesRecursively_TestDirectory_ReturnsCorrectFiles()
        {
            // Arrange
            const string dirName = "TestDirectory1";
            var dirPath = Path.Combine(TestResourcesPath, dirName);

            var containedDirectories = new List<string>
            {
                "TestFile1.png",
                "TestFile2.png",
                "TestSubDir1File1.png",
                "TestSubDir1File2.png",
                "TestSubDir2File1.png",
                "TestSubDir2File2.png",
            };
            
            // Act
            var result = _cut.EnumerateAllFilesRecursively(dirPath).ToList();
            
            // Assert
            AssertListContainsSameElements(containedDirectories, result);
        }

        [Fact]
        public void EnumerateFileSystemEntriesRecursively_ValidPath_ReturnsCorrectFileSystemEntries()
        {
            // Arrange
            const string dirName = "TestDirectory1";
            var dirPath = Path.Combine(TestResourcesPath, dirName);
            
            var containedFileSystemEntries = new List<string>
            {
                "TestFile1.png",
                "TestFile2.png",
                "TestSubDir1File1.png",
                "TestSubDir1File2.png",
                "TestSubDir2File1.png",
                "TestSubDir2File2.png",
                "TestSubDirectory1",
                "TestSubDirectory2"
            };
            
            // Act
            var result = _cut.EnumerateFileSystemEntriesRecursively(dirPath).ToList();
            
            // Assert
            AssertListContainsSameElements(containedFileSystemEntries, result);
        }
        
        private static void AssertListContainsSameElements(List<string> expected, List<string> actual)
        {
            Assert.Equal(expected.Count, actual.Count);
            foreach (var returnedValue in actual)
            {
                Assert.Contains(returnedValue.Split('/').Last(), expected);
            }
        }
    }
}