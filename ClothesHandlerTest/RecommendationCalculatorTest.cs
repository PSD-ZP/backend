using ClothesHandler.Calculator;
using ClothesHandler.Models;

namespace ClothesHandlerTest
{

    [TestFixture]
    public class RecommendationCalculatorTest
    {

        [Test]
        [Category("UnitTest")]
        public void SpringWeatherWithoutPrecipClothesTest()
        {
            RecommendationCalculator calculator = new RecommendationCalculator();

            BodyPart body = calculator.GetClothes(20, 0.0, 0.0, 0.0, 0.0);

            foreach (ClothesItem clothes in body.Head)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("NONE") || clothes.Name.Equals("äiltovka"));
            }

            foreach (ClothesItem clothes in body.Body)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Mikina") || clothes.Name.Equals("TriËko"));
            }

            foreach (ClothesItem clothes in body.Legs)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Rifle"));
            }

            foreach (ClothesItem clothes in body.Shoes)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Tenisky"));
            }

            foreach (ClothesItem clothes in body.Accessories)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("NONE"));
            }

        }

        [Test]
        [Category("UnitTest")]
        public void SpringWeatherWithPrecipClothesTest()
        {
            RecommendationCalculator calculator = new RecommendationCalculator();

            BodyPart body = calculator.GetClothes(20, 15.0, 100.0, 0.0, 0.0);

            foreach (ClothesItem clothes in body.Head)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("NONE") || clothes.Name.Equals("äiltovka"));
            }

            foreach (ClothesItem clothes in body.Body)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Mikina") || clothes.Name.Equals("TriËko"));
            }

            foreach (ClothesItem clothes in body.Legs)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Rifle"));
            }

            foreach (ClothesItem clothes in body.Shoes)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Tenisky") || clothes.Name.Equals("Gum·ky"));
            }

            foreach (ClothesItem clothes in body.Accessories)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("D·ûdnik") || clothes.Name.Equals("Pröiplaöù"));
            }
        }

        [Test]
        [Category("UnitTest")]
        public void SummerWeatherWithoutPrecipClothesTest()
        {
            RecommendationCalculator calculator = new RecommendationCalculator();

            BodyPart body = calculator.GetClothes(30.0, 15.0, 0.0, 20.0, 0.0);

            foreach (ClothesItem clothes in body.Head)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("NONE") || clothes.Name.Equals("äiltovka"));
            }

            foreach (ClothesItem clothes in body.Body)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("TriËko"));
            }

            foreach (ClothesItem clothes in body.Legs)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Rifle") || clothes.Name.Equals("Kraùasy"));
            }

            foreach (ClothesItem clothes in body.Shoes)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Tenisky") || clothes.Name.Equals("Sand·le"));
            }

            foreach (ClothesItem clothes in body.Accessories)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("NONE"));
            }

        }

        [Test]
        [Category("UnitTest")]
        public void SummerWeatherWithPrecipClothesTest()
        {
            RecommendationCalculator calculator = new RecommendationCalculator();

            BodyPart body = calculator.GetClothes(30.0, 15.0, 90.0, 20.0, 0.0);

            foreach (ClothesItem clothes in body.Head)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("NONE") || clothes.Name.Equals("äiltovka"));
            }

            foreach (ClothesItem clothes in body.Body)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("TriËko"));
            }

            foreach (ClothesItem clothes in body.Legs)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Rifle") || clothes.Name.Equals("Kraùasy"));
            }

            foreach (ClothesItem clothes in body.Shoes)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Tenisky") || clothes.Name.Equals("Gum·ky"));
            }

            foreach (ClothesItem clothes in body.Accessories)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("D·ûdnik") || clothes.Name.Equals("Pröiplaöù"));
            }

        }

        [Test]
        [Category("UnitTest")]
        public void AutumnWeatherWithoutPrecipClothesTest()
        {
            RecommendationCalculator calculator = new RecommendationCalculator();

            BodyPart body = calculator.GetClothes(15.0, 5.0, 0, 80.0, 0.0);

            foreach (ClothesItem clothes in body.Head)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("NONE") || clothes.Name.Equals("äiltovka"));
            }

            foreach (ClothesItem clothes in body.Body)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("TriËko") || clothes.Name.Equals("Mikina") || clothes.Name.Equals("Prechodn· bunda"));
            }

            foreach (ClothesItem clothes in body.Legs)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Rifle"));
            }

            foreach (ClothesItem clothes in body.Shoes)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Tenisky"));
            }

            foreach (ClothesItem clothes in body.Accessories)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("NONE"));
            }

        }


        [Test]
        [Category("UnitTest")]
        public void AutumnWeatherWithPrecipClothesTest()
        {
            RecommendationCalculator calculator = new RecommendationCalculator();

            BodyPart body = calculator.GetClothes(15.0, 20.0, 100.0, 20.0, 0.0);

            foreach (ClothesItem clothes in body.Head)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("NONE") || clothes.Name.Equals("Prechodna Ëiapka"));
            }

            foreach (ClothesItem clothes in body.Body)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("TriËko") || clothes.Name.Equals("Mikina") || clothes.Name.Equals("Softshell bunda"));
            }

            foreach (ClothesItem clothes in body.Legs)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Rifle") || clothes.Name.Equals("Kraùasy"));
            }

            foreach (ClothesItem clothes in body.Shoes)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Tenisky") || clothes.Name.Equals("Gum·ky"));
            }

            foreach (ClothesItem clothes in body.Accessories)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("D·ûdnik") || clothes.Name.Equals("Pröiplaöù"));
            }

        }

        [Test]
        [Category("UnitTest")]
        public void WinterWeatherWithoutPrecipClothesTest()
        {
            RecommendationCalculator calculator = new RecommendationCalculator();

            BodyPart body = calculator.GetClothes(-5, 12.0, 0.0, 70.0, 0.0);

            foreach (ClothesItem clothes in body.Head)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("NONE") || clothes.Name.Equals("Zimna Ëiapka"));
            }

            foreach (ClothesItem clothes in body.Body)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("TriËko") || clothes.Name.Equals("Mikina") || clothes.Name.Equals("HrubÈ body")
                    || clothes.Name.Equals("Zimn· bunda"));
            }

            foreach (ClothesItem clothes in body.Legs)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Rifle") || clothes.Name.Equals("Spodky"));
            }

            foreach (ClothesItem clothes in body.Shoes)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("ZimnÈ top·nky"));
            }

            foreach (ClothesItem clothes in body.Accessories)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("NONE"));
            }

        }

        [Test]
        [Category("UnitTest")]
        public void WinterWeatherWithPrecipClothesTest()
        {
            RecommendationCalculator calculator = new RecommendationCalculator();

            BodyPart body = calculator.GetClothes(-10.0, 20.0, 0.0, 20.0, 100.0);

            foreach (ClothesItem clothes in body.Head)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("NONE") || clothes.Name.Equals("Zimna Ëiapka"));
            }

            foreach (ClothesItem clothes in body.Body)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("TriËko") || clothes.Name.Equals("Mikina") || clothes.Name.Equals("HrubÈ body")
                    || clothes.Name.Equals("Zimn· bunda"));
            }

            foreach (ClothesItem clothes in body.Legs)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Rifle") || clothes.Name.Equals("Spodky"));
            }

            foreach (ClothesItem clothes in body.Shoes)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("ZimnÈ top·nky"));
            }

            foreach (ClothesItem clothes in body.Accessories)
            {
                Console.WriteLine(clothes.Name);
                Assert.IsTrue(clothes.Name.Equals("Rukavice") || clothes.Name.Equals("ä·l"));
            }

        }
    }
}