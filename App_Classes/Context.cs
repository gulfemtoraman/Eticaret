using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eticaret.App_Classes;
using Eticaret.Models;

namespace Eticaret.App_Classes
{
    public class Context
    {
        private static Model1 baglanti;

        public static Model1 Baglanti
        {
            get
            {
                if (baglanti == null)
                {
                    baglanti = new Model1();
                }
                return baglanti; 
            }
            set { baglanti = value; }
        }

    }
}