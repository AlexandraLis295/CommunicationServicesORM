namespace Demo.Tests
{
    using System;
    using NUnit.Framework;
    using Domain;

    [TestFixture]
    public class TariffTests
    {
        [Test]
        public void ToString_ValidData_Success()
        {
            // arrange
            var subscriber = new Subscriber(1, "Рябова", "Дария", "1990.04.30", "Кирилловна");
            var tariff = new Tariff(1, "Оптимальный", subscriber);
            var expected = "Оптимальный Рябова Д. 1990.04.30. К.";

            //act
            var actual = tariff.ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_EmptySubscriber_Success()
        {
            // arrange
            var tariff = new Tariff(1, "Безлимит");
            var expected = "Безлимит";

            //act
            var actual = tariff.ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Ctor_ValidDataEmptySubscriber_Success()
        {
            // arrange & act & assert
            Assert.DoesNotThrow(() => _ = new Tariff(1, "Безлимит"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\0")]
        [TestCase("\n")]
        [TestCase("\r")]
        [TestCase("\t")]
        public void Ctor_WrongDataNullTariffNameEmptySubscribers_Fail(string wrongTariffName)
        {
            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Tariff(1, wrongTariffName));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("\0")]
        [TestCase("\n")]
        [TestCase("\r")]
        [TestCase("\t")]
        public void Ctor_WrongDataNullTariffNameEmptySubscriber_Fail(string wrongTariffName)
        {
            // arrange
            var subscriber = new Subscriber(1, "Рябова", "Дария", "Кирилловна");

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Tariff(1, wrongTariffName));
        }

        [Test]
        public void Ctor_ValidData_Success()
        {
            // arrange
            var subscriber = new Subscriber(1, "Рябова", "Дария", "Кирилловна");

            // act & assert
            Assert.DoesNotThrow(() => _ = new Tariff(1, "Оптимальный", subscriber));
        }
    }
}
