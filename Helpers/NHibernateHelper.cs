using NHibernate;
using System;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace SchoolTest
{
    public class NHibernateHelper
    {
        private static readonly ISessionFactory _sessionFactory;

        static NHibernateHelper() => _sessionFactory = FluentConfigure();

        public static ISessionFactory FluentConfigure()
        {
            var connectString = @"Server=(localdb)\mssqllocaldb;Database=NHIBERNATEDEMODB;Trusted_Connection=True;";
            return Fluently.Configure()
                    .Database(
                        MsSqlConfiguration.MsSql2012
                            .ConnectionString(connectString).ShowSql())
                .Cache(
                    c => c.UseQueryCache()
                        .UseSecondLevelCache()
                        .ProviderClass<NHibernate.Cache.HashtableCacheProvider>())
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }

        public static ISession GetCurrentSession() => _sessionFactory.OpenSession();

        public static void CloseCurrentSession() => _sessionFactory.Close();

    }

}
