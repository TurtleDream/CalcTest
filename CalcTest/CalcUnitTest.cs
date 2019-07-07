using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace CalcTest
{
	[TestClass]
	public class CalcUnitTest
	{
		protected const string AppDriverUrl = "http://127.0.0.1:4723";

		private WindowsDriver<WindowsElement> driver;
		private CalcPage calcPage;

		[TestInitialize]
		public void Setup()
		{
			DesiredCapabilities cap = new DesiredCapabilities();
			cap.SetCapability("app", "c7d71b2e-1a01-4d69-830c-3079fe2fee0f_gs0bzqhjenrzm!App");
			driver = new WindowsDriver<WindowsElement>(new Uri(AppDriverUrl), cap, TimeSpan.FromSeconds(20));

			calcPage = new CalcPage(driver);
		}

		[TestCleanup]
		public void TestsCleanup()
		{
			driver.Dispose();
		}

		[TestMethod]
		public void TestButtons()
		{
			calcPage.Checker(calcPage.btn0, "0");
			calcPage.Checker(calcPage.btn1, "01");
			calcPage.Checker(calcPage.btn2, "012");
			calcPage.Checker(calcPage.btn3, "0123");
			calcPage.Checker(calcPage.btn4, "01234");
			calcPage.Checker(calcPage.btn5, "012345");
			calcPage.Checker(calcPage.btn6, "0123456");
			calcPage.Checker(calcPage.btn7, "01234567");
			calcPage.Checker(calcPage.btn8, "012345678");
			calcPage.Checker(calcPage.btn9, "0123456789");
			calcPage.Checker(calcPage.btnFloat, "0123456789,");
			calcPage.Checker(calcPage.btnClear, "");
		}

		[TestMethod]
		public void TestPlus()
		{
			calcPage.Clicker(calcPage.btn1);
			calcPage.Clicker(calcPage.btnPlus);
			calcPage.Clicker(calcPage.btn2);
			calcPage.Clicker(calcPage.btnPlus);
			calcPage.Clicker(calcPage.btn3);
			calcPage.Checker(calcPage.btnEqually, "6");
		}


		[TestMethod]
		public void TestMinus()
		{
			calcPage.Clicker(calcPage.btn9);
			calcPage.Clicker(calcPage.btnFloat);
			calcPage.Clicker(calcPage.btn5);
			calcPage.Clicker(calcPage.btnMinus);
			calcPage.Clicker(calcPage.btn5);
			calcPage.Clicker(calcPage.btnMinus);
			calcPage.Clicker(calcPage.btn3);
			calcPage.Checker(calcPage.btnEqually, "1,5");
		}

		[TestMethod]
		public void TestMultiply()
		{
			calcPage.Clicker(calcPage.btn1);
			calcPage.Clicker(calcPage.btnMultiply);
			calcPage.Clicker(calcPage.btn2);
			calcPage.Clicker(calcPage.btnMultiply);
			calcPage.Clicker(calcPage.btn7);
			calcPage.Checker(calcPage.btnEqually, "14");
		}

		[TestMethod]
		public void TestShare()
		{
			calcPage.Clicker(calcPage.btn9);
			calcPage.Clicker(calcPage.btn0);
			calcPage.Clicker(calcPage.btnShare);
			calcPage.Clicker(calcPage.btn3);
			calcPage.Clicker(calcPage.btnShare);
			calcPage.Clicker(calcPage.btn5);
			calcPage.Checker(calcPage.btnEqually, "6");
		}

		[TestMethod]
		public void GeneralTest()
		{
			calcPage.Clicker(calcPage.btn9);
			calcPage.Clicker(calcPage.btnFloat);
			calcPage.Clicker(calcPage.btn5);
			calcPage.Clicker(calcPage.btnMultiply);
			calcPage.Clicker(calcPage.btn2);
			calcPage.Clicker(calcPage.btnMinus);
			calcPage.Clicker(calcPage.btn1);
			calcPage.Clicker(calcPage.btnShare);
			calcPage.Clicker(calcPage.btn3);
			calcPage.Clicker(calcPage.btnPlus);
			calcPage.Clicker(calcPage.btn4);
			calcPage.Checker(calcPage.btnEqually, "10");
		}
	}
}
