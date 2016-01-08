using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SourceCodeGeneration
{
    public static class CSharpSourceCodeGeneration
    {
        public static string GetSafeTypeName(Type type)
        {
            if (type.IsByRef)
            {
                return GetSafeTypeName(type.GetElementType());
            }
            if (type.IsArray)
            {
                return GetSafeTypeName(type.GetElementType()) + "[]";
            }
            if (!type.IsGenericType)
            {
                return (type.IsGenericParameter) ? type.Name : GetTypePrimitiveName(type);
            }

            var generic = type.GetGenericTypeDefinition();
            var sb = new StringBuilder();
            sb.Append(generic.FullName.Substring(0, generic.FullName.IndexOf('`')));
            sb.Append('<');

            int i = 0;
            foreach (var arg in type.GetGenericArguments())
            {
                if (i++ > 0)
                {
                    sb.Append(", ");
                }
                sb.Append(GetSafeTypeName(arg));
            }
            sb.Append('>');
            return sb.ToString();
        }

        public static IEnumerable<string> GetTypeParametersConstrants(MethodInfo method)
        {
            var parameterConstraints = new List<string>();
            foreach (var arg in method.GetGenericArguments())
            {
                var cons = arg.GetGenericParameterConstraints();
                var constraints = cons.Where(x => x != typeof(ValueType)).Select(x => GetSafeTypeName(x)).ToList();
                if ((arg.GenericParameterAttributes & GenericParameterAttributes.ReferenceTypeConstraint) == GenericParameterAttributes.ReferenceTypeConstraint)
                {
                    constraints.Insert(0, "class");
                }
                else if ((arg.GenericParameterAttributes & GenericParameterAttributes.NotNullableValueTypeConstraint) == GenericParameterAttributes.NotNullableValueTypeConstraint)
                {
                    constraints.Insert(0, "struct");
                }
                if (constraints.Count != 0)
                {
                    parameterConstraints.Add(GetSafeTypeName(arg) + ": " + string.Join(", ", constraints.ToArray()));
                }
            }
            return parameterConstraints;
        }

        public static string GetTypeParameters(MethodInfo method)
        {
            return string.Join(", ", method.GetGenericArguments().Select(x => x.Name).ToArray());
        }

        public static string GetInvokingMethodArguments(MethodInfo method)
        {
            return string.Join(", ", method.GetParameters().Select(x => GetInvokinArgumentModifier(x) + x.Name).ToArray());
        }

        public static string GetInvokinArgumentModifier(ParameterInfo parameter)
        {
            if (parameter.IsOut)
            {
                return "out ";
            }
            else if (parameter.ParameterType.IsByRef)
            {
                return "ref ";
            }
            return string.Empty;
        }

        public static string GetParameterModifier(ParameterInfo parameter)
        {
            if (parameter.IsOut)
            {
                return "out ";
            }
            else if (parameter.ParameterType.IsByRef)
            {
                return "ref ";
            }
            else if (parameter.ParameterType.IsArray && parameter.CustomAttributes.OfType<CustomAttributeData>().Any(x => x.AttributeType == typeof(ParamArrayAttribute)))
            {
                return "params ";
            }
            return string.Empty;
        }

        public static string GetParameterType(ParameterInfo parameter)
        {
            //var instance = parameter.CustomAttributes.First();
            //var ddd = parameter.CustomAttributes.First().GetType();
            var typeName = parameter.ParameterType == typeof(object) && parameter.CustomAttributes.OfType<CustomAttributeData>().Any(x => x.AttributeType == typeof(DynamicAttribute)) ? "dynamic" : GetSafeTypeName(parameter.ParameterType);
            return GetParameterModifier(parameter) + typeName + " " + parameter.Name;
        }

        private static readonly CSharpCodeProvider codeProvider = new CSharpCodeProvider();

        public static string GetTypePrimitiveName(Type t)
        {
            if ((t.IsValueType || t == typeof(string)) && !t.IsEnum)
            {
                var type = new CodeTypeReference(t);
                return codeProvider.GetTypeOutput(type);
            }
            return t.FullName;
        }
    }
}
