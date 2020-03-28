namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Tests
    {
        [Test]
        public void FieldsExist()
        {
            //  private string make;
            //private string model;
            //private Dictionary<string, string> phonebook;
            var phone = new Phone("samsung", "abvdg");

            var type = typeof(Phone);

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            string expResField1 = "make";
            string expResField2 = "model";
            string expResField3 = "phonebook";

            var modelField = fields.First(x => x.Name == "make").Name;
            var fuelAmountField = fields.First(x => x.Name == "model").Name;
            var fuelConsumptionPerKmAmountField = fields.First(x => x.Name == "phonebook").Name;

            Assert.AreEqual(expResField1, modelField);
            Assert.AreEqual(expResField2, fuelAmountField);
            Assert.AreEqual(expResField3, fuelConsumptionPerKmAmountField);
        }
        [Test]
        public void ConstructorExists()
        {
            var type = typeof(Phone);
            var constr = type.GetConstructors();

            Assert.IsTrue(constr != null);
        }


        //make model count
        [Test]
        public void Make_PropertyCheck()
        {
            string normal = "Samsung";
            var phone = new Phone(normal, "abvdg");


            string wrong2 = string.Empty;
            string wrong3 = null;


            Assert.Throws<ArgumentException>(() => new Phone(wrong2, "abddaw"));
            Assert.Throws<ArgumentException>(() => new Phone(wrong3, "abddaw"));
            Assert.DoesNotThrow(() => new Phone(normal, "badbaw"));
            Assert.AreEqual(phone.Make, normal);
        }

        [Test]
        public void Model_PropertyCheck()
        {
            string normal = "Samsung";
            var phone = new Phone("abvdg", normal);


            string wrong2 = string.Empty;
            string wrong3 = null;


            Assert.Throws<ArgumentException>(() => new Phone("abddaw", wrong2));
            Assert.Throws<ArgumentException>(() => new Phone("abddaw", wrong3));
            Assert.DoesNotThrow(() => new Phone("badbaw", normal));
            Assert.AreEqual(phone.Model, normal);
        }
        [Test]
        public void Count_PropertyCheck()
        {
            string normal = "Samsung";

            var phone = new Phone("abvdg", normal);
            phone.AddContact("pesho", "test1");
            phone.AddContact("gosho", "test1");
            phone.AddContact("dido", "test1");

            Assert.AreEqual(phone.Count, 3);
        }

        [Test]
        public void AddContact_MethodCheck()
        {
            string normal = "Samsung";

            var phone = new Phone("abvdg", normal);
            phone.AddContact("pesho", "test1");
            phone.AddContact("dido", "test1");
            Assert.Throws<InvalidOperationException>(() => phone.AddContact("pesho", "test1"));
            Assert.DoesNotThrow(() => phone.AddContact("gosho", "test1"));
            //count?
        }

        [Test]
        public void Call_MethodCheck()
        {
            string normal = "Samsung";

            var phone = new Phone("abvdg", normal);

            string name1 = "pesho";
            string name2 = "dido";

            string wrongName = "gogo";

            string number1 = "test1";

            phone.AddContact(name1, number1);
            phone.AddContact(name2, number1);
            Assert.Throws<InvalidOperationException>(() => phone.Call(wrongName));
            Assert.DoesNotThrow(() => phone.Call("pesho"));
            string expected= $"Calling {name1} - {number1}...";

            StringAssert.AreEqualIgnoringCase(expected,phone.Call(name1));
        }
    }
}