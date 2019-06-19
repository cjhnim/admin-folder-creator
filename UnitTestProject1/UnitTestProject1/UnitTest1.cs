using System;
using System.IO;
using System.Security.AccessControl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileSystemAccessRule administratorRule = new FileSystemAccessRule("Administrators", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);

            FileSystemAccessRule everyoneRule = new FileSystemAccessRule("EveryOne", FileSystemRights.CreateDirectories | FileSystemRights.CreateFiles, AccessControlType.Allow);

            DirectorySecurity dirSec = new DirectorySecurity();
            dirSec.AddAccessRule(everyoneRule);
            dirSec.AddAccessRule(administratorRule);

            DirectoryInfo info = Directory.CreateDirectory(@"C:\GuestTemp", dirSec);

            Assert.IsTrue(info.Exists);
        }
    }
}
