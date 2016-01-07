using Microsoft.VisualStudio.TestTools.UnitTesting;
using SourceCodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SourceCodeGeneration;

namespace SourceCodeGeneration.Tests
{
    [TestClass()]
    public class CSharpSourceCodeGenerationTests
    {
        [TestMethod()]
        public void GetParameterType_DynamicParameterGiven_dddd()
        {
            var method = typeof(SampleClass).GetMethod("Method9");
            var parameter = method.GetParameters()[0];

            var result = CSharpSourceCodeGeneration.GetParameterType(parameter);
            result.Should().Be("dynamic input");
        }

        [TestMethod()]
        public void GetTypeParametersConstrantsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTypeParametersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetMethodCallArgumentsTest()
        {
            var method = typeof(SampleClass).GetMethod("Method10");
            CSharpSourceCodeGeneration.GetInvokingMethodArguments(method);
        }

        [TestMethod]
        public void GetParameterModifier_OutParameter_ShouldReturnOutKeyword()
        {
            var method = typeof(SampleClass).GetMethod("Method10");
            var parameter = method.GetParameters()[1];
            var result = CSharpSourceCodeGeneration.GetParameterModifier(parameter);

            result.Should().Be("out ");
        }

        [TestMethod]
        public void GetParameterModifier_RefParameter_ShouldReturnRefKeyword()
        {
            var method = typeof(SampleClass).GetMethod("Method8");
            var parameter = method.GetParameters()[0];
            var result = CSharpSourceCodeGeneration.GetParameterModifier(parameter);

            result.Should().Be("ref ");
        }

        [TestMethod]
        public void GetParameterModifier_ParamsParameter_ShouldReturnParamsKeyword()
        {
            var method = typeof(SampleClass).GetMethod("Method7");
            var parameter = method.GetParameters()[1];
            var result = CSharpSourceCodeGeneration.GetParameterModifier(parameter);

            result.Should().Be("params ");
        }

        //[TestMethod]
        //public void GetArgumentCallString_OutParameter_ShouldReturnOutKeyword()
        //{
        //    var method = typeof(SampleClass).GetMethod("Method10");
        //    var parameter = method.GetParameters()[1];
        //    var result = CSharpSourceCodeGeneration.GetArgumentCallString(parameter);

        //    result.Should().Be("out " + parameter.Name);
        //}
    }
}