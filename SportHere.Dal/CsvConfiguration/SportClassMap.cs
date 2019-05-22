using CsvHelper.Configuration;
using SportHere.Dal.Entities;
using SportHere.DAL.Entities.ModelBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportHere.Dal.CsvConfiguration
{
    public sealed class SportClassMap : ClassMap<Sport>
    {
        public SportClassMap()
        {
            AutoMap();
            Map(m => m.IsDeleted).Ignore();
        }
    }
}