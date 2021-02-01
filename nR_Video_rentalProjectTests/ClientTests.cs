using Microsoft.VisualStudio.TestTools.UnitTesting;
using nR_Video_rentalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nR_Video_rentalProject.Tests
{
    [TestClass()]
    public class ClientTests
    {
        [TestMethod()]
        public void CmdRecordTest()
        {
            Client client = new Client(1,"Nr","Queen street","78945","nr@gamil.com","NZ");
            client.AddClient();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void CmdRecordTest2()
        {
            Movie movie = new Movie(1, "Don", "4.9", "2018", "5", "3","fighting");
            movie.AddMovie();
            Assert.IsTrue(true);
        }
    }
}