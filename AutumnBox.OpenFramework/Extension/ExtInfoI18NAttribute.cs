﻿/*************************************************
** auth： zsh2401@163.com
** date:  2018/8/4 23:31:59 (UTC +8:00)
** desc： ...
*************************************************/
using AutumnBox.OpenFramework.Management;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace AutumnBox.OpenFramework.Extension
{
    /// <summary>
    /// 支持多语言的字符串特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public abstract class ExtInfoI18NAttribute : ExtensionAttribute, IInformationAttribute
    {
        private const string DEFAULT_KEY = "all";
        private Dictionary<string, string> kvs;
        /// <summary>
        /// 构建
        /// </summary>
        /// <param name="pairRegionAndValues"></param>
        /// <param name="value"></param>
        public ExtInfoI18NAttribute(params string[] pairRegionAndValues)
        {
            Load(pairRegionAndValues);
        }
        private bool TryParse(string kv, ref string k, ref string v)
        {
            try
            {
                var splits = kv.Split(':');
                if (splits.Count() >= 2)
                {
                    k = splits.First().ToLower();
                    v = string.Join("", splits, startIndex: 1, count: splits.Count() - 1);
                }
                else
                {
                    k = DEFAULT_KEY;
                    v = kv;
                }
                Debug.WriteLine($"{k}:{v}");
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void Load(string[] _kvs)
        {
            kvs = new Dictionary<string, string>();
            if (_kvs == null)
            {
                kvs.Add(DEFAULT_KEY, null);
                return;
            }
            string currentKey = null;
            string currentValue = null;
            foreach (string kv in _kvs)
            {
                if (TryParse(kv, ref currentKey, ref currentValue))
                {
                    try
                    {
                        kvs.Add(currentKey, currentValue);
                    }
                    catch (ArgumentException)
                    {
                        //Same key already exists
                        kvs[currentKey] = currentValue;
                    }
                }
            }
        }
        /// <summary>
        /// 键
        /// </summary>
        public virtual string Key => GetType().Name;
        /// <summary>
        /// 值
        /// </summary>
        public virtual object Value
        {
            get
            {
                return GetByCurrentLanCode();
            }
        }
        /// <summary>
        /// 尝试获取
        /// </summary>
        /// <returns></returns>
        private string GetByCurrentLanCode()
        {
            string crtLanCode = null;
            CallingBus.AutumnBox_GUI.RunOnUIThread(() =>
            {
                crtLanCode = CallingBus.AutumnBox_GUI.GetCurrentLanguageCode().ToLower();
            });
            if (kvs.TryGetValue(crtLanCode, out string value))
            {
                return value;
            }
            try
            {
                return kvs[DEFAULT_KEY];
            }
            catch
            {
                return null;
            }
        }
    }
}
