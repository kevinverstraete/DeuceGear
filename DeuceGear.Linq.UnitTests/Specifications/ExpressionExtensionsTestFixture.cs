using DeuseGear.Linq;
using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace DeuceGear.UnitTests.Linq.Specifications
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ExpressionExtensionsTestFixture
    {
        [Test]
        public void ExpressionExtensionsAndNullTest()
        {
            // arrange
            Expression<Func<string, bool>> expr = (x => true);
            Expression<Func<string, bool>> expr2 = null;

            // act
            var result = Assert.Throws<ArgumentNullException>(() => expr.And(expr2));

            // assert
            Assert.That(result.ParamName, Is.EqualTo("expressionToAdd"));
        }
        [Test]
        public void ExpressionExtensionsOrNullTest()
        {
            // arrange
            Expression<Func<string, bool>> expr = (x => true);
            Expression<Func<string, bool>> expr2 = null;

            // act
            var result = Assert.Throws<ArgumentNullException>(() => expr.Or(expr2));

            // assert
            Assert.That(result.ParamName, Is.EqualTo("expressionToOr"));
        }
        [Test]
        public void ExpressionExtensionsNotNullTest()
        {
            // arrange
            Expression<Func<string, bool>> expr = null;

            // act
            var result = Assert.Throws<ArgumentNullException>(() => ExpressionExtensions.Not(expr));

            // assert
            Assert.That(result.ParamName, Is.EqualTo("expressionToNot"));
        }

        [Test]
        public void ReplaceParameterTest()
        {
            // arrange 
            Expression<Func<Sample, bool>> testCase = i => i.FirstName.Equals(i.LastName);
            var newParam = "25fe5cf5142e4cd1906c5f2f1c0767ef";
            var newParamExpression = Expression.Parameter(typeof(Sample), newParam);

            // act
            var result = testCase.ReplaceParameter(testCase.Parameters.First(), newParamExpression);

            // assert
            Assert.That(result.ToString(), Is.EqualTo("25fe5cf5142e4cd1906c5f2f1c0767ef => 25fe5cf5142e4cd1906c5f2f1c0767ef.FirstName.Equals(25fe5cf5142e4cd1906c5f2f1c0767ef.LastName)"));
        }
    }
}
