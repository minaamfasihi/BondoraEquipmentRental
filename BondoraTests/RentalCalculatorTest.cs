using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bondora.Helpers;
using Bondora.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using Bondora.Services;
using System.Messaging;
using Bondora.Rental;

namespace BondoraTests
{
    [TestClass]
    public class RentalCalculatorTest
    {
        // For Regular Equipment
        [TestMethod]
        public void TestRegularEquipmentRentalLessThanTwoDays()
        {
            RentalCalculator rc = new RentalCalculator();
            OneTime ot = new OneTime();
            Premium pr = new Premium();
            int days = 1;
            float shouldBe = ot.getFees() + pr.getFees(days);
            Assert.AreEqual(rc.getRentalPrice(EquipmentType.Regular, days), shouldBe);
        }
        [TestMethod]
        public void TestRegularEquipmentRentalTwoDays()
        {
            RentalCalculator rc = new RentalCalculator();
            OneTime ot = new OneTime();
            Premium pr = new Premium();
            int days = 2;
            float shouldBe = ot.getFees() + pr.getFees(days);
            Assert.AreEqual(rc.getRentalPrice(EquipmentType.Regular, days), shouldBe);
        }
        [TestMethod]
        public void TestRegularEquipmentRentalMoreThanTwoDays()
        {
            RentalCalculator rc = new RentalCalculator();
            OneTime ot = new OneTime();
            Premium pr = new Premium();
            Regular r = new Regular();
            int days = 3;
            float shouldBe = ot.getFees() + pr.getFees(2) + r.getFees(1);
            Assert.AreEqual(rc.getRentalPrice(EquipmentType.Regular, days), shouldBe);
        }

        // For Specialized Equipment
        [TestMethod]
        public void TestSpecializedEquipmentRentalLessThanThreeDays()
        {
            RentalCalculator rc = new RentalCalculator();
            Regular r = new Regular();
            Premium pr = new Premium();
            int days = 2;
            float shouldBe = pr.getFees(days);
            Assert.AreEqual(rc.getRentalPrice(EquipmentType.Specialized, days), shouldBe);
        }
        [TestMethod]
        public void TestSpecializedEquipmentRentalThreeDays()
        {
            RentalCalculator rc = new RentalCalculator();
            Regular r = new Regular();
            Premium pr = new Premium();
            int days = 3;
            float shouldBe = pr.getFees(3) + r.getFees(0);
            Assert.AreEqual(rc.getRentalPrice(EquipmentType.Specialized, days), shouldBe);
        }
        [TestMethod]
        public void TestSpecializedEquipmentRentalMoreThanTwoDays()
        {
            RentalCalculator rc = new RentalCalculator();
            Regular r = new Regular();
            Premium pr = new Premium();
            int days = 5;
            float shouldBe = pr.getFees(3) + r.getFees(2);
            Assert.AreEqual(rc.getRentalPrice(EquipmentType.Specialized, days), shouldBe);
        }
        // For Heavy Equipment
        [TestMethod]
        public void TestHeavyEquipmentRentalOneDay()
        {
            RentalCalculator rc = new RentalCalculator();
            OneTime ot = new OneTime();
            Premium pr = new Premium();
            int days = 1;
            float shouldBe = ot.getFees() + pr.getFees(1);
            Assert.AreEqual(rc.getRentalPrice(EquipmentType.Heavy, days), shouldBe);
        }
        [TestMethod]
        public void TestHeavyEquipmentRentalMoreThanOneDay()
        {
            RentalCalculator rc = new RentalCalculator();
            OneTime ot = new OneTime();
            Premium pr = new Premium();
            int days = 3;
            float shouldBe = ot.getFees() + pr.getFees(3);
            Assert.AreEqual(rc.getRentalPrice(EquipmentType.Heavy, days), shouldBe);
        }
    }
}
