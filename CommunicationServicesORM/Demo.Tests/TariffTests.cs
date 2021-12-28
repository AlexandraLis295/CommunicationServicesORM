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
            var subscriber = new Subscriber(1, "������", "�����", "1990.04.30", "����������");
            var tariff = new Tariff(1, "�����������", subscriber);
            var expected = "����������� ������ �. 1990.04.30. �.";

            //act
            var actual = tariff.ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_EmptySubscriber_Success()
        {
            // arrange
            var tariff = new Tariff(1, "��������");
            var expected = "��������";

            //act
            var actual = tariff.ToString();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Ctor_ValidDataEmptySubscriber_Success()
        {
            // arrange & act & assert
            Assert.DoesNotThrow(() => _ = new Tariff(1, "��������"));
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
            var subscriber = new Subscriber(1, "������", "�����", "����������");

            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Tariff(1, wrongTariffName));
        }

        [Test]
        public void Ctor_ValidData_Success()
        {
            // arrange
            var subscriber = new Subscriber(1, "������", "�����", "����������");

            // act & assert
            Assert.DoesNotThrow(() => _ = new Tariff(1, "�����������", subscriber));
        }
    }
}
