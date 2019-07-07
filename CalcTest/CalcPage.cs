using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalcTest
{
	class CalcPage
	{
		private readonly WindowsDriver<WindowsElement> driver;
		private readonly Logger logger = LogManager.GetCurrentClassLogger();

		public CalcPage(WindowsDriver<WindowsElement> driver)
		{
			this.driver = driver;
			logger.Info("Start application");
		}

		public WindowsElement btn0 => driver.FindElementByName("0");
		public WindowsElement btn1 => driver.FindElementByName("1");
		public WindowsElement btn2 => driver.FindElementByName("2");
		public WindowsElement btn3 => driver.FindElementByName("3");
		public WindowsElement btn4 => driver.FindElementByName("4");
		public WindowsElement btn5 => driver.FindElementByName("5");
		public WindowsElement btn6 => driver.FindElementByName("6");
		public WindowsElement btn7 => driver.FindElementByName("7");
		public WindowsElement btn8 => driver.FindElementByName("8");
		public WindowsElement btn9 => driver.FindElementByName("9");
		public WindowsElement btnFloat => driver.FindElementByName(".");
		public WindowsElement btnClear => driver.FindElementByName("C");
		public WindowsElement btnShare => driver.FindElementByName("/");
		public WindowsElement btnMultiply => driver.FindElementByName("*");
		public WindowsElement btnPlus => driver.FindElementByName("+");
		public WindowsElement btnMinus => driver.FindElementByName("-");
		public WindowsElement btnEqually => driver.FindElementByName("=");
		public WindowsElement textBox => driver.FindElementByClassName("TextBox");

		public void Checker(WindowsElement windowsElement, String expected)
		{
			
			Clicker(windowsElement);
			Assert.AreEqual(expected, textBox.Text, "Ошибка теста! Ожидалось - " + expected + ". Получено - " + textBox.Text);
		}

		public void Clicker(WindowsElement windowsElement)
		{
			try
			{
				logger.Info("Нажатие на элемент " + windowsElement.Text);
				windowsElement.Click();
			}
			catch (Exception exception)
			{
				logger.Error("Ошибка " + exception);
				MessageBox.Show("Error " + exception);
			}
		}
	}
}
