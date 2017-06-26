﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG.UBP.Core.Config
{
    internal class UbpConfigSection : ConfigurationSection
    {
        private const string XmlnsKey = "xmlns";
        private const string DbContextInitializerKey = "dbContextInitializer";

        [ConfigurationProperty(XmlnsKey, IsRequired = false)]
        private string Xmlns
        {
            get { return (string)this[XmlnsKey]; }
            set { this[XmlnsKey] = value; }
        }

        [ConfigurationProperty(DbContextInitializerKey)]
        public virtual DbContextInitializerElement DbContextInitializer
        {
            get { return (DbContextInitializerElement)this[DbContextInitializerKey]; }
            set { this[DbContextInitializerKey] = value; }
        }
    }
}
