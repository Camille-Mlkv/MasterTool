using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTool.UI.Services
{
    public static class StringExtension
    {
        public static Color ToColorFromResourceKey(this string resourceKey)
        {
            return Application.Current.Resources
                .MergedDictionaries.First()[resourceKey] as Color;
        }
    }
}
