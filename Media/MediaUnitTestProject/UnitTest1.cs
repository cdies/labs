using System;
using System.Data.Linq;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaUnitTestProject.TestServiceReference;

namespace MediaUnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CheckMP3()
        {
            MediaDataClassesDataContext db = new MediaDataClassesDataContext();
            Table<MediaTable> table = db.GetTable<MediaTable>();
            var path = from i in table select i.Path;
            foreach (var s in path)
                Assert.IsTrue(s.Contains(".mp3"));
        }

        [TestMethod]
        public void CheckIsNotNull()
        {
            MediaDataClassesDataContext db = new MediaDataClassesDataContext();
            Table<MediaTable> table = db.GetTable<MediaTable>();
            var path = from i in table select i.Path;
            foreach (var s in path)
                Assert.IsNotNull(s);
        }

        [TestMethod]
        public void ChekWCFServer()
        {
            MediaServiceClient media = new MediaServiceClient();
            Assert.IsNotNull(media.GetTable());
        }
    }
}
