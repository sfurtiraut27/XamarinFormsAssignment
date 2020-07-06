using NUnit.Framework;
using PeoplehoodApp.Models;
using PeoplehoodApp.ViewModels;

namespace TestProject
{
    public class PeopleTest
    {
        PeopleViewModel viewModel;
       [SetUp]
        public void Setup()
        {
             viewModel = new PeopleViewModel();
        }

        [Test]
        public void ValidSAID()
        {
            string IdNumber = "9202204720082";
            Assert.IsTrue(viewModel.IsValidSAID(IdNumber));
        }
        [Test]
        public void NotValidSAID()
        {
            string IdNumber = "1";
            Assert.IsFalse(viewModel.IsValidSAID(IdNumber));
        }

        [Test]
        public void GetPeopleData()
        {
            string IdNumber = "1";
            Assert.IsNotNull(viewModel.GetPeopleWithID(IdNumber));
        }

       
    }
}