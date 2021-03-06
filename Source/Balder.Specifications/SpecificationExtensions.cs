﻿using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Balder.Specifications
{
	public static class TestExtensions
	{
		public static void ShouldBe(this object valueToTest, object expected)
		{
			Assert.AreEqual(expected, valueToTest);
		}

		public static void ShouldNotBe(this object valueToTest, object expected)
		{
			Assert.AreNotEqual(expected,valueToTest);
		}

		public static void ShouldNotBeNull(this object valueToTest)
		{
			Assert.IsNotNull(valueToTest);
		}

		public static void ShouldBeNull(this object valueToTest)
		{
			Assert.IsNull(valueToTest);
		}

		public static void ShouldBeSameAs(this object valueToTest, object expected)
		{
			Assert.AreSame(valueToTest, expected);
		}

		public static void ShouldNotBeSameAs(this object valueToTest, object expected)
		{
			Assert.AreNotSame(valueToTest, expected);
		}

		public static void ShouldBeTrue(this bool valueToTest)
		{
			Assert.IsTrue(valueToTest);
		}

		public static void ShouldBeFalse(this bool valueToTest)
		{
			Assert.IsFalse(valueToTest);
		}

		public static void ShouldBeInstanceOfType<T>(this object valueToTest)
		{
			Assert.IsInstanceOfType(valueToTest,typeof(T));
		}

		public static void ShouldNotBeInstanceOfType<T>(this object valueToTest)
		{
			Assert.IsNotInstanceOfType(valueToTest, typeof(T));
		}

		public static void ShouldBeInstanceOfType(this object valueToTest,Type type)
		{
			Assert.IsInstanceOfType(valueToTest, type);
		}

		public static void ShouldNotBeInstanceOfType(this object valueToTest, Type type)
		{
			Assert.IsNotInstanceOfType(valueToTest, type);
		}

		public static void ShouldBeEmpty(this IList list)
		{
			Assert.AreEqual(0,list.Count);
		}

		public static void ShouldContain(this IList list, object expectedObject)
		{
			var index = list.IndexOf(expectedObject);
			if( index == -1 )
			{
				Assert.Fail("Expected object was not in list");
			}
		}

		public static void ShouldHave(this IList list, int expectedCount)
		{
			Assert.AreEqual(expectedCount,list.Count);
		}

		public static void ShouldNotBeNullOrEmpty(this string aString)
		{
			if( string.IsNullOrEmpty(aString))
			{
				Assert.Fail();
			}
		}

		public static void ShouldThrowException<T>(this object anObj, Action action) where T : Exception
		{
			ShouldThrowException<T>(anObj,action,null);
		}

		public static void ShouldThrowException<T>(this object anObj, Action action, Action<T> exception) where T : Exception
		{
			Exception ex = null;

			try
			{
				action.Invoke();
			}
			catch (Exception e)
			{
				ex = e;
			}

			if (ex == null)
				Assert.Fail("Did not throw exception");
			else
			{
				if (ex.GetType() != typeof(T))
				{
					Assert.Fail("Did not throw expected exception ({0}), but {1}",ex.GetType().Name,typeof(T).Name);
				}
				else if( null != exception )
				{
					exception.Invoke((T) ex);
				}
			}

		}
	}
}