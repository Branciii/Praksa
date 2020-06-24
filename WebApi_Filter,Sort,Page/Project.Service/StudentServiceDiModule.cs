using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Praksa.Service.Common;

namespace ProjectService
{
	public class StudentServiceDiModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<StudentService>().As<IStudentService>().InstancePerDependency();
		}
	}
}