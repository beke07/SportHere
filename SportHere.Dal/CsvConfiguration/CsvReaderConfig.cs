using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportHere.Dal.CsvConfiguration
{
    public static class CsvReaderConfig
    {
        public static Configuration Configuration
        {
            get
            {
                return new Configuration()
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                };
            }
        }
    }
}
