using NUnit.Framework;
using Pruebas_CodeChallenge;

namespace pruebas
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Mi C4a p2a p5s", "Mi Cadena para pruebas")]
        public void Prueba1(string str, string strCadenaNormal)
        {
            var result = Pruebas_CodeChallenge.Program.ConvierteCadena(strCadenaNormal);

            Assert.AreEqual(result, str);

        }


        [TestCase("¿C2o e3n el d1a de h1y?, G4s p1r E3r.", "¿Como estan el dia de hoy?, Gracias por Estar.")]
        public void Prueba2(string str, string strCadenaNormal)
        {
            var result = Pruebas_CodeChallenge.Program.ConvierteCadena(strCadenaNormal);

            Assert.AreEqual(result, str);

        }


        [TestCase("(C31) H1y t4s e3s i3s: [113-214], [P4a-219]", "(Caso1) Hoy tenemos estos items: [123-234], [Palabra-239]")]
        public void Prueba3(string str, string strCadenaNormal)
        {
            var result = Pruebas_CodeChallenge.Program.ConvierteCadena(strCadenaNormal);

            Assert.AreEqual(result, str);

        }

    }
}