using System;
using System.Collections.Generic;
using System.Text;

namespace GhiasAmooz.Core.Convertors
{
    public class FixedText
    {
        public static string FixEmail(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
