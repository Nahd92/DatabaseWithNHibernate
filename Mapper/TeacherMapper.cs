using FluentNHibernate.Mapping;
using SchoolTest;

namespace Mapper
{
    public class TeacherMapper : ClassMap<Teacher>
    {
        public TeacherMapper()
        {
            Id(x => x.ID).GeneratedBy.Native();
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
        }
    }
}