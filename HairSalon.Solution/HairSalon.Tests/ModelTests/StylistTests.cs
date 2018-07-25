using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
/******************************************************************************/

  [TestClass]
  public class StylistTests : IDisposable
  {
    public StylistTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=william_kinzig_test;";
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
// 
// /******************************************************************************/
//
//     [TestMethod]
//     public void Save()
//     {
//       //Arrange
//       Stylist testStylist = new Stylist("stylistOne");
//       testStylist.Save();
//       //Act
//       List<Stylist> testList = new List<Stylist>{testStylist};
//       List<Stylist> result = Stylist.GetAll();
//       //Assert
//       CollectionAssert.AreEqual(testList, result);
//     }
//
// /******************************************************************************/
//
//     [TestMethod]
//     public void Find()
//     {
//       //Arrange
//       Stylist newStylist = new Stylist("bob");
//       newStylist.Save();
//       //Act
//       Stylist result = Stylist.Find(newStylist.GetId());
//       //Assert
//       Assert.AreEqual(newStylist, result);
//     }
//
// /******************************************************************************/
//
//     [TestMethod]
//     public void Edit()
//     {
//       //Arrange
//       string  testName = "blah";
//       Stylist testStylist = new Stylist(testName);
//       testStylist.Save();
//       string newName = "name2";
//       //Act
//       testStylist.Edit(newName);
//       string result = Stylist.Find(testStylist.GetId()).GetName();
//       //Assert
//       Assert.AreEqual(newName, result);
//     }
//
// /******************************************************************************/
//
//     [TestMethod]
//     public void Delete()
//     {
//       //Arrange
//       Stylist testStylist = new Stylist("David");
//       testStylist.Save();
//       Stylist newTestStylist = new Stylist("Eric");
//       newTestStylist.Save();
//       List<Stylist> DeleteList_Fail = new List<Stylist>{testStylist, newTestStylist};
//       List<Stylist> DeleteList_Pass = new List<Stylist>{newTestStylist};
//         //Act
//       Stylist.Find(testStylist.GetId()).Delete();
//       List<Stylist> result = Stylist.GetAll();
//       //Assert
//       // CollectionAssert.AreEqual(DeleteList_Fail, result);
//       CollectionAssert.AreEqual(result, DeleteList_Pass);
//     }
//
// /******************************************************************************/
//
//     [TestMethod]
//     public void GetSpecialties()
//     {
//       //Arrange
//       Stylist newStylist = new Stylist("bob");
//       newStylist.Save();
//       Specialty newSpecialty = new Specialty("dave");
//       newSpecialty.Save();
//       Specialty newSpecialty1 = new Specialty("fade");
//       newSpecialty1.Save();
//
//       //Act
//       newStylist.AddSpecialty(newSpecialty);
//       newStylist.AddSpecialty(newSpecialty1);
//
//       List<Specialty> expectedResult = new List<Specialty>{newSpecialty, newSpecialty1};
//       List<Specialty> result = newStylist.GetSpecialties();
//
//       //Assert
//       CollectionAssert.AreEqual(expectedResult, result);
//     }
  }
}
