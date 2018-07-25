using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
/******************************************************************************/
  [TestClass]
  public class SpecialtyTests : IDisposable
  {
    public SpecialtyTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=william_kinzig_test;";
    }
    public void Dispose()
    {
      Specialty.DeleteAll();
    }
// /******************************************************************************/
//     [TestMethod]
//     public void Save()
//     {
//       //Arrange
//       Specialty testSpecialty = new Specialty("Blah");
//       testSpecialty.Save();
//       //Act
//       List<Specialty> testList = new List<Specialty>{testSpecialty};
//       List<Specialty> result = Specialty.GetAll();
//       //Assert
//       CollectionAssert.AreEqual(testList, result);
//     }
// /******************************************************************************/
//     [TestMethod]
//     public void Find()
//     {
//       //Arrange
//       Specialty testSpecialty = new Specialty("Blah");
//       testSpecialty.Save();
//       //Act
//       Specialty result = Specialty.Find(testSpecialty.GetId());
//       //Assert
//       Assert.AreEqual(testSpecialty, result);
//     }
// /******************************************************************************/
//     [TestMethod]
//     public void Edit()
//     {
//       //Arrange
//       string  testName = "Blah";
//       Specialty testSpecialty = new Specialty(testName);
//       testSpecialty.Save();
//       string updateName = "BlahBlah";
//       //Act
//       testSpecialty.Edit(updateName);
//       string result = Specialty.Find(testSpecialty.GetId()).GetName();
//       //Assert
//       Assert.AreEqual(updateName, result);
//     }
// /******************************************************************************/
//     [TestMethod]
//     public void Delete()
//     {
//       //Arrange
//       Specialty testSpecialty = new Specialty("Blah");
//       testSpecialty.Save();
//       Specialty newTestSpecialty = new Specialty("BlahBlah");
//       newTestSpecialty.Save();
//       List<Specialty> beforeDeleteList = new List<Specialty>{testSpecialty, newTestSpecialty}; //Use to make test fail
//       List<Specialty> afterDeleteList = new List<Specialty>{newTestSpecialty}; //Use to make test pass
//
//       //Act
//       Specialty.Find(testSpecialty.GetId()).Delete();
//       List<Specialty> result = Specialty.GetAll();
//       //Assert
//       CollectionAssert.AreEqual(afterDeleteList, result);
//     }
// /******************************************************************************/
//     [TestMethod]
//     public void GetStylists()
//     {
//       //Arrange
//       Specialty newSpecialty = new Specialty("Blah");
//       newSpecialty.Save();
//       Stylist newStylist = new Stylist("Blah");
//       newStylist.Save();
//       Stylist newStylist1 = new Stylist("Blah");
//       newStylist1.Save();
//
//       //Act
//       newSpecialty.AddStylist(newStylist);
//       newSpecialty.AddStylist(newStylist1);
//
//       List<Stylist> expectedResult = new List<Stylist>{newStylist, newStylist1};
//       List<Stylist> result = newSpecialty.GetStylists();
//
//       //Assert
//       CollectionAssert.AreEqual(expectedResult, result);
//     }
  }
}
