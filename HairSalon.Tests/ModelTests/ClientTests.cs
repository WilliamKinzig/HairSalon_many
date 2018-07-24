using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public ClientTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=william_kinzig_test;";
    }
    public void Dispose()
    {
      Client.DeleteAll();
    }
    // [TestMethod]
    // public void Save()
    // {
    //   //Arrange
    //   Client testClient = new Client("clientOne", 3);
    //   testClient.Save();
    //   //Act
    //   List<Client> testList = new List<Client>{testClient};
    //   List<Client> result = Client.GetAll();
    //   //Assert
    //   CollectionAssert.AreEqual(testList, result);
    // }


    [TestMethod]
    public void AddCatagory_AddsStylistToClient_StylistList()
    {
      Client testClient = new Client("wient");
      testClient.Save();
      Stylist testStylist = new Stylist("davist");
      testStylist.Save();

      testClient.AddStylist(testStylist);

      List<Stylist> result = testClient.GetStylists();
      List<Stylist> testList = new List<Stylist> {testStylist};

      CollectionAssert.AreEqual(testList, result);

    }

    [TestMethod]
    public void GetStylists_ReturnsAllClientStylists_StylistList()
    {
      //Arrange
      Client testClient = new Client("Mow the lawn");
      testClient.Save();

      Stylist testStylist1 = new Stylist("Home stuff");
      testStylist1.Save();

      Stylist testStylist2 = new Stylist("Work stuff");
      testStylist2.Save();

      //Act
      testClient.AddStylist(testStylist1);
      List<Stylist> result = testClient.GetStylists();
      List<Stylist> testList = new List<Stylist> {testStylist1};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }


    //
    //
    // [TestMethod]
    // public void Edit()
    // {
    //   //Arrange
    //   Client testClient = new Client("Naruto",0);
    //   testClient.Save();
    //   Client oldClient = new Client("Naruto", testClient.GetClientId());
    //   //Act
    //   testClient.Edit("Hokage");
    //
    //   Client result = Client.Find(testClient.GetClientId());
    //   //Assert
    //
    //   Assert.AreEqual(testClient, result);
    // }
    //
    //
    //
    //
    //
    // [TestMethod]
    // public void Delete()
    // {
    //   //Arrange
    //   Client testClient = new Client("Alan Tam", 3);
    //   testClient.Save();
    //   Client newTestClient = new Client("Chocolate Jainz", 1);
    //   newTestClient.Save();
    //   List<Client> List1 = new List<Client>{testClient, newTestClient};
    //   List<Client> List2 = new List<Client>{newTestClient};
    //
    //   //Act
    //   Client.Find(testClient.GetClientId()).Delete();
    //   List<Client> result = Client.GetAll();
    //   //Assert
    //   //CollectionAssert.AreEqual(List1, result);
    //   CollectionAssert.AreEqual(List2, result);
    //
    // }
    //
    //
    // [TestMethod]
    // public void Find()
    // {
    //   //Arrange
    //   Client testClient = new Client("bob", 3);
    //   testClient.Save();
    //   //Act
    //   Client result = Client.Find(testClient.GetClientId());
    //   //Assert
    //   Assert.AreEqual(testClient, result);
    // }
  }
}
