﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Linq;
using System;
using SourceCodeGeneration.Tests.DifferentNamespace;

namespace SourceCodeGeneration.Tests
{
    [TestClass()]
    public class CSharpSourceCodeGenerationTests
    {
        [TestMethod]
        public void GetParameterType_DynamicParameterGiven_ShouldReturnDynamicKeyword()
        {
            var method = typeof(SampleClass).GetMethod("Method9");
            var parameter = method.GetParameters()[0];

            var result = CSharpSourceCodeGeneration.GetParameterType(parameter);
            result.Should().Be("dynamic input");
        }

        [TestMethod]
        public void GetParameterType_GenericParamsParameterGiven_ShouldReturnParamsKeyword()
        {
            var method = typeof(SampleClass).GetMethod("Method11");
            var parameter = method.GetParameters()[0];

            var result = CSharpSourceCodeGeneration.GetParameterType(parameter);
            result.Should().Be("params TValue[] values");
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

        [TestMethod]
        public void GetSafeTypeName_ClassGiven_ShouldReturnClassName()
        {
            var type = typeof(SampleClass);

            var result = CSharpSourceCodeGeneration.GetSafeTypeName(type);

            result.Should().Be(type.Name);
        }

        [TestMethod]
        public void GetSafeTypeName_ArrayGiven_ShouldReturnArrayType()
        {
            var type = typeof(SampleClass[]);

            var result = CSharpSourceCodeGeneration.GetSafeTypeName(type);

            result.Should().Be("SampleClass[]");
        }

        [TestMethod]
        public void GetSafeTypeName_GenericGiven_ShouldReturnCorrespondingGenericExpression()
        {
            var type = typeof(Action<SampleStruct>);

            var result = CSharpSourceCodeGeneration.GetSafeTypeName(type);

            result.Should().Be("Action<SampleStruct>");
        }

        [TestMethod]
        public void GetSafeTypeName_BuiltinTypeGiven_ShouldReturnShortenRepresentation()
        {
            var type = typeof(int);

            var result = CSharpSourceCodeGeneration.GetSafeTypeName(type);

            result.Should().Be("int");
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