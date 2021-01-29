using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolTest.Mapper
{
    public class StudentMapper : ClassMap<Student>
    {
        public StudentMapper()
        {
            Id(x => x.ID).GeneratedBy.Native();
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
        }
    }
}
