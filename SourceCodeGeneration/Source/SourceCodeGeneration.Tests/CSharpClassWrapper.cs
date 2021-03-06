﻿using SourceCodeGeneration.Tests;
using System;
using System.Collections.Generic;

namespace SourceCodeGeneration.Tests
{
	public partial class SampleClassWrapper
	{
		private readonly SampleClass _sampleclass;

		public SampleClassWrapper(SampleClass sampleclass)
		{
			_sampleclass = sampleclass;
		}

		public virtual void Method0<TValue>() 		
		{
			_sampleclass.Method0<TValue>();
		}
		public virtual void Method1<TValue>() 
            where TValue: class		
		{
			_sampleclass.Method1<TValue>();
		}
		public virtual void Method2<TValue>() 
            where TValue: struct		
		{
			_sampleclass.Method2<TValue>();
		}
		public virtual void Method3<TValue>() 
            where TValue: IComparable		
		{
			_sampleclass.Method3<TValue>();
		}
		public virtual void Method4<TValue, TResult>() 
            where TValue: class
            where TResult: TValue		
		{
			_sampleclass.Method4<TValue, TResult>();
		}
		public virtual void Method5<TValue>(Func<TValue> func) 
            where TValue: IComparable		
		{
			_sampleclass.Method5<TValue>(func);
		}
		public virtual IEnumerable<TValue> Method6<TValue>(IEnumerable<TValue> func) 
            where TValue: IComparable		
		{
			return _sampleclass.Method6<TValue>(func);
		}
		public virtual void Method7(string str, params Type[] types) 		
		{
			_sampleclass.Method7(str, types);
		}
		public virtual long Method8(ref Type[] types) 		
		{
			return _sampleclass.Method8(ref types);
		}
		public virtual string Method9(dynamic input) 		
		{
			return _sampleclass.Method9(input);
		}
		public virtual bool Method10(string input, out int result) 		
		{
			return _sampleclass.Method10(input, out result);
		}
		public virtual void Method11<TValue>(params TValue[] values) 		
		{
			_sampleclass.Method11<TValue>(values);
		}
		public override int GetHashCode() 		
		{
			return _sampleclass.GetHashCode();
		}
		public override bool Equals(Object obj) 		
		{
			return _sampleclass.Equals(obj);
		}
		public new Type GetType() 		
		{
			return _sampleclass.GetType();
		}
	}
	public partial interface ISampleClass		
	{

      void Method0<TValue>();

      void Method1<TValue>()
            where TValue: class;

      void Method2<TValue>()
            where TValue: struct;

      void Method3<TValue>()
            where TValue: IComparable;

      void Method4<TValue, TResult>()
            where TValue: class
            where TResult: TValue;

      void Method5<TValue>(Func<TValue> func)
            where TValue: IComparable;

      IEnumerable<TValue> Method6<TValue>(IEnumerable<TValue> func)
            where TValue: IComparable;

      void Method7(string str, params Type[] types);

      long Method8(ref Type[] types);

      string Method9(dynamic input);

      bool Method10(string input, out int result);

      void Method11<TValue>(params TValue[] values);
	}
}

