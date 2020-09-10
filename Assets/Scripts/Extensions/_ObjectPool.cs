using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// Decompiled with JetBrains decompiler
// Type: System.Reflection.Internal.ObjectPool`1
// Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 21BBF68D-61D6-4A2A-A5C3-E180E6B6706D
// Assembly location: C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.Core.dll

using System.Collections.Concurrent;
using System.Threading;


/// <summary>
/// This class as same as ObjectPool In .netCore
/// </summary>
public sealed class KObjectPool<T> where T : class
{
    private readonly KObjectPool<T>.Element[] _items;
    private readonly Func<T> _factory;

    internal KObjectPool(Func<T> factory)
      : this(factory, Environment.ProcessorCount * 2)
    {
    }

    internal int Length
    {
        get
        {
            return _items.Length;
        }
    }
    internal KObjectPool(Func<T> factory, int size)
    {
        this._factory = factory;
        this._items = new KObjectPool<T>.Element[size];
    }

    private T CreateInstance()
    {
        return this._factory();
    }

    internal T Allocate()
    {
        // Chổ này thật sự hiệu quả không ta ? - 14/6/2020.
        // Chổ này thiệt sự rất hiệu quả =]]. 15/6/2020.
        KObjectPool<T>.Element[] items = this._items;
        T instance;
        for (int index = 0; index < items.Length; ++index)
        {
            instance = items[index].Value;
            if ((object)instance != null
                // Ignore this for something
                // && (object)instance == (object)Interlocked.CompareExchange<T>(ref items[index].Value, default(T), instance)
                )
            {
                items[index].Value = null;
                return instance;
            }
        }

        instance = this.CreateInstance();
        return instance;
    }

    internal void Free(T obj)
    {
        KObjectPool<T>.Element[] items = this._items;
        for (int index = 0; index < items.Length; ++index)
        {
            if ((object)items[index].Value == null)
            {
                items[index].Value = obj;
                break;
            }
        }
    }

    // Why use struct in here ?????. I dont know that why
    private struct Element
    {
        internal T Value;
    }
}


/// <summary>
/// Tại sao mình không : new() mà phải dùng Class. Và tại sao mình lại không thay new T() mà phải dùng _Factory.
/// Vì mình muốn ẩn Constructor mặc định của class mà thay vào đó Class Manager sở hữu pool sẽ biết chính xác việc init của clas đó.
/// </summary>
/// <typeparam name="T"></typeparam>
internal sealed class KStackPool<T> where T : class
{
    private readonly Stack<T> m_Stack = new Stack<T>();

    private readonly Func<T> _factory;

    internal KStackPool(Func<T> factory)
      : this(factory, Environment.ProcessorCount * 2)
    {

    }
    internal KStackPool(Func<T> factory, int size)
    {
        this._factory = factory;
        m_Stack = new Stack<T>(size);
    }

    public int Size()
    {
        return m_Stack.Count;
    }

    public void Clear()
    {
        m_Stack.Clear();
    }

    internal T Allocate()
    {
        T evt = m_Stack.Count == 0 ? _factory.Invoke() : m_Stack.Pop();
        return evt;
    }

    internal void Free(T element)
    {
        if (m_Stack.Count > 0 && ReferenceEquals(m_Stack.Peek(), element))
        {
            Debug.LogError("Internal error. Trying to destroy object that is already released to pool.");
        }
        else
            m_Stack.Push(element);
    }
}
