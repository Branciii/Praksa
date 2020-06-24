using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Praksa.Repository.Common;

namespace ProjectRepository
{
    public class StudentRepositoryDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerDependency();
        }
    }
}
