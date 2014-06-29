using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobertTapping.Mi9CC;
using RobertTapping.Mi9CC.Controllers;
using System.IO;
using System.Net.Http.Headers;
using System.Web;

namespace RobertTapping.Mi9CC.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {

        [TestMethod]
        public  void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            var jsonString = "";
            using (var sr = new StreamReader(@"SampleData\sampledata.json"))
            {
                
                jsonString = sr.ReadToEnd();

                sr.Close();
            }
    
                 controller.Post();



            // Assert
        }


        [TestMethod]
        public  void Post_with_parent_property()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            var jsonString = "";
            using (var sr = new StreamReader(@"SampleData\sampledata2.json"))
            {

                jsonString = sr.ReadToEnd();
                
                sr.Close();
            }
         controller.Post();


            // Assert
        }


        [TestMethod]
        public void Post_with_no_data()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            var response = controller.Post();


            // Assert
        }

    }
}
