using NUnit.Framework;

using UnitTestAndDebug;

namespace Tests
{
    public class Tests
    {
        // Con el código inicial, en el test InvalidID, el caso de ingresar una id null, fallaba debido a que el método IdUtils.IdIsValid
        // fallaba al recibir una string null.
        // Por lo tanto modifique el método para que aceptara una id null agregando una sentencia condicional al inicio.

        [TestCase("12345")]
        [TestCase("Zero52[*¨¨d")]
        [TestCase("Jhon Cena")]
        public void ValidName(string name)
        {
            Person john = new Person(name, "5.390.929-5");
            Assert.AreEqual(john.Name, name);
        }


        [TestCase("5390929-5")]
        [TestCase("53909295")]
        [TestCase("5.390.929-5")]
        public void ValidId(string id)
        {
            Person john = new Person("John Doe", id);
            Assert.AreEqual(john.ID, id);
        }


        [TestCase("")]
        [TestCase(null)]
        public void InvalidName(string name)
        {
            Person john = new Person(name, "5.390.929-5");
            Assert.AreEqual(john.Name, null);
        }


        [TestCase("")]
        [TestCase("1.234.567-8")]
        [TestCase(null)]
        public void InvalidID(string id)
        {
            Person john = new Person("John Doe", id);
            Assert.AreEqual(john.ID, null);
        }
    }
}