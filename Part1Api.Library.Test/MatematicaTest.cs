namespace Part1Api.Library.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestarDecomposicao()
        {
            var divisores = Matematica.Decompor(40);
            Assert.IsNotNull(divisores);
            Assert.That(divisores, Is.EqualTo(new List<int>() { 1, 2, 4, 5, 8, 10, 20, 40 }));

            divisores = Matematica.Decompor(-999);
            Assert.IsNotNull(divisores);
            Assert.That(divisores, Is.EqualTo(new List<int>() { }));

            divisores = Matematica.Decompor(0);
            Assert.IsNotNull(divisores);
            Assert.That(divisores, Is.EqualTo(new List<int>() { }));

            divisores = Matematica.Decompor(1);
            Assert.IsNotNull(divisores);
            Assert.That(divisores, Is.EqualTo(new List<int>() { 1 }));

            divisores = Matematica.Decompor(2);
            Assert.IsNotNull(divisores);
            Assert.That(divisores, Is.EqualTo(new List<int>() { 1, 2 }));

            divisores = Matematica.Decompor(3);
            Assert.IsNotNull(divisores);
            Assert.That(divisores, Is.EqualTo(new List<int>() { 1, 3 }));

            divisores = Matematica.Decompor(4);
            Assert.IsNotNull(divisores);
            Assert.That(divisores, Is.EqualTo(new List<int>() { 1, 2, 4 }));

            divisores = Matematica.Decompor(5);
            Assert.IsNotNull(divisores);
            Assert.That(divisores, Is.EqualTo(new List<int>() { 1, 5 }));

            divisores = Matematica.Decompor(7);
            Assert.IsNotNull(divisores);
            Assert.That(divisores, Is.EqualTo(new List<int>() { 1, 7 }));

            divisores = Matematica.Decompor(1000);
            Assert.IsNotNull(divisores);
            Assert.That(divisores, Is.EqualTo(new List<int>() { 1, 2, 4, 5, 8, 10, 20, 25, 40, 50, 100, 125, 200, 250, 500, 1000 }));

            divisores = Matematica.Decompor(1001);
            Assert.IsNotNull(divisores);
            Assert.That(divisores, Is.EqualTo(new List<int>() { 1, 7, 11, 13, 77, 91, 143, 1001 }));

            Assert.Pass();
        }

        [Test]
        public void RemoverNumerosNaoPrimos()
        {
            var primos = Matematica.RemoverNumerosNaoPrimos(new List<int>() { 1, 2, 3, 4, 5, 76, 19, 659, 600, 500, 745 });
            Assert.IsNotNull(primos);
            Assert.That(primos, Is.EqualTo(new List<int>() { 2, 3, 5, 19, 659 }));

            Assert.Pass();
        }
    }
}